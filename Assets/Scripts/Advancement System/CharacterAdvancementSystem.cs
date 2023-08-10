using System.Collections;
using System.Collections.Generic;
using System.Linq;
using NVectors; //custom namespace for vectors
using UnityEngine;

public class CharacterAdvancementSystem : MonoBehaviour
{
    private CharacterController characterController;
    private CharacterStats stats;


    private const float baseIncreaseAmount = 0.01f; // The base increase for stats

    private void Start()
    {
        characterController = GetComponent<CharacterController>();
        stats = GetComponent<CharacterStats>();
    }

    private void Update()
    {
        if (characterController != null)
        {
            if (characterController.velocity.magnitude > stats.walkingThreshold)
            {
                // Increase the Agility vector
                IncreaseAgility();

                stats.UpdateValues();
            }
        }
    }
    // Stat increases
    public void IncreaseStrength()
    {
        float increaseAmount = CalculateIncrease(stats.Stats.a);
        // Adjust the increase amount based on active MagnitudeModifierBuff
        MagnitudeModifierBuff[] magnitudeBuffs = stats.GetComponents<MagnitudeModifierBuff>();
        foreach (var buff in magnitudeBuffs)
        {
            increaseAmount = buff.ApplyMultiplier(increaseAmount);
        }

        stats.strength += increaseAmount;
        stats.SetStats();
    }

    public void IncreaseIntelligence()
    {
        float increaseAmount = CalculateIncrease(stats.Stats.b);
        // Adjust the increase amount based on active MagnitudeModifierBuff
        MagnitudeModifierBuff[] magnitudeBuffs = stats.GetComponents<MagnitudeModifierBuff>();
        foreach (var buff in magnitudeBuffs)
        {
            increaseAmount = buff.ApplyMultiplier(increaseAmount);
        }

        stats.intelligence += increaseAmount;
        stats.SetStats();
    }
    public void IncreaseWillpower()
    {
        float increaseAmount = CalculateIncrease(stats.Stats.c);
        // Adjust the increase amount based on active MagnitudeModifierBuff
        MagnitudeModifierBuff[] magnitudeBuffs = stats.GetComponents<MagnitudeModifierBuff>();
        foreach (var buff in magnitudeBuffs)
        {
            increaseAmount = buff.ApplyMultiplier(increaseAmount);
        }

        stats.willpower += increaseAmount;
        stats.SetStats();
    }
    public void IncreaseLuck()
    {
        float increaseAmount = CalculateIncrease(stats.Stats.d);
        // Adjust the increase amount based on active MagnitudeModifierBuff
        MagnitudeModifierBuff[] magnitudeBuffs = stats.GetComponents<MagnitudeModifierBuff>();
        foreach (var buff in magnitudeBuffs)
        {
            increaseAmount = buff.ApplyMultiplier(increaseAmount);
        }

        stats.luck += increaseAmount;
        stats.SetStats();
    }
    public void IncreaseAgility()
    {
        float increaseAmount = CalculateIncrease(stats.Stats.e);
        // Adjust the increase amount based on active MagnitudeModifierBuff
        MagnitudeModifierBuff[] magnitudeBuffs = stats.GetComponents<MagnitudeModifierBuff>();
        foreach (var buff in magnitudeBuffs)
        {
            increaseAmount = buff.ApplyMultiplier(increaseAmount);
        }

        stats.agility += increaseAmount;
        stats.SetStats();
    }
    public void IncreaseCharisma()
    {
        float increaseAmount = CalculateIncrease(stats.Stats.f);
        // Adjust the increase amount based on active MagnitudeModifierBuff
        MagnitudeModifierBuff[] magnitudeBuffs = stats.GetComponents<MagnitudeModifierBuff>();
        foreach (var buff in magnitudeBuffs)
        {
            increaseAmount = buff.ApplyMultiplier(increaseAmount);
        }

        stats.charisma += increaseAmount;
        stats.SetStats();
    }

    private float CalculateIncrease(float currentStatValue)
    {
        return baseIncreaseAmount / (1 + currentStatValue);
    }


    public void TakeDamage(float attackerStrength)
    {
        float damageDealt = attackerStrength - stats.baseDefense;
        stats.maxHealth -= Mathf.Max(damageDealt, 0); // Ensure we don't heal the character

        // If health goes below 0, you can handle character death here
        if (stats.maxHealth <= 0)
        {
            // Handle character death, e.g., play death animation, respawn, etc.
        }
    }
}
