using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

namespace CCG
{
    public class FrameStateHotel : FrameStateBase
    {
        #region variables
        private static readonly Frame.FrameType Type = Frame.FrameType.Hotel;
        #endregion

        #region properties
        public override Frame.FrameType type { get { return FrameStateHotel.Type; } }
        #endregion

        #region public methods
        /// <summary>
        /// コンストラクタ
        /// </summary>
        public FrameStateHotel()
        {
            timer = new Timer();

            OnInitialize();
        }

        protected override void OnInsertMimic()
        {
            StartTimer(1f, true, () =>
            {
                mimic.FullCure();
            });
        }
        #endregion

        #region private methods
        protected override void OnStartTimer() { }
        protected override void OnEndTimer() { }
        #endregion
    }
}