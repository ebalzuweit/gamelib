using UnityEngine;

namespace gamelib
{
    public class IkRoot : MonoBehaviour
    {
        [SerializeField] private EndEffector[] _endEffectors;

        public void Init()
        {
            foreach (var effector in _endEffectors)
                effector.Init(this);
        }

        private void Awake()
        {
            Init();
        }
    }
}
