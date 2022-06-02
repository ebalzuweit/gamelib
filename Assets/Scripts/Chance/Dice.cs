using UnityEngine;

namespace com.ebalzuweit.gamelib.Chance
{
    public static class Dice
    {
        public static int Roll(int numSides = 6, int numDice = 1)
        {
            int sum = 0;
            for (int i = 0; i < numDice; i++)
            {
                sum += Random.Range(1, numSides + 1);
            }
            return sum;
        }
    }
}