using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

using System.Collections;

namespace CCG
{
    public class BattleManager : SingletonMonoBehaviour<BattleManager>
    {
        #region properties
        public bool IsBattleRunning { get { return currentBattle != null; } }

        private Queue<Battle> battleQueue { get; set; }
        private Battle currentBattle { get; set; }
        #endregion

        #region unity callbacks
        private void Awake()
        {
            battleQueue = new Queue<Battle>();
        }

        private void Update()
        {
            // バトル中なら
            if (currentBattle != null)
                return;

            if(battleQueue.Count >= 1)
            {
                var battle = battleQueue.Dequeue();
                currentBattle = battle;
                StartCoroutine(BattleLoop());
            }
        }
        #endregion

        #region public methods
        public void AddBattleQueue(Battle battle)
        {
            battleQueue.Enqueue(battle);
        }
        #endregion

        #region private methods
        private IEnumerator BattleLoop()
        {
            var wait = new WaitForSeconds(1);
            while(currentBattle.IsBattle)
            {
                currentBattle.Next();

                yield return wait;
            }

            currentBattle = null;
        }
        #endregion
    }
}