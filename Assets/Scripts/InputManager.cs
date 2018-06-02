using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

namespace CCG
{
    public class InputManager : MonoBehaviour
    {
        public enum InputState
        {
            DragStart,
            Dragging,
            DragEnd,
        }

        #region properties
        public InputState inputState { get; private set; }
        #endregion

        #region public methods
        public void OnDragStart(Vector2 dragStartPos)
        {
            if (inputState == InputState.DragStart)
                return;
            if (inputState == InputState.Dragging)
                return;

            inputState = InputState.DragStart;
        }

        public void OnDragEnd(Vector2 dragEndPos)
        {
        }
        #endregion
    }
}