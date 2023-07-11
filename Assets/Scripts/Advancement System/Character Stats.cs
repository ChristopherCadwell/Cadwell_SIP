using System.Collections;
using System.Collections.Generic;
using NVectors;
using UnityEngine;

public class CharacterStats : MonoBehaviour
{
    public enum ActionType
    {
        Walk,
        Run,
        Fall,
        takeMeleeDamage,
        takeMagicDamage,
        PhysicalAttack,
        MagicAttack
    }
    public float strength = 1.0f;
    public float intelligence = 1.0f;
    public float willpower = 1.0f;
    public float luck = 1.0f;
    public float agility = 1.0f;
    public float charisma = 1.0f;
    public float baseDefense;
    public float maxHealth;
    public float maxMana;
    public float baseMoveSpeed;

    public Vector6 Stats { get; set; }
    public Vector6 ProgressVectors { get; private set; }

    private Dictionary<string, int> stats = new Dictionary<string, int>();

    private void Start()
    {
        // Assign the initial values of your stats to the Stats vector
        Stats = new Vector6(strength, intelligence, agility, willpower, luck, charisma);

        // Determine misc values
        baseDefense = (strength + willpower) / 4;
        maxHealth = 20 + (strength * 2);
        maxMana = 20 + (intelligence * 2);
        baseMoveSpeed = 5 + (agility / 4);
    }

    // Stat changes
    public void UpdateStatsVector()
    {
        Stats = new Vector6(strength, intelligence, agility, willpower, luck, charisma);
    }
    public void AddProgress(ActionType actionType, float increaseValue)
    {
        // ActionType is an enum you define that corresponds to different actions
        // that can increase a stat.
        
    }
    public int GetStatValue(string statName)
    {
        // Check if the stat exists in the stats dictionary
        if (!stats.ContainsKey(statName))
        {
            // If not, return 0 or some default value
            return 0;
        }

        // Return the value of the stat
        return stats[statName];
    }
}
