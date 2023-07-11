using System.Collections;
using System.Collections.Generic;
using System.Linq;
using NVectors;//custom namespace for vectors
using UnityEngine;

public class CharacterAdvancementSystem : MonoBehaviour
{
    // Assuming that the progress vectors are stored in a Dictionary with the stat name as the key
    private Dictionary<string, float> progressVectors = new Dictionary<string, float>();

    // The threshold for each stat to increase
    private const float statIncreaseThreshold = 100.0f; // Change this value to your desired threshold

    public void AddProgress(CharacterStats characterStats, string statName, float progressAmount)
    {
        // Check if the stat exists in the progress vectors
        if (!progressVectors.ContainsKey(statName))
        {
            // If not, initialize it
            progressVectors[statName] = 1.0f;
        }

        // Add the progress to the stat
        progressVectors[statName] += progressAmount;

        // Check if any stat should be increased
        CheckVectors(characterStats);
    }

    private void CheckVectors(CharacterStats characterStats)
    {
        // Iterate over all progress vectors
        foreach (var stat in progressVectors.Keys.ToList())
        {
            // Get the current value of the stat
            int statValue = characterStats.GetStatValue(stat); // Assuming that GetStatValue returns the current value of the stat

            // Calculate the threshold for this stat based on its current value
            float threshold = CalculateThreshold(statValue); // Assuming that CalculateThreshold calculates the threshold based on the stat value

            // Check if the progress vector has reached the threshold
            if (progressVectors[stat] >= threshold)
            {
                // Increase the stat
                characterStats.IncreaseStat(stat, 1);

                // Reset the progress vector for the stat
                progressVectors[stat] = 0.0f;
            }
        }
    }
    private float CalculateThreshold(int statValue)
    {
        // Calculate the threshold based on the stat value
        return statValue * 10.0f;
    }
}
