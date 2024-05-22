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

    void Start()
    {
        npcScript = GetComponent<NPC>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 DirectionToPlayer = player.transform.position - transform.position;
        float Diffrence = Vector3.Dot(DirectionToPlayer, transform.forward);
        if(Diffrence >= 1f)
        {
            Ray ray = new Ray(transform.position, DirectionToPlayer);
            if(Physics.Raycast(ray, out RaycastHit hitInfo,Mathf.Infinity))
            {
                if(hitInfo.collider.gameObject == player)
                {
                    IsDetecting = true;
                }
                else
                {
                    IsDetecting = false;

                }
            }
            else
            {
                IsDetecting = false;
            }
        }
        else
        {
            IsDetecting = false;
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
                Detection -= Time.deltaTime * 5;
            }
        }

    }
}
