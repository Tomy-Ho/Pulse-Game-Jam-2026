using UnityEngine;

[CreateAssetMenu]
public class DashAbility : Ability
{
    private PlayerMovement playerMovement;
    private EnemyAttack enemyAttack;
    private float normalSpeed;
    public float dashSpeed;
    public override void Activate(GameObject parent){
        playerMovement = parent.GetComponent<PlayerMovement>();
        enemyAttack = parent.GetComponent<EnemyAttack>();

        normalSpeed = playerMovement.speed;
        playerMovement.speed = dashSpeed;
        
    }

    public override void BeginCooldown(GameObject parent){
        playerMovement.speed = normalSpeed;    
        playerMovement.canMove = true;
       
    }

    public override void AbilityLoop(GameObject parent)
    {
        
    }

}
