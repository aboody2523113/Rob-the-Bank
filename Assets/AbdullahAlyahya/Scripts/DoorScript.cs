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

    private void Start()
    {
        OpenDoor();
    }


    public void OpenDoor()
    {
        if (CanOpen)
        {
            frameDoor.transform.position = openedFrame.transform.position;
            frameDoor.transform.rotation = openedFrame.transform.rotation;
        }
    }

    public void CloseDoor()
    {
        frameDoor.transform.position = closedFrame.transform.position;
        frameDoor.transform.rotation = closedFrame.transform.rotation;
    }
}
