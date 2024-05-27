using System.Collections;
using System.Collections.Generic;
using System.IO.Pipes;
using UnityEngine;

public class Detector : MonoBehaviour
{
    public GameObject player;
    public float DetectionSpeed;
    public float Detection;
    public bool IsDetecting = false;
    private NPC npcScript;

    public GameObject Head;

    private bool FirstFrame = true;

    private bool InPlayerArea = false;

    void Start()
    {
        npcScript = GetComponent<NPC>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject == player)
        {
            InPlayerArea = true;

        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == player)
        {
            InPlayerArea = false;
        }
    }
    void Update()
    {
        
        Vector3 DirectionToPlayer = player.transform.position - Head.transform.position;
        float Diffrence = Vector3.Dot(DirectionToPlayer, Head.transform.forward);
        if(Diffrence >= 0f)
        {
            Ray ray = new Ray(Head.transform.position, DirectionToPlayer);
            if(Physics.Raycast(ray, out RaycastHit hitInfo,Mathf.Infinity))
            {
                if(hitInfo.collider.gameObject == player)
                {
                    if(IsDetecting == false)
                    {
                        player.GetComponent<Player>().StartDetecting(gameObject);
                    }
                    IsDetecting = true;
                }
                else
                {
                    if (InPlayerArea == false)
                    {
                        IsDetecting = false;
                    }
                    else
                    {
                        if (IsDetecting == false)
                        {
                            player.GetComponent<Player>().StartDetecting(gameObject);
                        }
                        float PlayerDetectionSpeed = player.GetComponent<Player>().DetectionSpeed;
                        IsDetecting = true;
                        Detection += Time.deltaTime * DetectionSpeed * PlayerDetectionSpeed;
                    }

                }
            }
            else
            {
                if (InPlayerArea == false)
                {
                    IsDetecting = false;
                }
                else
                {
                    if(IsDetecting == false)
                    {
                        player.GetComponent<Player>().StartDetecting(gameObject);
                    }
                    IsDetecting = true;
                }
            }
        }
        else
        {

            if(InPlayerArea == false) {
                IsDetecting = false;
            }
            else
            {
                if (IsDetecting == false)
                {
                    player.GetComponent<Player>().StartDetecting(gameObject);
                }
                IsDetecting = true;
            }
        }

        if (IsDetecting) {
            float PlayerDetectionSpeed = player.GetComponent<Player>().DetectionSpeed;
            if(PlayerDetectionSpeed > 0)
            {
                Detection += Time.deltaTime * DetectionSpeed * PlayerDetectionSpeed;
            }
        }
        else
        {
            if(Detection > 0)
            {
                Detection -= Time.deltaTime * 2f;
            }
            else
            {
                if(FirstFrame == false)
                {
                    player.GetComponent<Player>().StopDetecting(gameObject);
                }
            }
        }
        FirstFrame = false;

    }
}
