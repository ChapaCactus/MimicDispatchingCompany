using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

namespace CCG
{
    public abstract class FrameStateBase : ScriptableObject
    {
        #region variables
        protected Timer timer { get; set; }
        #endregion

        #region properties
        public abstract Frame.FrameType type { get; }
        #endregion

        #region public methods
        public virtual void OnAwake()
        {
            OnInitialize();
        }

        public virtual void OnUpdate(float deltaTime)
        {
            timer.Update(deltaTime);
        }
        #endregion

        #region private methods
        protected virtual void OnInitialize()
        {
        }

        protected abstract void OnStartTimer();
        protected abstract void OnEndTimer();
        #endregion
    }
}