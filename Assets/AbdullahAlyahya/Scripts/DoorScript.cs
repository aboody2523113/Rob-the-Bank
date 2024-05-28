using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorScript : MonoBehaviour
{
    public GameObject player;

    public Animator anim;

    public bool CanOpen;

    public bool Opened;

    private void Start()
    {
        anim = GetComponent<Animator>();    
    }

    public void OpenDoor()
    {
        if (CanOpen)
        {
            if(Opened == false)
            {
                Opened = true;
                anim.SetBool("Open", true);
                GetComponent<BoxCollider>().isTrigger = true;
            }
            else
            {
                CloseDoor();
            }
        }
    }

    public void CloseDoor()
    {
        if(Opened == true)
        {
            Opened = false;
            anim.SetBool("Open", false);
            GetComponent<BoxCollider>().isTrigger = false;
        }
        else
        {
            OpenDoor();
        }
    }
}
