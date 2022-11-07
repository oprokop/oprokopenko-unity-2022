using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Manager : MonoBehaviour
{
    public Character character;
    public Door door;
    private NavMeshAgent agent;
    private NavMeshHit hit;
    private float defaultSpeed;
    private int layerIndex;
    private float tLerp;
    
    void Start()
    {
        agent = character.GetComponent<NavMeshAgent>();
        defaultSpeed = agent.speed;
        tLerp = 0.0f;
    }

    void Update()
    {
        if (NavMesh.SamplePosition(agent.transform.position, out hit, 1f, NavMesh.AllAreas))
        {
            layerIndex = IndexFromMask(hit.mask);
        }

        if (layerIndex == 3)
        {
            agent.speed = SpeedChanger.GetSpeed(agent.transform.position.y, agent.destination.y, defaultSpeed);
        }
        else
        {
            agent.speed = defaultSpeed;
        }
        
        if (layerIndex == 4)
        {
            tLerp += 1.5f * Time.deltaTime;
            if (tLerp > 1.0f)
            {
                tLerp = 1.0f;
            }
        }
        else
        {
            tLerp -= 1.5f * Time.deltaTime;
            if (tLerp < 0.0f)
            {
                tLerp = 0.0f;
            }
        }
        door.MoveDoor(tLerp);
    }

    private static int IndexFromMask(int mask)
    {
        for (int i = 0; i < 32; ++i)
        {
            if ((1 << i) == mask)
                return i;
        }
        return -1;
    }
}
