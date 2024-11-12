using UnityEngine;

namespace MultiplayerARPG
{
    public partial class DefaultGameplayRule
    {

        [Header("Knockdown")]
        public float baseKnockdownChance = 0.01f;

        public override float GetKnockdownChance(BaseCharacterEntity attacker)
        {
            CharacterStats attackerStats = attacker.GetCaches().Stats;
            float knockdownChance = baseKnockdownChance + attackerStats.knockdownChance;
            // Minimum knockdown chance is 1%
            if (knockdownChance < 0.01f)
                knockdownChance = 0.01f;
            // Maximum knockdown chance is 30%
            if (knockdownChance > 0.30f)
                knockdownChance = 0.30f;
            return knockdownChance;
        }


    }

    public abstract partial class BaseGameplayRule
    {

        public abstract float GetKnockdownChance(BaseCharacterEntity attacker);

    }

}
