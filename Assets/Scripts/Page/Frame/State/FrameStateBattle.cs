﻿using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

namespace CCG
{
    public class FrameStateBattle : FrameStateBase
    {
        #region variables
        private static readonly Frame.FrameType Type = Frame.FrameType.Battle;
        #endregion

        #region properties
        public override Frame.FrameType type { get { return FrameStateBattle.Type; } }

        private EnemySpawner enemySpawner { get; set; }
        private Frame frame { get; set; }
        #endregion

        #region public methods
        /// <summary>
        /// コンストラクタ
        /// </summary>
        public FrameStateBattle(Frame frame, List<Transform> spawnPoints)
        {
            enemySpawner = new EnemySpawner(frame, spawnPoints);
        }

        public override void OnInsertMimic(Mimic mimic)
        {
            enemySpawner.Run();
        }
        #endregion

        #region private methods
        protected override void OnInitialize()
        {
            base.OnInitialize();
        }

        protected override void OnStartTimer() { }
        protected override void OnEndTimer() { }
        #endregion
    }
}