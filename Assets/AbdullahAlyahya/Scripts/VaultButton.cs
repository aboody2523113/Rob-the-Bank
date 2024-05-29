using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VaultButton : MonoBehaviour
{
    public GameObject VaultDoor;

    public AudioClip VaultOpenSound;

    public void Interact()
    {
        VaultDoor.GetComponent<VaultDoor>().OpenDoor();
    }
}
