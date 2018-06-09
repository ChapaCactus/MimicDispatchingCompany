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
            Hotel,
        }
        #endregion

        #region properties
        private Mimic mimic { get; set; }

        private List<FrameStateBase> state { get; set; }
        private int currentStateIndex { get; set; }
        private FrameStateBase currentState { get { return state[currentStateIndex]; } }

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
            enemySpawner = new EnemySpawner(vectorPoints, this);

            state = new List<FrameStateBase>();
            state.Add(new FrameStateBattle());
            state.Add(new FrameStateHotel());
        }

        private void Update()
        {
            currentState.OnUpdate(Time.deltaTime);
        }
        #endregion

        #region public methods
        public Mimic GetMimic()
        {
            return mimic;
        }

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