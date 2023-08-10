using UnityEngine;
using System.Collections;

public class MagnitudeModifierBuff : Buff
{
    private CharacterStats characterStats;
    public float multiplier = 1.0f; // The current multiplier for this buff

    private void Start()
    {
        characterStats = GetComponent<CharacterStats>();
    }
    public MagnitudeModifierBuff(CharacterStats charStats, float duration)
    {
        characterStats = charStats;
        this.duration = duration;
    }

    public float ApplyMultiplier(float initialIncrease)
    {
        return initialIncrease * multiplier;
    }

    public void ApplyPotion4()
    {
        multiplier = 2.0f;
        Apply();
    }

    public void ApplyPotion5()
    {
        multiplier = 10.0f;
        Apply();
    }

    public void ApplyPotion6()
    {
        multiplier = 100.0f;
        Apply();
    }

    private void Apply()
    {
        characterStats.ApplyBuff(this);
        StartCoroutine(ExpirationCoroutine());
    }

    private IEnumerator ExpirationCoroutine()
    {
        yield return new WaitForSeconds(duration);

        // Revert the multiplier
        multiplier = 1.0f; // Resetting the multiplier to its base value

        characterStats.RemoveBuff(this);
    }
}
