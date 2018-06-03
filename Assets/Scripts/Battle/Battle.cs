using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

namespace CCG
{
    public class Battle
    {
        /// <summary>
        /// コンストラクタ
        /// </summary>
        public Battle(Mimic mimic, Enemy enemy)
        {
            this.mimic = mimic;
            this.enemy = enemy;

            IsBattle = true;
            turn = 0;
        }

        #region enums
        public enum Side
        {
            Mimic,
            Enemy,
        }
        #endregion

        #region properties
        public bool IsBattle { get; private set; }

        private Mimic mimic { get; set; }
        private Enemy enemy { get; set; }

        private int turn { get; set; }
        #endregion

        #region public methods
        public static Battle Create(Mimic mimic, Enemy enemy)
        {
            return new Battle(mimic, enemy);
        }

        public void Next()
        {
            turn++;
            Debug.Log($"turn{turn} 開始.");

            Debug.Log("ミミックの攻撃！！");
            // ミミックの攻撃
            mimic.Attack(enemy);
            Debug.Log($"Mimic health: {mimic.health}, Enemy health: {enemy.health}.");
            if (enemy.health == 0)
            {
                enemy.Kill();

                OnEndBattle();
                return;
            }

            Debug.Log("敵の攻撃！！");
            // 敵の攻撃
            enemy.Attack(mimic);
            Debug.Log($"Mimic health: {mimic.health}, Enemy health: {enemy.health}.");
            if(mimic.health == 0)
            {
                mimic.Kill();

                OnEndBattle();
                return;
            }
        }
        #endregion

        #region private methods
        private void OnEndBattle()
        {
            IsBattle = false;
        }
        #endregion
    }
}