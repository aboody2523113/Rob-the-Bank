using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public AudioSource audioSource;

    public GameObject keycardPrefab;


    public Dictionary<string, GameObject> tools = new Dictionary<string, GameObject>();


    private void Start()
    {

        tools.Add("Keycard", keycardPrefab);
    }


    public void PlayAudio(AudioClip clip)
    {
        audioSource.PlayOneShot(clip);
    }
}
