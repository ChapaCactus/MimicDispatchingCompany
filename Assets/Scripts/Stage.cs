using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

namespace CCG
{
    public class Stage : MonoBehaviour
    {
        #region classes
        public class Data
        {
            /// <summary>
            /// コンストラクタ
            /// </summary>
            public Data(int id, string name, string bgName)
            {
                this.id = id;
                this.name = name;
                this.bgName = bgName;
            }

            public int id { get; private set; }
            public string name { get; private set; }
            public string bgName { get; private set; }
        }
        #endregion

        #region properties
        public Mimic mimic { get; private set; }

        private Data data { get; set; }
        #endregion

        #region public methods
        public void SetMimic(Mimic mimic)
        {
            this.mimic = mimic;
        }
        #endregion
    }
}