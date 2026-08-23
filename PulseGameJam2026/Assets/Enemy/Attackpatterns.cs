using UnityEngine;

public class Attackpatterns : MonoBehaviour
{
    public enum AttackPattern
    {
        FlatAttack,
        FrontAttack,
        BigAreaAttack,
        LaserAttack
    }

    public class AttackPatternInfo
    {
        public AttackPattern pattern;
        public float[] parameters;
        public float timeToAttack;

        public AttackPatternInfo(AttackPattern pattern)
        {
            switch (pattern)
            {
                case AttackPattern.FlatAttack:
                    parameters = new float[] { 0f, 0.5f, 5f, 1f }; // Flat area attack
                    timeToAttack = 2;
                    break;
                case AttackPattern.FrontAttack:
                    parameters = new float[] { 1f, 0f, 1f, 1.5f }; // Front attack
                    timeToAttack = 1;
                    break;
                case AttackPattern.BigAreaAttack:
                    parameters = new float[] { 0f, -2f, 6f, 6f }; // Big area attack
                    timeToAttack = 4;
                    break;
                case AttackPattern.LaserAttack:
                    parameters = new float[] { 5f, 0f, 10f, 0.5f }; // Laser attack
                    timeToAttack = 2;
                    break;
            }
        }
    }
}
