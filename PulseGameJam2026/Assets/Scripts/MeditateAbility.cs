using UnityEngine;

[CreateAssetMenu]
public class MeditateAbility : Ability
{
    private int counter;
    private float normalSpeed;
    private PlayerMovement playerMovement;
    private HealthManager playerHealth;
    private PlayerAttack playerAttack;
    private Animator playerAnim;
    public int healthRegen;
    public override void Activate(GameObject parent) {
        // Meditate can be used anytime, hold to meditate, fill "sanity" bar, lock player movement, play meditate animation
        playerMovement = parent.GetComponent<PlayerMovement>();
        playerAttack = parent.GetComponent<PlayerAttack>();
        playerAnim = parent.GetComponentInChildren<Animator>();
        normalSpeed = 4;    

        SpriteRenderer sr = parent.GetComponent<SpriteRenderer>(); // FOR TESTING: CHANGE COLOR OF CIRCLE
        if(sr != null) sr.color = Color.blue;
        //TODO: PLAY ANIMATION

        if (parent.tag.Equals("GhostPlayer"))
        {
            parent.tag = "Player";
            parent.GetComponent<PlayerAttack>().isGhost = false;
        }
    }

    public override void AbilityLoop(GameObject parent) {
        playerMovement.speed = 0;
        playerMovement.canJump = false;
        playerAttack.canAttack = false;
        //TODO: INCREASE SANITY + SANITY BAR
        playerHealth = parent.GetComponent<HealthManager>();
        playerAnim.SetTrigger("isMeditating");

        if(playerHealth.currentHealth <= playerHealth.maxHealth - healthRegen){
            playerHealth.currentHealth += healthRegen;  
            playerHealth.healthBar.SetCurrentHealth(playerHealth.currentHealth);    
        }   

        // counter++; //FOR TESTING
        // Debug.Log("Counter: " + counter);
    }


    public override void BeginCooldown(GameObject parent) {
        playerMovement.speed = normalSpeed;
        playerMovement.canJump = true;
        playerAttack.canAttack = true;
        
        SpriteRenderer sr = parent.GetComponent<SpriteRenderer>();
        playerAnim.SetBool("isMeditating", false);
        if (sr != null) sr.color = Color.white;

        Debug.Log("Final counter value: " + counter);
    }
}
