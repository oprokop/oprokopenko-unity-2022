using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;

using UnityEngine;

public class Explosion : MonoBehaviour
{
    public GameObject Prefab;
    public Material invisibleMaterial;

    private void OnCollisionEnter(Collision collision)
    {
        //var _timer = new Timer(TimerCallback, null, 0, 2000);
        var granadeCollider = Prefab.GetComponent<SphereCollider>();
        var meshRender = Prefab.GetComponent<MeshRenderer>();

        Debug.Log("onCollisionEnter - " + collision);

        var sizeIncr = 1;

        meshRender.material = invisibleMaterial;

        while (granadeCollider.radius < 5)
        {
            granadeCollider.radius = granadeCollider.radius + sizeIncr;
        }

    }


    //private IEnumerator Countdown2()
    //{
    //    while (true)
    //    {
    //        yield return new WaitForSeconds(2.0f); //wait 2 seconds
    //        Debug.Log("1 sec");                                    //do thing
    //    }
    //}
    //private static void TimerCallback(object o)
    //{
    //    Debug.Log("In TimerCallback: " + DateTime.Now);
    //}
}
