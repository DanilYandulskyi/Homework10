using UnityEngine;

public class ChanceGenerator 
{
    private static int s_maxChance = 100;

    public static bool CalculateChances(int chance)
    {
        int randomNumber = Random.Range(0, s_maxChance);

        return randomNumber < chance;
    }
}