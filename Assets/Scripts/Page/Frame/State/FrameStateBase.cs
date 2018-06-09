using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

namespace CCG
{
    public abstract class FrameStateBase : ScriptableObject
    {
        #region properties
        public abstract Frame.FrameType type { get; }

        protected Timer timer { get; set; }
        protected Mimic mimic { get; set; }
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

        public void InsertMimic(Mimic mimic)
        {
            this.mimic = mimic;

            OnInsertMimic();
        }
        #endregion

        #region private methods
        protected abstract void OnInsertMimic();

        protected void StartTimer(float start, bool isLoop, Action onEndTimer)
        {
            timer.StartTimer(start, isLoop, onEndTimer);
        }

        protected virtual void OnInitialize()
        {
        }

        protected abstract void OnStartTimer();
        protected abstract void OnEndTimer();
        #endregion
    }
}