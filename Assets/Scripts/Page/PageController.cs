using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

using System.Linq;

namespace CCG
{
    public class PageController : SingletonMonoBehaviour<PageController>
    {
        #region properties
        private Page page { get; set; }
        #endregion

        #region unity callbacks
        private void Awake()
        {
            page = new Page();
            page.frames = FindFrames();
        }
        #endregion

        #region public methods
        #endregion

        #region private methods
        /// <summary>
        /// シーン内のフレームを全て取得する
        /// </summary>
        private List<Frame> FindFrames()
        {
            return GameObject.FindGameObjectsWithTag("Frame")
                             .Select(go => go.GetComponent<Frame>())
                             .ToList();
        }
        #endregion
    }
}