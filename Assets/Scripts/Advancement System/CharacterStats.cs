using System.Collections;
using System.Collections.Generic;
using NVectors;
using StarterAssets;
using UnityEditorInternal;
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

    public float walkingThreshold = 0.1f;

    public Vector6 Stats { get; set; }

    private float thresholdMultiplier = 1.2f;

    private ThirdPersonController controller;

    private CharacterAdvancementSystem system;

    private void Start()
    {
        controller = GetComponent<ThirdPersonController>();
        system = GetComponent<CharacterAdvancementSystem>();

        // Assign the initial values of your stats to the Stats vector
        Stats = new Vector6(strength, intelligence, agility, willpower, luck, charisma);

        // Determine misc values
        baseDefense = (strength + willpower) / 4;
        maxHealth = 20 + (strength * 2);
        maxMana = 20 + (intelligence * 2);
        baseMoveSpeed = 1 + (agility / 4);

        system.GetStats();
    }
    public void UpdateValues()
    {
        strength = Stats.a;
        intelligence = Stats.b;
        willpower = Stats.c;
        luck = Stats.d;
        agility = Stats.e;
        charisma = Stats.f;

        // Determine misc values
        baseDefense = (Stats.a + Stats.d) / 4;
        maxHealth = 20 + (Stats.a * 2);
        maxMana = 20 + (Stats.b * 2);
        baseMoveSpeed = 1 + (Stats.e / 4);
        Debug.Log(baseMoveSpeed.ToString());
    }
}
