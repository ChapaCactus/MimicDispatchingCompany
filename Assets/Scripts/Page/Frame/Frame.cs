using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

using System.Linq;

namespace CCG
{
    public class Frame : MonoBehaviour, IInsertable
    {
        #region enums
        public enum FrameType
        {
            Battle,
        }
        #endregion

        #region properties
        private Mimic mimic { get; set; }
        private IFrameState state { get; set; }
        private EnemySpawner enemySpawner { get; set; }
        #endregion

        #region variables
        [SerializeField]
        private List<Transform> spawnPoints = new List<Transform>();
        #endregion

        #region unity callbacks
        private void Awake()
        {
            Assert.IsNotNull(spawnPoints);

            var vectorPoints = spawnPoints.Select(tf => tf.position).ToList();
            enemySpawner = new EnemySpawner(vectorPoints);
        }

        private void Update()
        {
            enemySpawner.Update();
        }
        #endregion

        #region public methods
        /// <summary>
        /// ミミック挿入
        /// </summary>
        public void InsertMimic(Mimic mimic)
        {
            if (mimic == null)
                return;

            this.mimic = mimic;
            this.mimic.transform.position = transform.position;
            this.mimic.transform.SetParent(transform);

            Debug.Log($"mimic name: {mimic.charaName}");

            mimic.Invoke();
            enemySpawner.Run();
        }
        #endregion

        #region private methods
        #endregion
    }
}