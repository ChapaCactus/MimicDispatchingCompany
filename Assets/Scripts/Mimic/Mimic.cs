using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

using DG.Tweening;
using HedgehogTeam.EasyTouch;

namespace CCG
{
    [RequireComponent(typeof(QuickDrag))]
    public class Mimic : MonoBehaviour
    {
        #region enums
        public enum State
        {
            OnDrag,
            FrameIn,
            Invoked,
        }
        #endregion

        #region variables
        [SerializeField]
        private SpriteRenderer characterRenderer;
        #endregion

        #region properties
        public string charaName { get { return data.name.charaName; } }
        public string title { get { return data.name.title; } }
        public int level { get { return data.level.level; } }
        public int exp { get { return data.level.exp; } }
        public int next { get { return data.level.next; } }
        public int health { get { return data.health.health; } }
        public int maxHealth { get { return data.health.maxHealth; } }
        public int power { get { return data.power.GetTotalPower(); } }
        public int defense { get { return data.defense.GetTotalDefense(); } }

        public State state { get; private set; }

        private CharacterData data { get; set; }
        private MimicView view { get; set; }

        private Action onDead { get; set; }
        #endregion

        #region variables
        #endregion

        #region unity callbacks
        private void Awake()
        {
            var dummyData = CharacterData.CreateDummyData();
            Setup(dummyData);
        }
        #endregion

        #region public methods
        public void Setup(CharacterData data)
        {
            this.data = data;

            view = new MimicView(characterRenderer);
            view.SetMaskInteraction(SpriteMaskInteraction.VisibleOutsideMask);

            EasyTouch.On_DragStart += OnDragStart;
            EasyTouch.On_Drag += OnDrag;
            EasyTouch.On_DragEnd += OnDragEnd;
        }

        public void SetOnDeadCallback(Action onDead)
        {
            this.onDead = onDead;
        }

        /// <summary>
        /// フレームに入ったとき
        /// </summary>
        public void OnFrameIn()
        {
            state = State.FrameIn;

            view.SetMaskInteraction(SpriteMaskInteraction.VisibleInsideMask);
        }

        /// <summary>
        /// 起動
        /// </summary>
        public void Invoke()
        {
            state = State.Invoked;

            view.SetMaskInteraction(SpriteMaskInteraction.VisibleInsideMask);
            view.PlayIdleAnimation();
        }

        /// <summary>
        /// ダメージ
        /// </summary>
        public void Damage(int damage)
        {
            if (data == null)
                return;

            data.health.Damage(damage);

            if (data.health.IsDead)
                onDead();
        }

        /// <summary>
        /// 回復
        /// </summary>
        public void Cure(int cure)
        {
            if (data == null)
                return;

            data.health.Cure(cure);
        }

        /// <summary>
        /// 全回復
        /// </summary>
        public void FullCure()
        {
            if (data == null)
                return;

            data.health.FullCure();
        }
        #endregion

        #region private methods
        private void OnDestroy()
        {
            EasyTouch.On_DragStart -= OnDragStart;
            EasyTouch.On_Drag -= OnDrag;
            EasyTouch.On_DragEnd -= OnDragEnd;
        }

        private void OnDragStart(Gesture gesture)
        {
            Debug.Log("OnDragStart");
        }

        private void OnDrag(Gesture gesture)
        {
        }

        private void OnDragEnd(Gesture gesture)
        {
            Debug.Log("OnDragEnd");

            IInsertable insertable = CheckIsPutSuccess(gesture);
            insertable?.InsertMimic(this);
        }

        private IInsertable CheckIsPutSuccess(Gesture gesture)
        {
            Vector2 worldPoint = Camera.main.ScreenToWorldPoint(gesture.position);
            LayerMask mask = LayerMask.GetMask("IInsertable");
            RaycastHit2D hit = Physics2D.Raycast(worldPoint, Vector2.zero, Mathf.Infinity, mask);

            if (!hit.collider)
                return null;

            return hit.collider.GetComponent<IInsertable>();
        }
        #endregion
    }
}