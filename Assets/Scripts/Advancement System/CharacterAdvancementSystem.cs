using System.Collections;
using System.Collections.Generic;
using System.Linq;
using NVectors;//custom namespace for vectors
using UnityEngine;

public class CharacterAdvancementSystem : MonoBehaviour
{
    private CharacterController characterController;
    private CharacterStats stats;
    [SerializeField] private float strength;
    [SerializeField] private float intelligence;
    [SerializeField] private float willpower;
    [SerializeField] private float luck;
    [SerializeField] private float agility;
    [SerializeField] private float charisma;

    private void Start()
    {
        characterController = GetComponent<CharacterController>();
        stats = GetComponent<CharacterStats>();
    }

    private void Update()
    {
        if (characterController.velocity.magnitude > stats.walkingThreshold)
        {
            var agilityIncrease = 0.01f;
            // Increase the Agility vector
            agility = agility + agilityIncrease;

            SetStats(strength, intelligence, willpower, luck, agility, charisma);
            stats.UpdateValues();
            Debug.Log("Updated");
        }
    }
    public void GetStats()
    {
        strength = stats.Stats.a;
        intelligence = stats.Stats.b;
        willpower = stats.Stats.c;
        luck = stats.Stats.d;
        agility = stats.Stats.e;
        charisma = stats.Stats.f;
    }
    public void SetStats(float Str, float Int, float Wil, float Luc, float Agi, float Cha)
    {
        stats.Stats = new Vector6(Str, Int, Wil, Luc, Agi, Cha);
    }
}
