using UnityEngine;
using UnityEngine.Animations;
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
        GameObject normalPlayer = parent.transform.Find("PlayerVariant")?.gameObject;
        GameObject ghostPlayer = parent.transform.Find("GhostForm")?.gameObject;

        if (playerTag.Equals("Player"))
        {
            parent.tag = "GhostPlayer";
            playerSprite.color = Color.green;
            playerAttackScript.isGhost = true;
            if (normalPlayer)
            {
                normalPlayer.SetActive(false);

            }
            if (ghostPlayer)
            {
                ghostPlayer.SetActive(true);
            }
        }

        if (playerTag.Equals("GhostPlayer"))
        {
            parent.tag = "Player";
            playerSprite.color = Color.white;
            playerAttackScript.isGhost = false;
            if (normalPlayer)
            {
                normalPlayer.SetActive(true);
            }
            if (ghostPlayer)
            {
                ghostPlayer.SetActive(false);
            }
        }
    }

    void ActivateCorrectGameObject(GameObject parent)
    {
        
    }
}
