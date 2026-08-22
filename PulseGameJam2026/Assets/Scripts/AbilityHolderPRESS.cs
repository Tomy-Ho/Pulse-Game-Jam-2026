using UnityEngine;
using UnityEngine.InputSystem;

public class AbilityHolderPRESS : MonoBehaviour
{
    public GameObject player;
    public Ability ability;
    float cooldownTime;
    float activeTime;
    enum AbilityState
    {
        ready,
        active,
        cooldown
    }

    AbilityState state = AbilityState.ready;
    
    public Key key;

    void Update(){
        switch(state) {
            case AbilityState.ready:
                if (Keyboard.current[key].wasPressedThisFrame){
                    ability.Activate(gameObject);
                    activeTime = ability.activeTime;
                    state = AbilityState.active;
                    
                }
                break;
            case AbilityState.active:
                if(activeTime > 0){
                    activeTime -= Time.deltaTime;
                }
                else {
                    ability.BeginCooldown(gameObject);
                    state = AbilityState.cooldown;
                    cooldownTime = ability.cooldownTime;                    
                }

                break;
            case AbilityState.cooldown:
                if(cooldownTime > 0) {
                    cooldownTime -= Time.deltaTime;
                }
                else {
                    state = AbilityState.ready;
                }
                break;
        }
    }
}
