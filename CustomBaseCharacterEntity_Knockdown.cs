using LiteNetLib;
using LiteNetLibManager;
using MultiplayerARPG.GameData.Model.Playables;
using System.Collections;
using UnityEngine;


namespace MultiplayerARPG
{
    public partial class BaseCharacterEntity
    {
        [Category("Sync Fields")]
        [SerializeField]
        protected SyncFieldBool isKnockdown = new SyncFieldBool();


        public event System.Action<bool> OnIsKnockdownChange;
        public bool IsKnockdown { get { return isKnockdown.Value; } set { isKnockdown.Value = value; } }

        protected PlayableCharacterModel PlayableCharacterModel => Model as PlayableCharacterModel;


        [DevExtMethods("Awake")]
        protected void CustomKnockdownAwake()
        {
            isKnockdown.onChange += IsKnockdownChange;
            onSetupNetElements += SetupKnockdownSyncFields;
            onReceivedDamage += OnReceivedDamageKnockdown;
            onDead.AddListener(OnDeadKnockdown);
            onCanMoveValidated += CustomKnockdownCanMoveValidated;
        }

        [DevExtMethods("OnDestroy")]
        protected void CustomKnockdownDestroy()
        {
            onDead.RemoveListener(OnDeadKnockdown);
        }

        private void CustomKnockdownCanMoveValidated(ref bool canMove)
        {
            if (IsKnockdown)
                canMove = false;
        }

        private void IsKnockdownChange(bool initial, bool value)
        {
            if (value)
            {
                StartCoroutine(KnockdownCoroutine());
            }
            OnIsKnockdownChange?.Invoke(value);
        }

        private void SetupKnockdownSyncFields()
        {
            isKnockdown.deliveryMethod = DeliveryMethod.ReliableOrdered;
            isKnockdown.syncMode = LiteNetLibSyncField.SyncMode.ServerToClients;

        }

        private void OnDeadKnockdown()
        {
            if (!IsServer)
                return;
            IsKnockdown = false;
        }

        private void OnReceivedDamageKnockdown(HitBoxPosition position,
        Vector3 fromPosition,
        IGameEntity attacker,
        CombatAmountType combatAmountType,
        int totalDamage,
        CharacterItem weapon,
        BaseSkill skill,
        int skillLevel,
        CharacterBuff buff,
        bool isDamageOverTime)
        {
            if (!IsServer)
                return;

            if (IsRecaching)
                return;

            if (IsKnockdown)
                return;
            if (attacker is not BaseCharacterEntity _attacker)
                return;

            IsKnockdown = Random.value <= CurrentGameplayRule.GetKnockdownChance(_attacker);
            
        }

        IEnumerator KnockdownCoroutine()
        {
            PlayableCharacterModel.StopActionAnimation();
            PlayableCharacterModel.StopCustomAnimation();
            StopMove();
            AttackComponent.CancelAttack();
            UseSkillComponent.CancelSkill();
            UseSkillComponent.InterruptCastingSkill();
            PlayableCharacterModel.PlayKnockdownAnimation(true);
            yield return new WaitForSeconds(5);
            StopCustomAnimation();
            IsKnockdown = false;
        }

  
    }

 }
