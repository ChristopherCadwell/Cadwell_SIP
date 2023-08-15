using NVectors;
using System.Collections;
using UnityEngine;

public class EnemyStats : MonoBehaviour
{
    public float variancePercent = 0.1f;
    public Vector6 Stats { get; set; }
    public float health;
    public float defense;
    public float maxHealth;
    public float strength;
    public float intelligence;
    public float willpower;
    public float luck;
    public float agility;
    public float charisma;
    public float multiplier = 1.0f;
    public float dynamicMultiplier = 1.0f;
    public bool isDynamicDifficulty;


    public GameObject enemyPrefab; // The enemy prefab for respawning
    private bool isDead = false; // Track if the enemy is currently dead
    private float respawnTimer = 2.0f; // Time in seconds before the enemy respawns

    private MeshRenderer[] meshRenderers;
    private Collider[] colliders;
    private Transform childObject;

    private void Awake()
    {
        // Cache references to all mesh renderers and colliders in the enemy
        meshRenderers = GetComponentsInChildren<MeshRenderer>();
        colliders = GetComponentsInChildren<Collider>();
        childObject = transform.GetChild(0);
    }
    

    public void TakeDamage(float attackerStrength)
    {
        if (isDead) return; // Don't take damage if already dead

        float damageDealt = 10 + attackerStrength - defense;
        health -= Mathf.Max(damageDealt, 0); // Ensure we don't heal the enemy
        Debug.Log("Dealt " + damageDealt + " Damage");
        if (health <= 0 && !isDead)
        {
           Debug.Log("Difference between stat values = "+ HandleDeath());
        }
    }

    private IEnumerator RespawnAfterDelay()
    {
        yield return new WaitForSeconds(respawnTimer);
        Respawn();
    }

    private void Respawn()
    {
        isDead = false;
        if (isDynamicDifficulty)
        {
            multiplier = dynamicMultiplier;
            InitializeBasedOnPlayer(FindObjectOfType<CharacterStats>().Stats);
        }
        else
        {
            InitializeBasedOnPlayer(FindObjectOfType<CharacterStats>().Stats);
        }
        
        // Reset health and other stats
        health = 20 + Stats.a * 2;
        defense = Stats.a / 50;
        SetActiveState(true); // Show and make the enemy interactable again
    }

    private void SetActiveState(bool state)
    {
        if (childObject != null)
        {
            childObject.gameObject.SetActive(state);
        }
        // Toggle visibility
        foreach (var renderer in meshRenderers)
        {
            renderer.enabled = state;
        }

        // Toggle interactivity
        foreach (var collider in colliders)
        {
            collider.enabled = state;
        }
    }
    public void InitializeBasedOnPlayer(Vector6 playerStats)
    {
        // Calculate the scaled difference directly from the player's stats
        Vector6 scaledDifference = playerStats * multiplier;

        // Calculate the enemy's stats by adding the scaled difference to the player's stats
        Stats = playerStats + scaledDifference;

        // Setting health and defense based on the generated stats
        maxHealth = 20 + Stats.a * 2;
        health = maxHealth;
        defense = Stats.a + Stats.d / 20;
        strength = Stats.a;
        intelligence = Stats.b;
        willpower = Stats.c;
        luck = Stats.d;
        agility = Stats.e;
        charisma = Stats.f;
    }
    
        public float HandleDeath()
        {
            isDead = true;
            dynamicMultiplier += 0.1f;
            Debug.Log("Enemy died. Attempting to hide.");
            SetActiveState(false);
            StartCoroutine(RespawnAfterDelay());

            // Calculate the difference between this object's stats and the player stats
            Vector6 difference = Stats - FindObjectOfType<CharacterStats>().Stats;
            // Return the magnitude of the difference
            return difference.Magnitude();
        }
    
}
