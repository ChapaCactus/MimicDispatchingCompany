using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Assertions;

namespace CCG
{
    public class Page
    {
        /// <summary>
        /// コンストラクタ
        /// </summary>
        public Page()
        {
            Init();
        }

        #region properties
        public List<Frame> frames { get; set; }
        #endregion

        #region public methods
        public void Init()
        {
            frames = new List<Frame>();
        }
        #endregion
    }
}