using System.Collections.Generic;
using UnityEngine;

public class PingPong : MonoBehaviour
{
    private Vector3 positionDisplacement;
    private Vector3 positionOrigin;
    private float _timePassed;

    private void Start()
    {
        float randomDistance = Random.Range(-5f, 5f);
        positionDisplacement = new Vector3(randomDistance, randomDistance, randomDistance);
        positionOrigin = transform.position;
    }

    private void Update()
    {
        _timePassed += Time.deltaTime;
        transform.position = Vector3.Lerp(positionOrigin, positionOrigin + positionDisplacement,Mathf.PingPong(_timePassed, 1));
    }
}