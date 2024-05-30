using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VaultButton : MonoBehaviour
{
    public GameObject VaultDoor;

    public GameManager gameManager;

    public AudioClip VaultOpenSound;

    public bool IsOpened = false;

    public void Interact()
    {
        if(IsOpened == false)
        {
            IsOpened = true;
            VaultDoor.GetComponent<VaultDoor>().OpenDoor();
            gameManager.PlayAudio(VaultOpenSound);
        }

    }
}
