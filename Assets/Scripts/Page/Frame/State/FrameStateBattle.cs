using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

namespace CCG
{
    public class FrameStateBattle : FrameStateBase
    {
        #region variables
        private static readonly Frame.FrameType Type = Frame.FrameType.Battle;
        #endregion

        #region properties
        public override Frame.FrameType type { get { return FrameStateBattle.Type; } }
        #endregion

        #region public methods
        #endregion

        #region private methods
        protected override void OnStartTimer() { }
        protected override void OnEndTimer() { }
        #endregion
    }
}