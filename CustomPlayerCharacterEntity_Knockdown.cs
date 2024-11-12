using UnityEngine;


namespace MultiplayerARPG
{
    public partial class PlayerCharacterEntity
    {

        public override bool CanAttack()
        {
            if (IsKnockdown)
                return false;
            return base.CanAttack();
        }

        public override bool CanDoActions()
        {
            if (isKnockdown)
                return false;
            return base.CanDoActions();
        }


    }

    public partial class MonsterCharacterEntity
    {

        public override bool CanAttack()
        {
            if (IsKnockdown)
                return false;
            return base.CanAttack();
        }

        public override bool CanDoActions()
        {
            if (isKnockdown)
                return false;
            return base.CanDoActions();
        }


    }

}
