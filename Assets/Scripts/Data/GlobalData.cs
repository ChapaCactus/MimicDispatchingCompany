using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

namespace CCG
{
    public static class GlobalData
    {
        #region properties
        public static int totalGold { get; private set; }
        public static int currentGold { get; private set; }
        #endregion

        #region public methods
        public static void AddGold(int add)
        {
            totalGold += add;
            currentGold += add;
        }
        #endregion
    }
}