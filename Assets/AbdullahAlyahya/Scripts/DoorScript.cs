using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorScript : MonoBehaviour
{
    public GameObject player;

    public GameObject frameDoor;

    public GameObject openedFrame;

    public GameObject closedFrame;

    public bool CanOpen;

    public bool Opened;



    public void OpenDoor()
    {
        if (CanOpen)
        {
            if(Opened == false)
            {
                Opened = true;
                frameDoor.transform.position = openedFrame.transform.position;
                frameDoor.transform.rotation = openedFrame.transform.rotation;
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
            frameDoor.transform.position = closedFrame.transform.position;
            frameDoor.transform.rotation = closedFrame.transform.rotation;
            GetComponent<BoxCollider>().isTrigger = false;
        }
        else
        {
            OpenDoor();
        }
    }
}
