using Cysharp.Text;
using System.Text;
using static UnityEngine.Rendering.DebugUI;

namespace MultiplayerARPG
{
    public partial class CharacterStatsTextGenerateData
    {
        public string knockdownChanceStatsFormat;
        public TextWrapper uiTextKnockdownChance;

         [DevExtMethods("GetText")]
        public void GetText_Kockdown(StringBuilder statsString)
        {
            // Determine the correct format string based on whether the stat is a rate
            string numberFormat = numberFormatRate;

            // Calculate the value to display, adjusting for rates if necessary
            string tempValue = (data.knockdownChance * 100).ToString(numberFormat);

            // Construct the display string
            string statsStringPart = ZString.Concat(isBonus ? "+" : string.Empty, ZString.Format(
                LanguageManager.GetText(knockdownChanceStatsFormat),
                tempValue));

            // Append the stat text to the builder if the value is not zero
            if (data.knockdownChance != 0)
            {
                if (statsString.Length > 0)
                    statsString.Append('\n');
                statsString.Append(statsStringPart);
            }

            // Set the text component if it's provided
            if (uiTextKnockdownChance != null)
                uiTextKnockdownChance.text = statsStringPart;
        }
    }
}
