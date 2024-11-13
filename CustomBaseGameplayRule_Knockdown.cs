using UnityEngine;

namespace MultiplayerARPG
{
    public partial class DefaultGameplayRule
    {
        [Header("Knockdown Rules")]
        [Tooltip("Maximum knockdown chance after landing a hit. 0.1 = 10%")]
        [Range(0f, 1f)]
        public float maxKnockdownChance = 1f;
        [Tooltip("Minimum Knockdown Duration that will take effect even if stat is lower.")]
        public float minKnockdownDurationInSeconds = 1;
        [Tooltip("Maximum Knockdown Duration that will take effect even if stat is higher.")]
        public float maxKnockdownDurationInSeconds = 10;
        [Tooltip("Minimum time before someone can be knocked again even if stat is lower")]
        public float minKnockdownCooldownInSeconds = 1;

        public override float GetKnockdownChance(BaseCharacterEntity attacker)
        {
            CharacterStats attackerStats = attacker.GetCaches().Stats;
            float knockdownChance = attackerStats.knockdownChance;
            // Minimum knockdown chance is 1%
            if (knockdownChance < 0.01f)
                knockdownChance = 0.01f;
            // Maximum knockdown chance is 30%
            if (knockdownChance > maxKnockdownChance)
                knockdownChance = maxKnockdownChance;
            return knockdownChance;
        }

        public override float GetKnockdownCooldown(BaseCharacterEntity attackedEntity)
        {
            CharacterStats attackedStats = attackedEntity.GetCaches().Stats;
            float _knockdownCooldown = attackedStats.knockdownCooldown;
            if (_knockdownCooldown < minKnockdownCooldownInSeconds)
                _knockdownCooldown = minKnockdownCooldownInSeconds;
            return _knockdownCooldown;
        }

        public override float GetKnockdownDuration(BaseCharacterEntity attackedEntity)
        {
            CharacterStats attackedStats = attackedEntity.GetCaches().Stats;
            float _knockdownDuration = attackedStats.knockdownDuration;
            if (_knockdownDuration < minKnockdownDurationInSeconds)
                _knockdownDuration = minKnockdownDurationInSeconds;

            if (_knockdownDuration > maxKnockdownDurationInSeconds)
                _knockdownDuration = maxKnockdownDurationInSeconds;
            return _knockdownDuration;
        }


    }

    public abstract partial class BaseGameplayRule
    {

        public abstract float GetKnockdownChance(BaseCharacterEntity attacker);
        public abstract float GetKnockdownDuration(BaseCharacterEntity attackedEntity);
        public abstract float GetKnockdownCooldown(BaseCharacterEntity attackedEntity);

    }

}
