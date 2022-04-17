using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace com.ebalzuweit.gamelib
{
    public class EndEffector : MonoBehaviour
    {
        [SerializeField] private Transform _goal;

        [SerializeField, Tooltip("If set, bones will prefer to be closer to the control transform.")]
        private Transform _control;

        private IkRoot _root;
        private Transform[] _bones;
        private Vector3[] _positions;
        private float[] _boneLengths;
        private float _fullLength;
        private Vector3[] _startDirections;
        private Quaternion[] _startRotations;
        private Quaternion _targetStartRotation;

        public void Init(IkRoot root)
        {
            if (!transform.IsChildOf(root.transform) || transform == root.transform)
                throw new ArgumentException(nameof(root), "EndEffector must be a child of its IkRoot.");

            _root = root;
            _bones = GetBones().ToArray();
            _positions = new Vector3[_bones.Length];
            _startDirections = new Vector3[_bones.Length];
            _startRotations = new Quaternion[_bones.Length];
            _boneLengths = new float[_bones.Length - 1];
            _fullLength = 0f;
            _targetStartRotation = _goal.rotation;

            for (int i = _bones.Length - 1; i >= 0; i--)
            {
                var cur = _bones[i];
                _startRotations[i] = cur.rotation;

                if (i == _bones.Length - 1)
                {
                    _startDirections[i] = _goal.position - cur.position;
                }
                else
                {
                    _boneLengths[i] = (_bones[i + 1].position - cur.position).magnitude;
                    _fullLength += _boneLengths[i];
                    _startDirections[i] = _bones[i + 1].position - cur.position;
                }
            }
        }

        // FABRIK implementation adapted from https://logicalbeat.jp/blog/6235/
        public void ResolveIk()
        {
            const int iterations = 10;
            const float accuracy = 0.001f;

            // read bone positions
            for (int i = 0; i < _positions.Length; i++)
                _positions[i] = _bones[i].position;

            // resolve IK
            var sqDistToTarget = (_goal.position - _bones[0].position).sqrMagnitude;
            if (sqDistToTarget >= _fullLength * _fullLength)
            {
                // target out-of-range
                var dir = (_goal.position - _positions[0]).normalized;

                for (int i = 1; i < _positions.Length; i++)
                    _positions[i] = _positions[i - 1] + dir * _boneLengths[i - 1];
            }
            else
            {
                for (int iteration = 0; iteration < iterations; iteration++)
                {
                    // back-propagation
                    for (int i = _positions.Length - 1; i > 0; i--)
                    {
                        if (i == _positions.Length - 1)
                        {
                            _positions[i] = _goal.position;
                        }
                        else
                        {
                            _positions[i] = _positions[i + 1] + (_positions[i] - _positions[i + 1]).normalized * _boneLengths[i];
                        }
                    }

                    // front-propagation
                    for (int i = 1; i < _positions.Length; i++)
                    {
                        _positions[i] = _positions[i - 1] + (_positions[i] - _positions[i - 1]).normalized * _boneLengths[i - 1];
                    }

                    float sqDist = (_positions[_positions.Length - 1] - _goal.position).sqrMagnitude;
                    if (sqDist < accuracy * accuracy)
                        break; // within accuracy, exit early
                }

                // move bones towards control object
                if (_control != null)
                {
                    for (int i = 1; i < _positions.Length - 1; i++)
                    {
                        var projectionPlane = new Plane(_positions[i + 1] - _positions[i - 1], _positions[i - 1]);
                        var projectedBonePosition = projectionPlane.ClosestPointOnPlane(_positions[i]);
                        var projectedControl = projectionPlane.ClosestPointOnPlane(_control.position);
                        float angleOnPlane = Vector3.SignedAngle(projectedBonePosition - _positions[i - 1], projectedControl - _positions[i - 1], projectionPlane.normal);
                        _positions[i] = Quaternion.AngleAxis(angleOnPlane, projectionPlane.normal) * (_positions[i] - _positions[i - 1]) + _positions[i - 1];
                    }
                }
            }

            // write bone positions
            for (int i = 0; i < _positions.Length; i++)
                _bones[i].position = _positions[i];

            // write bone rotations
            for (int i = 0; i < _positions.Length; i++)
            {
                if (i == _positions.Length - 1)
                    _bones[i].rotation = _goal.rotation * Quaternion.Inverse(_targetStartRotation) * _startRotations[i];
                else
                    _bones[i].rotation = Quaternion.FromToRotation(_startDirections[i], _positions[i + 1] - _positions[i]) * _startRotations[i];
            }
        }

        private void Start()
        {
            if (_root == null)
            {
                Debug.LogError("EndEffector reached Start without configured IkRoot!");
                Destroy(this);
            }
        }

        private void Update()
        {
            ResolveIk();
        }

        private IEnumerable<Transform> GetBones()
        {
            var bones = new List<Transform>();
            var current = transform;
            while (current != _root.transform)
            {
                bones.Add(current);
                current = current.parent;
            }
            bones.Reverse();

            return bones;
        }

        private void OnDrawGizmos()
        {
            if (_root == null)
                return;
            for (int i = 1; i < _bones.Length; i++)
            {
                Debug.DrawLine(_bones[i].position, _bones[i - 1].position, Color.green);
            }
        }
    }
}
