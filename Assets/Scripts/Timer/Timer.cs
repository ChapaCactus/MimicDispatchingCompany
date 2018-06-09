using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

namespace CCG
{
    public class Timer
    {
        #region variables
        public bool isRunning { get; private set; }

        private float timer { get; set; }
        private float duration { get; set; }
        private bool isLoop { get; set; }
        private Action onEndTimer { get; set; }
        #endregion

        #region public methods
        public void StartTimer(float duration, bool isLoop, Action onEndTimer)
        {
            this.duration = duration;
            this.timer = duration;
            this.isLoop = isLoop;
            this.onEndTimer = onEndTimer;
            this.isRunning = true;
        }

        public void Update(float deltaTime)
        {
            if (!isRunning) return;

            timer -= deltaTime;
            if (timer <= 0)
            {
                Debug.Log("onEndTimer");
                onEndTimer.SafeCall();

                if (isLoop)
                {
                    StartTimer(duration, isLoop, onEndTimer);
                }
                else
                {
                    isRunning = false;
                }
            }
        }
        #endregion
    }
}