using UnityEngine;

namespace MultiplayerARPG
{
    public partial class UICharacterStats
    {
        [Header("Custom stats")]
        public UILocaleKeySetting formatKeyKnockdownChanceStats = new UILocaleKeySetting(UIFormatKeys.UI_FORMAT_SIMPLE_PERCENTAGE);

        public TextWrapper uiTextKnockdownChance;

        [DevExtMethods("SetStatsGenerateTextData")]
        public void SetStatsGenerateTextData_Knockdown(CharacterStatsTextGenerateData generateTextData)
        {
            generateTextData.knockdownChanceStatsFormat = formatKeyKnockdownChanceStats;
            generateTextData.uiTextKnockdownChance = uiTextKnockdownChance;
        }

    }

}
