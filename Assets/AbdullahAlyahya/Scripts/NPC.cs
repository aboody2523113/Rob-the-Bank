using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NPC : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject player;

    public GameObject GM;

    public string[] Tools;

    public float Health;

    public bool Dead;

    public Detector detector;

    public NavMeshAgent agent;

    public Animator anim;

    public GameObject Head;

    public GameObject[] BotPlaces;
    private bool WalkingToBotPlace = false;
    private bool CanWalkToNewBotPlace = true;

    public bool CanBeThreated;
    void Start()
    {
        detector = GetComponent<Detector>();
        agent = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
        Health = 100f;
    }

    void WalkToNewBotPlace()
    {
        if(detector.Detection <= 5f)
        {
            CanWalkToNewBotPlace = true;
        }
    }
    
    void Death2()
    {
        if(Tools.Length > 0)
        {
            for(int i = 0; i < Tools.Length; i++)
            {
                GameObject tool = Instantiate(GM.GetComponent<GameManager>().tools[Tools[i]]);
                tool.transform.position = transform.position;
            }
        }
        if (detector.IsDetecting == true)
        {
            player.GetComponent<Player>().StopDetecting(gameObject);
        }
        gameObject.SetActive(false);
    }
    void OnDeath()
    {
        {
            
        }
        anim.SetBool("Death", true);
        Dead = true;
        Invoke("Death2", 1f);
    }

    public void Damage(float Dmg)
    {
        if(Health > 0f)
        {
            Health -= Dmg;
            if(Health <= 0f)
            {
                OnDeath();
            }
        }
    }

    void Update()
    {
        if(Dead != true)
        {
            Vector3 direction = player.transform.position - Head.transform.position;
            float diffrence = Vector3.Dot(direction, transform.forward);
            if (Vector3.Distance(agent.destination, transform.position) <= 0.5f)
            {
                anim.SetBool("Walking", false);

            }
            else
            {
                anim.SetBool("Walking", true);
            }
            if (detector.IsDetecting == true)
            {
                if (detector.Detection >= 10f)
                {
                    agent.destination = player.transform.position;
                    transform.LookAt(player.transform.position);
                    if (diffrence >= 0f)
                    {
                        Head.transform.LookAt(player.transform.position);
                    }

                }
                else if (detector.Detection >= 5f)
                {
                    agent.destination = transform.position;
                    transform.LookAt(player.transform.position);
                    if (diffrence >= 0f)
                    {
                        Head.transform.LookAt(player.transform.position);
                    }
                }
                else if (detector.Detection > 0)
                {
                    if (diffrence >= 0f)
                    {
                        Head.transform.LookAt(player.transform.position);
                    }
                }
                else
                {
                    Head.transform.rotation = transform.rotation;
                }
            }
            else
            {
                if (detector.Detection > 0f)
                {
                    if (diffrence >= 0f)
                    {
                        Head.transform.LookAt(player.transform.position);
                    }
                }
                else
                {
                    Head.transform.rotation = transform.rotation;
                }
                if (Vector3.Distance(agent.destination, transform.position) <= 0.5f)
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
                        Invoke("WalkToNewBotPlace", 10f);
                    }
                }
            }
        }

    }
}
