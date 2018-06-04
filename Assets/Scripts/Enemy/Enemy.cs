using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

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
        }

        public void Kill()
        {
            var goldSetting = new GoldObjectSetting();
            goldSetting.gold = 1;
            goldSetting.autoGetTimer = 3;

            GoldObject.Create(parentFrame.transform, goldSetting, goldObject =>
            {
            });

            Destroy(gameObject);
        }
        #endregion

        #region private methods
        private void Walk()
        {
            transform.position += Vector3.up;
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