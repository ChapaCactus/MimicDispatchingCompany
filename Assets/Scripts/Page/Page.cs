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
        public Page(IEnumerable<Frame> frames)
        {
            this.frames = frames;
        }

        #region properties
        public IEnumerable<Frame> frames { get; private set; }
        #endregion
    }
}