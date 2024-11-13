using UnityEngine;

namespace MultiplayerARPG.GameData.Model.Playables
{
    public partial class PlayableCharacterModel
    {
        [Header("Knockdown Animations")]
        [Tooltip("Knockdown Custom Animations")]
        public ActionState knockdownAnimation;

        public void PlayKnockdownAnimation(bool loop)
        {
            if (_isDoingAction)
                return;
            _latestCustomAnimationActionId = OFFSET_FOR_CUSTOM_ANIMATION_ACTION_ID + 2593;
            Behaviour.PlayAction(knockdownAnimation, 1f, 0f, loop, _latestCustomAnimationActionId);
        }


    }

}

