using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

using System.Linq;

namespace CCG
{
    public class MimicStock : MonoBehaviour
    {
        #region constants
        private List<float> CreateOffsets = new List<float>
        {
            -300,
            -150,
            0,
            150,
            300,
        };
        #endregion

        #region variables
        #endregion

        #region properties
        #endregion

        #region unity callbacks
        private void Awake()
        {
            CreateMimics();
        }
        #endregion

        #region private methods
        private void CreateMimics()
        {
            var dummyData = CharacterData.CreateDummyData();

            CreateOffsets.ForEach(offset => Mimic.Create(mimic =>
            {
                mimic.Setup(dummyData);
                mimic.transform.position = new Vector2(offset, transform.position.y);
            }));

            Debug.Log("CreateMimics...");
        }
        #endregion
    }
}