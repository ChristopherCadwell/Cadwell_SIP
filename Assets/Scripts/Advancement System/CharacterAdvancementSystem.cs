using System.Collections;
using System.Collections.Generic;
using System.Linq;
using NVectors;//custom namespace for vectors
using UnityEngine;

public class CharacterAdvancementSystem : MonoBehaviour
{
    private CharacterController characterController;
    private CharacterStats stats;

    private void Start()
    {
        characterController = GetComponent<CharacterController>();
        stats = GetComponent<CharacterStats>();

    }

    private void Update()
    {
        // Check if the player is walking
        if (characterController.velocity.magnitude > stats.walkingThreshold)
        {
            var agilityIncrease = 0.1f;
            // Increase the agility progress vector
            stats.IncreaseProgressVectors(0,0,agilityIncrease,0,0,0);
        }
    }
}
