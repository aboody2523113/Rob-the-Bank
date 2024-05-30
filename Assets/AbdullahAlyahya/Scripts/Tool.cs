using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Tool : MonoBehaviour
{

    public GameObject player;
    public void Interact()
    {
        player.GetComponent<Player>().Inventory.Add("Keycard");
        Destroy(gameObject);
    }
}
