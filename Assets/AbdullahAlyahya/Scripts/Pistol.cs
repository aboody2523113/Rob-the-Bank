using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Pistol : MonoBehaviour
{
    // Start is called before the first frame update

    public Animator anim;

    public bool CanShot = true;

    public bool Aiming = false;

    public GameObject Player;

    public GameObject GameManager;

    public AudioClip ShotSound;

    public GameObject cam;

    void Start()
    {
        anim = GetComponent<Animator>();     
    }

    void TurnCanShot(){
        CanShot = true;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.DrawRay(cam.transform.position, cam.transform.forward * 500);
        if (Player.GetComponent<PlayerMovement>().IsWalking == true){
            anim.SetBool("Walking",true);
        }else{
            anim.SetBool("Walking",false); 
        }

        if(Input.GetButton("Fire1")){
            if(CanShot == true){
                CanShot = false;
                if(Aiming == true)
                {
                    anim.Play("AimingShot");
                }
                else
                {
                    anim.Play("Shot");
                }
                GameManager.GetComponent<GameManager>().PlayAudio(ShotSound);
                Invoke("TurnCanShot",1f);
                Ray ray = new Ray(cam.transform.position, cam.transform.forward);
                if (Physics.Raycast(ray, out RaycastHit hit, Mathf.Infinity))
                {
                    if (hit.collider.gameObject.CompareTag("NPC"))
                    {
                        GameObject enemy = hit.collider.gameObject;
                        enemy.GetComponent<NPC>().Damage(100f);
                    }
                }
            }
        }

        if(Input.GetMouseButtonDown(1))
        {
            if (Aiming == false)
            {
                Aiming = true;
                anim.SetBool("Aiming", true);
            }
        }
        if (Input.GetMouseButtonUp(1))
        {
            if (Aiming == true)
            {
                Aiming = false;
                anim.SetBool("Aiming", false);

            }
        }

    }
}
