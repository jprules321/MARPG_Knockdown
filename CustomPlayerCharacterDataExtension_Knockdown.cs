using LiteNetLib.Utils;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MultiplayerARPG
{
    public static partial class CharacterDataExtensions
    {
        [DevExtMethods("CloneTo")]
        static void CloneTo_Knockdown(IPlayerCharacterData from, IPlayerCharacterData to)
        {
            to.IsKnockdown = from.IsKnockdown;
            to.NextKnockdownTime = from.NextKnockdownTime;
        }

        [DevExtMethods("SerializeCharacterData")]
        public static void SerializeCharacterData_Knockdown(PlayerCharacterData characterData, NetDataWriter writer)
        {

            writer.Put(characterData.IsKnockdown);
            writer.Put(characterData.NextKnockdownTime);
          
        }


        [DevExtMethods("DeserializeCharacterData")]
        public static void DeserializeCharacterData_Knockdown(PlayerCharacterData characterData, NetDataReader reader)
        {

            characterData.IsKnockdown = reader.GetBool();
            characterData.NextKnockdownTime = reader.GetFloat();
          
        }
    }

}
