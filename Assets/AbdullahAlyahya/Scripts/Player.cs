using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Start is called before the first frame update

    public float DetectionSpeed;

    public GameObject[] Detectors;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Detectors.Length >= 1)
        {
            for (int i = 0; i < Detectors.Length; i++)
            {
                if (Detectors[i] != null)
                {
                    GameObject Detector = Detectors[i];

                }
            }
    }

    private int FindIndex(GameObject obj, GameObject[] array)
    {
        for (int i = 0; i < array.Length; i++)
        {
            if (obj == array[i])
            {
                return i;
            }
        }
    }

    public void StartDetecting(GameObject detector)
    {
        Detectors[Detectors.Length] = detector;
    }

    public void StopDetecting(GameObject detector)
    {
        Detectors[FindIndex(detector,Detectors)] = null;
    }
}
