using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

using UnityEngine.UI;

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
        }
        #endregion
    }
}