using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeycardReader : MonoBehaviour
{

    public GameObject player;
    public GameObject Door;


    void CloseDoor()
    {
        Door.GetComponent<DoorScript>().CanOpen = false;
    }
    public void Interact()
    {
        if (player.GetComponent<Player>())
        {
            Door.GetComponent<DoorScript>().CanOpen = true;
            Invoke("CloseDoor", 5f);
        }
    }
}
