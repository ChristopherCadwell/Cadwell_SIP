using UnityEngine;
using System.Collections;
using NVectors;
using System.Collections.Generic;

[System.Serializable]
public class StatModifierBuff : Buff
{
    public Vector6 targetStats; // The target stats for this buff
    public float lerpSpeed = 0.05f; // The speed at which the character's stats will lerp towards the target stats

    private Vector6 _targetStats;
    private float _duration;

    private CharacterStats characterStats; // Reference to the CharacterStats component

    private static Dictionary<string, int> potionCount = new Dictionary<string, int>()
{
    {"Potion1", 0},
    {"Potion2", 0},
    {"Potion3", 0}
};
    private string potionType = "";

    public void ApplyPotion1()
    {
        potionType = "Potion1";
        // Increase the count for Potion1
        potionCount["Potion1"] += 1;

        // Adjust the lerpSpeed
        lerpSpeed += 0.2f * potionCount["Potion1"];  // Adjust the multiplier as desired

        targetStats = new Vector6(1000, 1000, 1000, 1000, 1000, 1000);
        Apply();
    }

    public void ApplyPotion2()
    {
        potionType = "Potion2";
        // Increase the count for Potion2
        potionCount["Potion2"] += 1;

        // Adjust the lerpSpeed
        lerpSpeed += 0.2f * potionCount["Potion2"];  // Adjust the multiplier as desired

        targetStats = new Vector6(characterStats.Stats.a, characterStats.Stats.b, characterStats.Stats.c, characterStats.Stats.d, 1000, characterStats.Stats.f);
        Apply();
    }

    public void ApplyPotion3()
    {
        potionType = "Potion3";
        // Increase the count for Potion2
        potionCount["Potion3"] += 1;

        // Adjust the lerpSpeed
        lerpSpeed += 0.2f * potionCount["Potion3"];  // Adjust the multiplier as desired

        float maxStat = Mathf.Max(characterStats.Stats.a, characterStats.Stats.b, characterStats.Stats.c, characterStats.Stats.d, characterStats.Stats.e, characterStats.Stats.f);
        targetStats = new Vector6(maxStat, maxStat, maxStat, maxStat, maxStat, maxStat);
        Apply();
    }


    public StatModifierBuff(Vector6 targetStats, float duration)
    {
        _targetStats = targetStats;
        _duration = duration;
    }
    private void Start()
    {
        characterStats = GetComponent<CharacterStats>();
    }

    public void Apply()
    {
        characterStats.StartCoroutine(ApplyCoroutine());
    }

    private IEnumerator ApplyCoroutine()
    {
        Vector6 initialStats = characterStats.Stats;
        float elapsedTime = 0f;

        while (elapsedTime < duration)
        {
            characterStats.Stats = Vector6.Lerp(initialStats, targetStats, elapsedTime * lerpSpeed / duration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        characterStats.Stats = targetStats;  // Ensure we reach the target stats at the end

        yield return new WaitForSeconds(duration - elapsedTime);  // Wait for the remaining duration

        // Decrement the potion count after its effect expires
        string potionType = GetPotionType();
        if (potionType != null && potionCount.ContainsKey(potionType))
        {
            potionCount[potionType] -= 1;

            // Adjust the lerpSpeed based on the potion count
            lerpSpeed -= 0.05f * potionCount[potionType];
        }

        // Revert the stats
        characterStats.Stats = initialStats;
    }

    private string GetPotionType()
    {
        return potionType;
    }



    public void SetTargetStats(Vector6 targetStats)
    {
        this.targetStats = targetStats;
    }

    public void SetDuration(float duration)
    {
        this.duration = duration;
    }
}