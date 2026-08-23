using UnityEngine;
using UnityEngine.InputSystem;

public class AbilityHolderPRESS : AbilityHolderBase
{
    
    protected override void Update(){
        switch(state) {
            case AbilityState.ready:
                if (Keyboard.current[key].wasPressedThisFrame){
                    ability.Activate(player);
                    activeTime = ability.activeTime;
                    state = AbilityState.active;
                    
                }
                break;
            case AbilityState.active:
                if(activeTime > 0){
                    activeTime -= Time.deltaTime;
                }
                else {
                    ability.BeginCooldown(player);
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
