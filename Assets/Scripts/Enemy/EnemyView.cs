using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

namespace CCG
{
    public class EnemyView
    {
        public EnemyView(SpriteRenderer mainRenderer)
        {
            this.mainRenderer = mainRenderer;
        }

        #region properties
        private SpriteRenderer mainRenderer { get; set; }
        #endregion

        public void SetMaskInteraction(SpriteMaskInteraction interaction)
        {
            mainRenderer.maskInteraction = interaction;
        }
    }
}