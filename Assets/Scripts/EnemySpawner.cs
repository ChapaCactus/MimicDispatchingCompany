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
            this.spawnPoints = spawnPoints.Select(transform => transform.position)
                .ToList();
            this.parent = parent;
        }

        #region properties
        private List<Vector3> spawnPoints { get; set; } = new List<Vector3>();
        private Frame parent { get; set; }
        #endregion

        #region public methods
        public void GenerateEnemy()
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

        #region private methods
        #endregion
    }
}