using NVectors;
using System.Collections;
using UnityEngine;

public class EnemyStats : MonoBehaviour
{
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
    public void InitializeBasedOnPlayer(Vector6 playerStats)
    {
        // Calculate the difference between the player's stats and some baseline stats (e.g., default enemy stats)
        Vector6 baselineStats = new Vector6(1.0f, 1.0f, 1.0f, 1.0f, 1.0f, 1.0f); // You can adjust this to whatever base values you want
        Vector6 difference = playerStats - baselineStats;

        // Normalize this difference to get values between -1 and 1
        Vector6 normalizedDifference = difference.Normalize();

        // Scale the normalized difference by 10% of the player's stats
        Vector6 scaledDifference = normalizedDifference * 0.10f;

        // Calculate the enemy's stats by adding this scaled difference to the player's stats
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

    public void TakeDamage(float attackerStrength)
    {
        if (isDead) return; // Don't take damage if already dead

        float damageDealt = 10 + attackerStrength - defense;
        health -= Mathf.Max(damageDealt, 0); // Ensure we don't heal the enemy
        Debug.Log("Dealt " + damageDealt + " Damage");
        if (health <= 0 && !isDead)
        {
            isDead = true;
            Debug.Log("Enemy died. Attempting to hide.");
            SetActiveState(false);
            StartCoroutine(RespawnAfterDelay());
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
        InitializeBasedOnPlayer(FindObjectOfType<CharacterStats>().Stats); // Assuming there's only one player character in the scene
                                                                           // Reset health and other stats if necessary
        health = 20 + Stats.a * 2;
        defense = Stats.a + Stats.d / 4;
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
}
