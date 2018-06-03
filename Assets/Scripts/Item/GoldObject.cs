using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

using HedgehogTeam.EasyTouch;

namespace CCG
{
    public class GoldObject : MonoBehaviour
    {
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
                    Destroy(gameObject);
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
            });

            Destroy(gameObject);
        }
        #endregion
    }

    public struct GoldObjectSetting
    {
        public int gold;
        public float autoGetTimer;
    }
}