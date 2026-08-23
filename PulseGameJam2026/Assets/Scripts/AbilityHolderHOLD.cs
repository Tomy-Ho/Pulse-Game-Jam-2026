using UnityEngine;
using UnityEngine.InputSystem;

public class AbilityHolderHOLD : AbilityHolderBase
{
    // Update is called once per frame
    void Start(){
        playerMovement = player.GetComponent<PlayerMovement>();
    }
    protected override void Update(){
        switch(state) {
            case AbilityState.ready:
                if(Keyboard.current[key].wasPressedThisFrame && playerMovement.isGrounded){
                    ability.Activate(player);
                    state = AbilityState.active;  
                }
            break;

            case AbilityState.active:
                if (Keyboard.current[key].isPressed){
                    ability.AbilityLoop(player);
                }
                else{
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
