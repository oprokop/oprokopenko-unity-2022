using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class LightsChanging : MonoBehaviour
{
    public List<Light> spots;
    [SerializeField] float minFlickerSpeed = 0.1f;
    [SerializeField] float maxFlickerSpeed = 1.1f;
    private float[] xDefaults;

    private void Start()
    {
        xDefaults = new float[spots.Count];
        for(int i = 0; i < spots.Count; i++)
        {
            var xDefault = spots[i].GetComponent<Transform>().position.x;
            xDefaults[i] = xDefault;
        }

        StartCoroutine(Flickering());
    }
    IEnumerator Flickering()
    {
        while(true)
        {
            foreach (Light spot in spots)
            {
                spot.enabled = !spot.enabled;
            }
            yield return new WaitForSeconds(Random.Range(minFlickerSpeed, maxFlickerSpeed));
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        var randomColor = new Color(Random.Range(0, 255), Random.Range(0, 255), Random.Range(0, 255), 255);

        foreach (Light spot in spots)
        {
            if (spot == null)
            {
                return;
            }
            spot.color = randomColor;

            for(int i = 0; i < spots.Count; i++)
            {
                spot.transform.position = new Vector3
                    (
                    Random.Range(xDefaults[i] - 5.0f, xDefaults[i] + 5.0f),
                    spot.transform.position.y,
                    spot.transform.position.z
                    );
            }
        }
    }
}
