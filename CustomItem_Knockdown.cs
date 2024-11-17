using UnityEngine;

namespace MultiplayerARPG
{
    public partial class WeaponItem {
        [Category("Equipment Settings")]
        [Header("Knockdown Settings")]
        [SerializeField]
        private bool canKnockDown;
        public bool CanKnockdown { get { return canKnockDown; } set { canKnockDown = value; } }

    }

    public partial interface IWeaponItem { 
        public bool CanKnockdown { get; set; }
    }

    public partial class Item
    {
        [Category("Equipment Settings")]
        [Header("Knockdown Settings")]
        public bool canKnockdown;

        public bool CanKnockdown { get { return canKnockdown; } set { canKnockdown = value; } }

    }

    public partial struct CharacterItem
    {
        public bool CanKnockdown()
        {
            IWeaponItem item = GetWeaponItem();
            if (item == null)
                return false;
            return item.CanKnockdown;
        }
        

    }
}