using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

using DG.Tweening;

namespace CCG
{
    public class MimicView
    {
        public MimicView(SpriteRenderer characterRenderer)
        {
            this.characterRenderer = characterRenderer;
        }

        #region properties
        private SpriteRenderer characterRenderer { get; set; }
        private ParticleSystem sleepParticle { get; set; }
        #endregion

        #region public methods
        public void SetDir(Frame.MimicDir dir)
        {
            var dirX = (dir == Frame.MimicDir.Right) ? 1 : -1;
            characterRenderer.transform.localScale = new Vector3(dirX, 1, 1);
        }

        public void SetMaskInteraction(SpriteMaskInteraction interaction)
        {
            if (characterRenderer != null)
            {
                characterRenderer.maskInteraction = interaction;
            }
        }

        public Tweener PlayIdleAnimation()
        {
            var tweener = characterRenderer.transform.DOMoveX(0.02f, 0.4f)
                                           .SetLoops(-1, LoopType.Yoyo)
                                           .SetEase(Ease.InOutExpo)
                                           .SetRelative(true);

            return tweener;
        }

        public void PlaySleepAnimation()
        {
            if (sleepParticle == null)
            {
                var effectPrefab = Resources.Load("Prefabs/Effect/Zzz") as GameObject;
                sleepParticle = GameObject.Instantiate(effectPrefab, characterRenderer.transform)
                                          .GetComponent<ParticleSystem>();
            }

            sleepParticle.gameObject.transform.position = characterRenderer.transform.position;
            sleepParticle.Play(true);
        }
        #endregion
    }
}