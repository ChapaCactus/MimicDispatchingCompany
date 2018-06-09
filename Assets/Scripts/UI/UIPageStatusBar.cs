using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

using UnityEngine.UI;
using DG.Tweening;

namespace CCG
{
    public class UIPageStatusBar : MonoBehaviour
    {
        #region variables
        [SerializeField]
        private Text goldText;
        #endregion

        #region public methods
        public void UpdateGoldText(int gold)
        {
            goldText.text = $"{gold}G";

            goldText.transform.localScale = Vector3.one;
            goldText.transform.DOScale(1.5f, 0.3f)
                    .SetEase(Ease.OutExpo)
                    .SetLoops(2, LoopType.Yoyo);
        }
        #endregion
    }
}