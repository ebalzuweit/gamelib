using UnityEngine;

public class SpawnVolume : Volume
{
    [SerializeField] private GameObject[] _spawnList;
    [SerializeField, Min(1)] private int _spawnCount = 1;
    [SerializeField] private Transform _spawnParent;

    public void Spawn()
    {
        for (int i = 0; i < _spawnCount; i++)
        {
            var prefab = _spawnList[Random.Range(0, _spawnList.Length)];
            var position = GetRandomPosition();
            Instantiate(prefab, position, Quaternion.identity, _spawnParent);
        }
    }
}