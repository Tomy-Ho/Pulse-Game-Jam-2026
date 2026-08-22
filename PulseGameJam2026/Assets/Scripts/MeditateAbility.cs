using UnityEngine;

[CreateAssetMenu]
public class MeditateAbility : Ability
{
    private int counter;
    private float normalSpeed;
    private PlayerMovement playerMovement;
    public override void Activate(GameObject parent) {
        // Meditate can be used anytime, hold to meditate, fill "sanity" bar, lock player movement, play meditate animation
        playerMovement = parent.GetComponent<PlayerMovement>();
        normalSpeed = playerMovement.speed;

        SpriteRenderer sr = parent.GetComponent<SpriteRenderer>(); // FOR TESTING: CHANGE COLOR OF CIRCLE
        if(sr != null) sr.color = Color.blue;
        //TODO: PLAY ANIMATION
    }

    public override void AbilityLoop(GameObject parent) {
        PlayerMovement playerMovement = parent.GetComponent<PlayerMovement>();
        playerMovement.speed = 0;

        //TODO: INCREASE SANITY + SANITY BAR

        // counter++; //FOR TESTING
        // Debug.Log("Counter: " + counter);
    }


    public override void BeginCooldown(GameObject parent) {
        PlayerMovement playerMovement = parent.GetComponent<PlayerMovement>();
        playerMovement.speed = normalSpeed;
        

        SpriteRenderer sr = parent.GetComponent<SpriteRenderer>();
        if (sr != null) sr.color = Color.white;

        Debug.Log("Final counter value: " + counter);
    }
}
