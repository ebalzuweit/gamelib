using System;
using UnityEngine;

namespace com.ebalzuweit.gamelib.Chance
{
    [CreateAssetMenu(fileName = "New Loot Table", menuName = "gamelib/Loot Table")]
    public class LootTable<T> : ScriptableObject
    {
        // TODO: Proper data structure and custom inspector
        [SerializeField] private T[] _table;

        public T[] Roll(int numRolls = 1, bool withReplacement = true)
        {
            if (_table.Length == 0)
                throw new InvalidOperationException("Table has no elements.");
            if (numRolls <= 0)
                throw new ArgumentOutOfRangeException(nameof(numRolls), "Must be positive.");
            if (withReplacement == false && numRolls >= _table.Length)
                throw new ArgumentOutOfRangeException(nameof(numRolls), "Table has too few elements.");
            if (withReplacement == false)
                throw new NotImplementedException("Rolls without replacement not implemented yet.");

            T[] rolls = new T[numRolls];
            for (int i = 0; i < numRolls; i++)
            {
                T roll;
                roll = _table[UnityEngine.Random.Range(0, _table.Length)];
                rolls[i] = roll;
            }
            return rolls;
        }
    }
}