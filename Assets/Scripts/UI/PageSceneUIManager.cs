using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

namespace CCG
{
    public class PageSceneUIManager : SingletonMonoBehaviour<PageSceneUIManager>
    {
        #region properties
        #endregion

        #region variables
        [SerializeField]
        private UIPageStatusBar statusBar;
        #endregion

        #region public methods
        public UIPageStatusBar GetStatusBar()
        {
            return statusBar;
        }
        #endregion
    }
}