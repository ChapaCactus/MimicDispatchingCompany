using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

using UnityEngine.UI;

namespace CCG
{
    public class OnomatopoeiaText
    {
        #region properties
        private Text text { get; set; }
        #endregion

        #region public methods
        /// <summary>
        /// コンストラクタ
        /// </summary>
        public OnomatopoeiaText(Text text)
        {
            this.text = text;

            Assert.IsNotNull(this.text);
        }

        public void SetMessage(string message)
        {
            text.text = message;
        }

        public void SetPosition(Vector2 position)
        {
            text.transform.position = position;
        }

        public void SetLocalPosition(Vector2 localPosition)
        {
            text.transform.localPosition = localPosition;
        }

        public void SetParent(Transform parent, bool worldPositionStays)
        {
            text.transform.SetParent(parent, worldPositionStays);
        }
        #endregion

        #region private methods
        #endregion
    }
}