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
    public float currentHealth;

    public float walkingThreshold = 0.1f;

    public Vector6 Stats { get; set; }

    private float thresholdMultiplier = 1.2f;

    private ThirdPersonController controller;

    private CharacterAdvancementSystem system;

    private GameObject fist;

    private void Start()
    {
        controller = GetComponent<ThirdPersonController>();
        system = GetComponent<CharacterAdvancementSystem>();
        fist = GameObject.FindWithTag("Fist");

        // Assign the initial values of your stats to the Stats vector
        Stats = new Vector6(strength, intelligence, agility, willpower, luck, charisma);

        // Determine misc values
        baseDefense = (strength + willpower) / 4;
        maxHealth = 20 + (strength * 2);
        maxMana = 20 + (intelligence * 2);
        baseMoveSpeed = 1 + (agility / 4);

        system.GetStats();
        currentHealth = maxHealth;
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
    }

    public void TakeDamage(float damageAmount)
    {
        currentHealth -= damageAmount;

        if (currentHealth <= 0)
        {
            Die();
        }
    }
    private void Die()
    {
        // Handle character death here. E.g., play a death animation, reload the scene, etc.
    }
    public void DealDamage()
    {
        var origin = fist.transform.position;
        Debug.Log("Damage function");
        // Use a raycast or collider check to see if you're hitting an opponent
        // If hitting an opponent, access their CharacterStats and call TakeDamage

        RaycastHit hit;
        float punchRange = 1f; // Example value, adjust accordingly
        Debug.Log("Looking for target");
        Debug.DrawRay(origin, transform.forward * punchRange, Color.red, 2.0f);
        if (Physics.Raycast(origin, transform.forward, out hit, punchRange))
        {
            Debug.Log("Hit Something");
            CharacterStats opponentStats = hit.collider.GetComponent<CharacterStats>();
            if (opponentStats != null)
            {
                Debug.Log("Found target");
                float damageAmount = 10f; // Example value, adjust accordingly
                opponentStats.TakeDamage(damageAmount);
            }
        }
    }
}
