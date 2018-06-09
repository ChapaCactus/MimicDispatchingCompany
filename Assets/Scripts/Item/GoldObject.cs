using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

using HedgehogTeam.EasyTouch;
using DG.Tweening;
using DarkTonic.MasterAudio;

namespace CCG
{
    public class GoldObject : MonoBehaviour
    {
        #region variables
        [SerializeField]
        private SpriteRenderer spriteRenderer;
        #endregion

        #region properties
        public int gold { get; private set; }

        private float autoGetTimer { get; set; }
        #endregion

        #region unity callback
        private void Update()
        {
            if (autoGetTimer > 0)
            {
                autoGetTimer -= Time.deltaTime;
                if (autoGetTimer <= 0)
                {
                    AddGold();
                }
            }
        }

        private void OnEnable()
        {
            EasyTouch.On_SimpleTap += OnTap;
        }

        private void OnDisable()
        {
            UnsubscribeEvent();
        }

        private void OnDestroy()
        {
            UnsubscribeEvent();
        }
        #endregion

        #region public methods
        public static void Create(Transform parent, GoldObjectSetting setting, Action<GoldObject> onCreate)
        {
            var prefab = Resources.Load("Prefabs/Item/GoldObject") as GameObject;
            var goldObject = Instantiate(prefab, parent).GetComponent<GoldObject>();

            goldObject.Setup(setting.gold, setting.autoGetTimer);

            onCreate(goldObject);
        }

        public void Setup(int gold, float autoGetTimer)
        {
            this.gold = gold;
            this.autoGetTimer = autoGetTimer;
        }
        #endregion

        #region private methods
        private void UnsubscribeEvent()
        {
            EasyTouch.On_SimpleTap -= OnTap;
        }

        private void OnTap(Gesture gesture)
        {
            AddGold();
        }

        private void AddGold()
        {
            GlobalData.AddGold(gold, current =>
            {
                PageSceneUIManager.I.GetStatusBar().UpdateGoldText(current);
                MasterAudio.PlaySound("8BIT_RETRO_Coin_Collect_Two_Note_Bright_Twinkle_mono");
            });

            var duration = 0.5f;
            var seq = DOTween.Sequence();
            seq.Append(transform.DOLocalMoveY(50, duration)
                       .SetRelative());
            seq.Join(spriteRenderer.DOFade(0, duration));
            seq.OnComplete(() => Destroy(gameObject));
        }
        #endregion
    }

    public struct GoldObjectSetting
    {
        public int gold;
        public float autoGetTimer;
    }
}