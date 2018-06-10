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
        #endregion

        #region public methods
        public void SetDir(Frame.MimicDir dir)
        {
            var dirX = (dir == Frame.MimicDir.Right) ? 1 : -1;
            characterRenderer.transform.localScale = new Vector3(dirX, 1, 1);
        }

        public void SetMaskInteraction(SpriteMaskInteraction interaction)
        {
            if(characterRenderer != null)
            {
                characterRenderer.maskInteraction = interaction;
            }
        }

        public Tweener PlayIdleAnimation()
        {
            var tweener = characterRenderer.transform.DOMoveY(1, 0.5f)
                             .SetLoops(-1, LoopType.Yoyo)
                             .SetRelative(true);

            return tweener;
        }
        #endregion
    }
}