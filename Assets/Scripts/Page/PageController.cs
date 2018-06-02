using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

namespace CCG
{
    public class PageController : MonoBehaviour
    {
        #region properties
        private Page page { get; set; }
        #endregion

        #region public methods
        public void Setup(Page page)
        {
            this.page = page;
        }
        #endregion
    }
}