using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VaultDoor : MonoBehaviour
{
    public Animator anim;
    public void OpenDoor()
    {
        anim.SetBool("Open", true);
        gameObject.GetComponent<BoxCollider>().enabled = false;
    }
}
