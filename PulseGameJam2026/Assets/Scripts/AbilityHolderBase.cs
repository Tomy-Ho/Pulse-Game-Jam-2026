using UnityEngine;
using UnityEngine.InputSystem;

public abstract class AbilityHolderBase : MonoBehaviour
{
    public GameObject player;
    public Ability ability;
    protected PlayerMovement playerMovement;

    protected float cooldownTime;
    protected float activeTime;
    public Key key;

    protected enum AbilityState
    {
        ready,
        active,
        cooldown
    }
    protected AbilityState state = AbilityState.ready;

    public float CooldownProgress
    {
        get
        {
            if (ability == null || ability.cooldownTime <= 0) return 0f;
            return Mathf.Clamp01(cooldownTime / ability.cooldownTime);
        }
    }
    

    public bool IsOnCooldown => state == AbilityState.cooldown;
    public bool IsActive => state == AbilityState.active;
    public bool IsReady => state == AbilityState.ready;

    protected virtual void Update()
    {
        // shared guard, called via base.Update() in children
    }
}