using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

using System.Linq;

namespace CCG
{
    public class EnemySpawner
    {
        public EnemySpawner(List<Vector3> spawnPoints, float spawnSpan = 1)
        {
            isRunning = false;

            this.spawnPoints = spawnPoints;
            this.spawnSpan = spawnSpan;
        }

        #region properties
        public bool isRunning { get; private set; }

        public List<Vector3> spawnPoints { get; private set; } = new List<Vector3>();

        private float spawnTimer { get; set; }
        private float spawnSpan { get; set; }
        #endregion

        #region public methods
        public void Update()
        {
            if(isRunning)
            {
                spawnTimer -= Time.deltaTime;
                if(spawnTimer <= 0)
                {
                    GenerateEnemy();
                    ResetTimer();
                }
            }
        }

        public void Run()
        {
            if (isRunning)
                return;
            isRunning = true;

            ResetTimer();
        }

        public void Stop()
        {
            if (!isRunning)
                return;
            isRunning = false;
        }
        #endregion

        #region private methods
        private void ResetTimer()
        {
            spawnTimer = spawnSpan;
        }

        private void GenerateEnemy()
        {
            Debug.Log("敵生成");
        }
        #endregion
    }
}