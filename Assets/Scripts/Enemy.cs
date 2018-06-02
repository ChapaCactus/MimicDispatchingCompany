using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

namespace CCG
{
    public class Enemy : MonoBehaviour
    {
        #region properties
        private CharacterData data { get; set; }
        #endregion

        #region public methods
        public void Setup(CharacterData data)
        {
            this.data = data;
        }
        #endregion
    }
}