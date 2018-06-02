using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

namespace CCG
{
    public class PageSceneUIManager : SingletonMonoBehaviour<PageSceneUIManager>
    {
        #region variables
        [SerializeField]
        private UIPageStatusBar statusBar;
        #endregion
    }
}