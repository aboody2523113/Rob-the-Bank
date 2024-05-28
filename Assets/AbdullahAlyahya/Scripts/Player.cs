using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Start is called before the first frame update

    public List<string> Inventory;

    public GameObject barPrefab;

    public GameObject cam;

    public float DetectionSpeed;

    public List<GameObject> Detectors;

    Dictionary<GameObject, GameObject[]> DetectorToBar = new Dictionary<GameObject, GameObject[]>();


    public GameObject InteractText;


    private bool CheckObject(GameObject obj, GameObject[] array)
    {
        bool RetunredValue = false;
        for(int i = 0; i < array.Length;i++)
        {
            if(obj == array[i])
            {
                RetunredValue = true;
            }

            if(i == array.Length - 1)
            {
                RetunredValue = false;
            }
        }
        return RetunredValue;
    }

    private int FindIndex(GameObject obj, List<GameObject> array)
    {
        int ReturntedValue = 0;
        for (int i = 0; i < array.Count; i++)
        {
                if (obj == array[i])
                {
                    return i;
                }
        }
        return ReturntedValue;

    }     

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        Ray ray = new Ray(transform.position, transform.forward);
        if(Physics.Raycast(ray,out RaycastHit hitInfo, 50f))
        {
            Debug.Log(hitInfo.collider.name);
            if (hitInfo.collider.gameObject.GetComponent<KeycardReader>() != null)
            {
                InteractText.SetActive(true);
            }else if(hitInfo.collider.gameObject.GetComponent<DoorScript>() != null)
            {
                if (hitInfo.collider.gameObject.GetComponent<DoorScript>().CanOpen == true)
                {
                    InteractText.SetActive(true);
                    if (Input.GetKeyDown(KeyCode.E))
                    {
                        hitInfo.collider.gameObject.GetComponent<DoorScript>().OpenDoor();
                    }
                }
                else
                {
                    InteractText.SetActive(false);
                }
            }
            else
            {
                InteractText.SetActive(false);
            }
        }
        else
        {
            InteractText.SetActive(false);
        }


        if(Detectors.Count >= 1)
        {
            for (int i = 0; i < Detectors.Count; i++)
            {
                GameObject Detector = Detectors[i];
                GameObject[] Bars = DetectorToBar[Detector];
                Detector detectorScript = Detector.GetComponent<Detector>();

                var targetPosLocal = cam.transform.InverseTransformPoint(Detector.transform.position);
                var targetAngle = -Mathf.Atan2(targetPosLocal.x, targetPosLocal.y) * Mathf.Rad2Deg;
                Bars[1].transform.eulerAngles = new Vector3(0, 0, targetAngle);

                if (detectorScript.Detection >= 10f)
                    {
                        Bars[0].SetActive(true);
                        Bars[1].SetActive(true);
                        Bars[2].SetActive(true);
                        Bars[3].SetActive(true);
                        Bars[4].SetActive(true);
                    }
                    else if (detectorScript.Detection >= 5f)
                    {
                        Bars[0].SetActive(true);
                        Bars[1].SetActive(true);
                        Bars[2].SetActive(true);
                        Bars[3].SetActive(true);
                        Bars[4].SetActive(false);

                    }
                    else if (detectorScript.Detection >= 2.5f)
                    {
                        Bars[0].SetActive(true);
                        Bars[1].SetActive(true);
                        Bars[2].SetActive(true);
                        Bars[3].SetActive(false);
                        Bars[4].SetActive(false);


                    }
                    else if (detectorScript.Detection > 0f)
                    {
                        Bars[0].SetActive(true);
                        Bars[1].SetActive(true);
                        Bars[2].SetActive(true);
                        Bars[3].SetActive(false);
                        Bars[4].SetActive(false);

                    }
                    else
                    {
                        Bars[0].SetActive(false);
                        Bars[1].SetActive(false);
                        Bars[2].SetActive(false);
                        Bars[3].SetActive(false);
                        Bars[4].SetActive(false);
                    }



            }
        }
    }


    public void StartDetecting(GameObject detector)
    {
        if (!Detectors.Contains(detector))
        {
            Detectors.Add(detector);
            GameObject Bar = Instantiate(barPrefab);
            GameObject[] array = new GameObject[5];
            array[0] = Bar;
            array[1] = Bar.transform.GetChild(0).gameObject;
            array[2] = Bar.transform.GetChild(0).gameObject.transform.GetChild(0).gameObject;
            array[3] = Bar.transform.GetChild(0).gameObject.transform.GetChild(0).gameObject.transform.GetChild(0).gameObject;
            array[4] = Bar.transform.GetChild(0).gameObject.transform.GetChild(0).gameObject.transform.GetChild(0).gameObject.transform.GetChild(0).gameObject;
            DetectorToBar.Add(detector, array);
        }
    }

    public void StopDetecting(GameObject detector)
    {
        if (Detectors.Contains(detector))
        {
            Detectors.Remove(detector);
            GameObject[] Bar = DetectorToBar[detector];
            DetectorToBar.Remove(detector);
            Destroy(Bar[0]);
        }
    }
}
