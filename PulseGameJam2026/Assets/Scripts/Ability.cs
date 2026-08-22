using UnityEngine;

[CreateAssetMenu(fileName = "Ability", menuName = "Scriptable Objects/Ability")]
public class Ability : ScriptableObject
{
    public new string name;
    public float cooldownTime;

    public virtual void Activate(GameObject parent) {}
    public virtual void BeginCooldown(GameObject parent) {}
    public virtual void AbilityLoop(GameObject parent) {} // Only for HOLD Abilities
}
