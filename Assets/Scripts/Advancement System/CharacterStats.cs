using System.Collections;
using System.Collections.Generic;
using NVectors;
using StarterAssets;
using UnityEngine;

public class CharacterStats : MonoBehaviour
{
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

    public float walkingThreshold = 1.0f;

    public Vector6 Stats { get; set; }
    public Vector6 ProgressVectors { get; private set; }

    private ThirdPersonController controller;

    private void Start()
    {
        controller = GetComponent<ThirdPersonController>();
        // Assign the initial values of your stats to the Stats vector
        Stats = new Vector6(strength, intelligence, agility, willpower, luck, charisma);
        ProgressVectors = new Vector6();

        // Determine misc values
        baseDefense = (strength + willpower) / 4;
        maxHealth = 20 + (strength * 2);
        maxMana = 20 + (intelligence * 2);
        baseMoveSpeed = 5 + (agility / 4);
    }

    public void IncreaseAgility()
    {
        // Define the increment for agility.
        float agilityIncrement = 0.01f;

        // Increase the agility stat
        agility += agilityIncrement;

        // Create a new Vector6 with the increased agility value, and assign it to ProgressVectors
        ProgressVectors = new Vector6(ProgressVectors.a, ProgressVectors.b, ProgressVectors.c + agilityIncrement,
            ProgressVectors.d, ProgressVectors.e, ProgressVectors.f);
        Debug.Log("Vector moved " + ProgressVectors);

        // Recalculate dependent values
        baseMoveSpeed = 5 + (agility / 4);
        controller.UpdateMoveSpeed(baseMoveSpeed);
    }
}
