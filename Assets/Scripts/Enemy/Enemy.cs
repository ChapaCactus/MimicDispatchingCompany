using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

using DarkTonic.MasterAudio;

namespace CCG
{
    public class Enemy : MonoBehaviour, IBattle
    {
        #region properties
        public int health { get { return data.health.health; } }

        private CharacterData data { get; set; }
        private EnemyView view { get; set; }

        private Frame parentFrame { get; set; }
        private Mimic target { get; set; }

        private float moveRad { get; set; }
        #endregion

        #region variables
        [SerializeField]
        private SpriteRenderer mainRenderer;
        #endregion

        #region unity callbacks
        private void Update()
        {
            if (target != null && !BattleManager.I.IsBattleRunning)
            {
                Walk();
            }
        }
        #endregion

        #region public methods
        public static void Create(Transform parent, Action<Enemy> onCreate)
        {
            var prefab = Resources.Load("Prefabs/Enemy/Enemy") as GameObject;
            var enemy = Instantiate(prefab, parent).GetComponent<Enemy>();

            onCreate(enemy);
        }

        public void Setup(CharacterData data, Frame parentFrame)
        {
            this.data = data;

            view = new EnemyView(mainRenderer);
            view.SetMaskInteraction(SpriteMaskInteraction.VisibleInsideMask);

            this.parentFrame = parentFrame;
            target = parentFrame.GetMimic();
            moveRad = Mathf.Atan2(
                target.transform.position.y - transform.position.y,
                target.transform.position.x - transform.position.x);
        }

        /// <summary>
        /// 攻撃
        /// </summary>
        public void Attack(IBattle target)
        {
            target.Damage(1);
        }

        /// <summary>
        /// ダメージ
        /// </summary>
        public void Damage(int damage)
        {
            data.health.Damage(damage);
            MasterAudio.PlaySound("GB_01_sfx");
        }

        public void Kill()
        {
            var goldSetting = new GoldObjectSetting();
            goldSetting.gold = 1;
            goldSetting.autoGetTimer = 3;

            GoldObject.Create(parentFrame.transform, goldSetting, goldObject =>
            {
                goldObject.transform.position = transform.position;
                Destroy(gameObject);
            });
        }
        #endregion

        #region private methods
        private void Walk()
        {
            var moveSpeed = 4;
            var pos = transform.position;
            pos.x += moveSpeed * Mathf.Cos(moveRad);
            pos.y += moveSpeed * Mathf.Sin(moveRad);
            transform.position = pos;
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.CompareTag("Mimic"))
            {
                OnCollisionMimic(target);
            }
        }

        private void OnCollisionMimic(Mimic mimic)
        {
            Debug.Log("Start Battle...");
            Battle battle = Battle.Create(mimic, this);
            BattleManager.I.AddBattleQueue(battle);
        }
        #endregion
    }
}