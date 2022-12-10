using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class InputManager : MonoBehaviour
{
    public UnityAction OnJumpPressed;
    public UnityAction OnMoveStarted;
    public UnityAction OnRightMoved;
    public UnityAction OnLeftMoved;
    public UnityAction OnKickPressed;
    public UnityAction OnNothingPressed;

    bool isUpPressed;
    bool isRightPressed;
    bool isLeftPressed;

    void Update()
    {
        if (!isUpPressed && !isRightPressed && !isLeftPressed)
        {
            OnNothingPressed?.Invoke();
            return;
        }
        if (isLeftPressed)
        {
            OnLeftMoved?.Invoke();
            OnMoveStarted?.Invoke();
        }

        if (isRightPressed)
        {
            OnRightMoved?.Invoke();
            OnMoveStarted?.Invoke();
        }
        if (isUpPressed)
        {
            OnJumpPressed?.Invoke();
        }
    }

    public void onUpPressed()
    {
        isUpPressed = true;
    }
    public void onUpReleased()
    {
        isUpPressed = false;
    }
    public void onRightDown()
    {
        isRightPressed = true;
    }
    public void onRightUp()
    {
        isRightPressed = false;
    }
    public void onLeftDown()
    {
        isLeftPressed = true;
    }
    public void onLeftUp()
    {
        isLeftPressed = false;
    }
}
