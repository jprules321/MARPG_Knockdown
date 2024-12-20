using System;

namespace MultiplayerARPG
{
    public static partial class GameExtensionInstance
    {

        [DevExtMethods("Init")]
        static void InitGameExtensionInstance_Knockdown()
        {
            onAddCharacterStats += OnAddCharacterStats_Knockdown;
            onMultiplyCharacterStatsWithNumber += OnMultiplyCharacterStatsWithNumber_Knockdown;
            onMultiplyCharacterStats += OnMultiplyCharacterStats_Knockdown;
        }

        private static void OnMultiplyCharacterStats_Knockdown(ref CharacterStats a, CharacterStats b)
        {
            a.knockdownChance = a.knockdownChance * b.knockdownChance;
            a.knockdownCooldown = a.knockdownCooldown * b.knockdownCooldown;
            a.knockdownDuration = a.knockdownDuration * b.knockdownDuration;
        }

        private static void OnMultiplyCharacterStatsWithNumber_Knockdown(ref CharacterStats a, float b)
        {
            a.knockdownChance = a.knockdownChance * b;
            a.knockdownCooldown = a.knockdownCooldown * b;
            a.knockdownDuration = a.knockdownDuration * b;
        }

        private static void OnAddCharacterStats_Knockdown(ref CharacterStats a, CharacterStats b)
        {
            a.knockdownChance = a.knockdownChance + b.knockdownChance;
            a.knockdownCooldown = a.knockdownCooldown + b.knockdownCooldown;
            a.knockdownDuration = a.knockdownDuration + b.knockdownDuration;
        }


    }
}
