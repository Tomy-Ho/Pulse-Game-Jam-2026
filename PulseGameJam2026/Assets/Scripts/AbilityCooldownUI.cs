using UnityEngine;
using UnityEngine.UI;

public class AbilityCooldownUI : MonoBehaviour
{
    public AbilityHolderBase abilityHolder;
    public Image cooldownOverlay;

    void Update()
    {
        if (abilityHolder == null || cooldownOverlay == null)
        {
            Debug.LogWarning("Missing reference on " + gameObject.name);
            return;
        }

        Debug.Log(gameObject.name + " progress: " + abilityHolder.CooldownProgress + " cooldown: " + abilityHolder.IsOnCooldown);
        cooldownOverlay.fillAmount = abilityHolder.CooldownProgress;
    }
}