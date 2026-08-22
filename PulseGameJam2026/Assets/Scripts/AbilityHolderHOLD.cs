using UnityEngine;
using UnityEngine.InputSystem;

public class AbilityHolderHOLD : MonoBehaviour
{
    public Ability ability;
    float cooldownTime;
    enum AbilityState
    {
        ready,
        active,
        cooldown
    }
    AbilityState state = AbilityState.ready;

    public Key key;

    // Update is called once per frame
    void Update(){
        switch(state) {
            case AbilityState.ready:
                if(Keyboard.current[key].wasPressedThisFrame){
                    ability.Activate(gameObject);
                    state = AbilityState.active;  
                }
            break;

            case AbilityState.active:
                if (Keyboard.current[key].isPressed){
                    ability.AbilityLoop(gameObject);
                }
                else{
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
