using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class InputManager : Singleton<InputManager>
{
    public UnityAction OnJumpPressed;
    public UnityAction OnMoveStarted;
    public UnityAction OnRightMoved;
    public UnityAction OnLeftMoved;
    public UnityAction OnNothingPressed;
    public UnityAction OnKick;
    public UnityAction OnPunch;

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

    public void OnUpPressed()
    {
        isUpPressed = true;
    }
    public void OnUpReleased()
    {
        isUpPressed = false;
    }
    public void OnRightDown()
    {
        isRightPressed = true;
    }
    public void OnRightUp()
    {
        isRightPressed = false;
    }
    public void OnLeftDown()
    {
        isLeftPressed = true;
    }
    public void OnLeftUp()
    {
        isLeftPressed = false;
    }

    public void OnPunchPressed()
    {
        OnPunch?.Invoke();
    }
    public void OnKickPressed()
    {
        OnKick?.Invoke();
    }
}
