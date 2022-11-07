using System.Collections;
using System.Collections.Generic;
using Unity.AI.Navigation;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public static class SpeedChanger
{
    public static float GetSpeed(float yAgent, float yNext, float speed)
    {
        if (yAgent < yNext)
        {
            return speed / 2;
        }
        else
        {
            return speed * 2;
        }
    }
}
