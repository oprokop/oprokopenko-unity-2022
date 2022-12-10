using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    private float length;
    private float startpos;
    public GameObject cam;
    [SerializeField] float parallexEffect;

    void Start()
    {
        startpos = transform.position.x;
        length = GetComponent<SpriteRenderer>().bounds.size.x;
    }
    void Update()
    {
        float distanceToCamera = (cam.transform.position.x * (1 - parallexEffect));
        float distance = (cam.transform.position.x * parallexEffect);

        transform.position = new Vector2(startpos + distance, transform.position.y);
       
        if (distanceToCamera > startpos + length)
        {
            startpos += length;
        }
        else if (distanceToCamera < startpos - length)
        {
            startpos -= length;
        }
    }
}