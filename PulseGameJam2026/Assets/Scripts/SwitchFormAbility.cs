using UnityEngine;
[CreateAssetMenu]

public class SwitchFormAbility : Ability
{

    SpriteRenderer playerSprite;
    string playerTag;
    PlayerAttack playerAttackScript;
    public override void Activate(GameObject parent)
    {
        playerSprite = parent.GetComponent<SpriteRenderer>();
        playerTag = parent.tag;
        playerAttackScript = parent.GetComponent<PlayerAttack>();
        if (playerTag.Equals("Player"))
        {
            parent.tag = "GhostPlayer";
            playerSprite.color = Color.green;
            playerAttackScript.isGhost = true;
        }

        if (playerTag.Equals("GhostPlayer"))
        {
            parent.tag = "Player";
            playerSprite.color = Color.white;
            playerAttackScript.isGhost = false;
        }
    }
}
