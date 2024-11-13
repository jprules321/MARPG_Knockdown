using NUnit.Framework.Interfaces;
using UnityEngine;

namespace MultiplayerARPG
{
    [System.Serializable]
    public partial struct CharacterStats
    {
        [Tooltip("How long in seconds before you can be knocked down again after getting up")]
        public float knockdownCooldown;
        [Tooltip("How long in seconds you will be knocked down for")]
        public float knockdownDuration;
        [Tooltip("Chances of knocking down an opponent after landing a hit")]
        public float knockdownChance;
    }



}
