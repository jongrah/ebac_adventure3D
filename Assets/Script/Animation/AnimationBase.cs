using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Animation
{
    public enum AnimationType
    {
        NONE,
        IDLE,
        RUN,
        ATTACK,
        DEATH
    }

    public class AnimationBase : MonoBehaviour
    {
        public Animator animator;
        public List<AnimationSetup> animationsSetups;


        public void PlayAnimationByTrigger(AnimationType animationType)
        {
            var setup = animationsSetups.Find(i => i.animationType == animationType);
            if(setup != null)
            {
                animator.SetTrigger(setup.trigger);
            }
        }
    }


    [System.Serializable]
    public class AnimationSetup
    {
        public AnimationType animationType;
        public string trigger;
    }

}