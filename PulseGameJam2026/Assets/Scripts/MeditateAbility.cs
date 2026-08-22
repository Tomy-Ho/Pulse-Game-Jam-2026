using UnityEngine;

[CreateAssetMenu]
public class MeditateAbility : Ability
{
    private int counter;
    public override void Activate(GameObject parent) {
        // Meditate can be used anytime, hold to meditate, fill "sanity" bar, lock player movement, play meditate animation
        SpriteRenderer sr = parent.GetComponent<SpriteRenderer>(); // FOR TESTING: CHANGE COLOR OF CIRCLE
        if(sr != null) sr.color = Color.blue;
        //TODO: SET PLAYER MOVEMENT TO 0 (CAN'T MOVE WHILE MEDITATING), PLAY MEDITATE ANIMATION
        
    }

    public override void AbilityLoop(GameObject parent) {
        counter++; //FOR TESTING
        Debug.Log("Counter: " + counter);
    }


    public override void BeginCooldown(GameObject parent) {
        //TODO: INSERT HERE: SET PLAYER MOVEMENT TO NORMAL SPEED, EXIT MEDITATE
        SpriteRenderer sr = parent.GetComponent<SpriteRenderer>();
        if (sr != null) sr.color = Color.white;

        Debug.Log("Final counter value: " + counter);
    }
}
