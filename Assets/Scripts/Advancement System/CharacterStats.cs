using System.Collections;
using System.Collections.Generic;
using NVectors;
using StarterAssets;
using UnityEditorInternal;
using UnityEngine;

public class CharacterStats : MonoBehaviour
{
    public float strength;
    public float intelligence;
    public float willpower;
    public float luck;
    public float agility;
    public float charisma;
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
        gameObject.SetActive(false);
    }
    public void DealDamage()
    {
        // Define the size of the box (for example, 1x1x1 units)
        Vector3 boxSize = new Vector3(1f, 1f, 1f);

        // Define the direction to cast the box (forward from the player)
        Vector3 direction = transform.forward;

        // Define the maximum distance the box should be cast
        float maxDistance = 2f; // You can adjust this value

        RaycastHit hit;
        if (Physics.BoxCast(transform.position, boxSize / 2, direction, out hit, Quaternion.identity, maxDistance))
        {
            Debug.Log("BoxCast hit: " + hit.collider.name); // Log the name of the object hit

            // Visualize the boxcast in the editor (for 2 seconds)
            Debug.DrawRay(transform.position, direction * hit.distance, Color.red, 2.0f);

            // Check if we hit an enemy and deal damage
            EnemyStats enemy = hit.collider.GetComponent<EnemyStats>();
            if (enemy != null)
            {
                Debug.Log("Dealing damage to enemy."); // Log when we're about to deal damage
                                                       // For this example, we're using a fixed damage value, but you can adjust based on player's strength or other factors
                enemy.TakeDamage(Stats.a * 2);
            }
            else
            {
                Debug.Log("Hit object is not an enemy."); // Log if the hit object is not an enemy
            }
        }
        else
        {
            Debug.Log("BoxCast did not hit anything."); // Log when boxcast doesn't detect any hits
        }
    }

}
