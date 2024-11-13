using System.Collections.Generic;

namespace MultiplayerARPG
{
    public partial interface IPlayerCharacterData
    {
        bool IsKnockdown { get; set; }
        float NextKnockdownTime { get; set; }

    }
}