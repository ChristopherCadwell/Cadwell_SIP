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

    private Vector6 progressThresholds = new Vector6(1.0f, 1.0f, 1.0f, 1.0f, 1.0f, 1.0f);

    private float thresholdMultiplier = 1.2f;

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
        baseMoveSpeed = 1 + (agility / 4);
    }

    public void IncreaseAgility()
    {
        // Define the increment for agility.
        float agilityIncrement = 1f;

        // Increase the agility stat
        agility += agilityIncrement;

        // Recalculate dependent values
        baseMoveSpeed = 1 + (agility / 4);
        controller.UpdateMoveSpeed(baseMoveSpeed);
    }
    private void CheckProgressVectors()
    {
        Debug.Log("Checking");

        // Check if the agility progress vector has reached its threshold
        if (ProgressVectors.c >= progressThresholds.c)
        {
            Debug.Log("True");

            // Increase the agility stat
            IncreaseAgility();

            // Reset the agility progress vector
            ProgressVectors = new Vector6(ProgressVectors.a, ProgressVectors.b, 0, ProgressVectors.d, ProgressVectors.e, ProgressVectors.f);

            // Increase the agility progress vector threshold
            progressThresholds = new Vector6(progressThresholds.a, progressThresholds.b, progressThresholds.c * thresholdMultiplier, progressThresholds.d, progressThresholds.e, progressThresholds.f);

            // Update the Stats vector
            Stats = new Vector6(strength, intelligence, agility, willpower, luck, charisma);
        }


        // Repeat for other stats...
    }
    public void IncreaseProgressVectors(float strength, float intelligence, float agility, float willpower, float luck, float charisma)
    {
        ProgressVectors = new Vector6(ProgressVectors.a + strength, ProgressVectors.b + intelligence, ProgressVectors.c + agility,
        ProgressVectors.d + willpower, ProgressVectors.e + luck, ProgressVectors.f + charisma);
        Debug.Log("Increased progress vectors " + ProgressVectors.c);

        // Check if any progress vector has reached its threshold
        CheckProgressVectors();

    }
}
