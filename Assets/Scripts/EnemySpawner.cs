using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

using System.Linq;

namespace CCG
{
    public class EnemySpawner
    {
        public EnemySpawner(Frame parent, List<Transform> spawnPoints)
        {
            isRunning = false;

            this.spawnPoints = spawnPoints.Select(transform => transform.position)
                .ToList();
            this.parent = parent;
        }

        #region properties
        public bool isRunning { get; private set; }

        private List<Vector3> spawnPoints { get; set; } = new List<Vector3>();
        private Frame parent { get; set; }

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

        public void Run(float spawnSpan = 3)
        {
            if (isRunning)
                return;
            isRunning = true;
            this.spawnSpan = spawnSpan;

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
            Vector3 spawnPos = spawnPoints.OrderBy(_ => Guid.NewGuid()).First();
            Enemy.Create(parent.transform, enemy =>
            {
                enemy.transform.position = spawnPos;
                var data = CharacterData.CreateEnemyDummyData();
                enemy.Setup(data, parent);
            });
        }
        #endregion
    }
}