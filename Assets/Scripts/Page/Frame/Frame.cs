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

        public enum MimicDir
        {
            Right,
            Left,
        }
        #endregion

        #region variables
        [SerializeField]
        private FrameType currentStateType = FrameType.Battle;

        [SerializeField]
        private MimicDir mimicDir = MimicDir.Right;

        [SerializeField]
        private Transform mimicPos;
        #endregion

        #region properties
        private Mimic mimic { get; set; }

        private Dictionary<Frame.FrameType, FrameStateBase> states { get; set; }
        private FrameStateBase currentState { get { return states[currentStateType]; } }
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

            states = new Dictionary<FrameType, FrameStateBase>();
            states.Add(FrameType.Battle
                       , new FrameStateBattle(this, spawnPoints));
            states.Add(FrameType.Hotel, new FrameStateHotel());
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
            mimic.transform.position = mimicPos.position;
            mimic.transform.SetParent(transform);

            Debug.Log($"mimic name: {mimic.charaName}");

            currentState.InsertMimic(mimic);
            mimic.OnFrameIn(mimicDir);
        }
        #endregion

        #region private methods
        #endregion
    }
}