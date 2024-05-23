using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NPC : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject player;

    public Detector detector;

    public NavMeshAgent agent;

    public GameObject Head;

    public GameObject[] BotPlaces;
    private bool WalkingToBotPlace = false;
    private bool CanWalkToNewBotPlace = true;

    public bool CanBeThreated;
    void Start()
    {
        detector = GetComponent<Detector>();
    }

    void WalkToNewBotPlace()
    {
        CanWalkToNewBotPlace = true;
    }

    void Update()
    {
        if(detector.IsDetecting == true)
        {
            if(detector.Detection >= 10f)
            {
                agent.destination = player.transform.position;
                transform.LookAt(player.transform.position);
                Head.transform.LookAt(player.transform.position);

            }else if(detector.Detection >= 5f)
            {
                agent.destination = transform.position;
                transform.LookAt(player.transform.position);
                Head.transform.LookAt(player.transform.position);
            }
            else if(detector.Detection > 0)
            {
                Head.transform.LookAt(player.transform.position);
            }
        }
        else
        {
            if (Vector3.Distance(agent.destination,transform.position) <= 0.5f)
            {
                WalkingToBotPlace = false;
            }
            if (WalkingToBotPlace == false)
            {
                if (CanWalkToNewBotPlace == true)
                {
                    GameObject BotPlace = BotPlaces[Random.Range(0, BotPlaces.Length)];
                    agent.destination = BotPlace.transform.position;
                    WalkingToBotPlace = true;
                    CanWalkToNewBotPlace = false;
                    Invoke("WalkToNewBotPlace", 30f);
                }
            }
        }

    }
}
