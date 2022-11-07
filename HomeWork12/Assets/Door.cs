using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.TextCore.Text;

public class Door : MonoBehaviour
{
    private Vector3 closedDoor;
    private Vector3 openedDoor;

    void Start()
    {
        closedDoor = transform.position;
        openedDoor = closedDoor;
        openedDoor.z += 1.5f;
    } 

    public void MoveDoor(float t)
    {
        transform.position = new Vector3(closedDoor.x, closedDoor.y, Mathf.Lerp(closedDoor.z, openedDoor.z, t));
    }
}
