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
        private Action onEndTimer { get; set; }
        #endregion

        #region public methods
        public void StartTimer(float start)
        {
            timer = start;
            isRunning = true;
        }

        public void Update(float deltaTime)
        {
            if (!isRunning) return;

            timer -= deltaTime;
            if (timer <= 0)
            {
                isRunning = false;
                onEndTimer.SafeCall();
            }
        }
        #endregion
    }
}