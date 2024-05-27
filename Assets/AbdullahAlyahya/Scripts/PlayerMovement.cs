using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject cam;

    public CharacterController charcont;

    public Animator anim;

    private void Start()
    {
        charcont = GetComponent<CharacterController>();
        Cursor.lockState = CursorLockMode.Locked;
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");

        cam.transform.eulerAngles -= new Vector3(mouseY, 0, 0);
        transform.eulerAngles -= new Vector3(0, -mouseX, 0);


        float ver = Input.GetAxis("Vertical");
        float hr = Input.GetAxis("Horizontal");

        if(ver != 0 || hr != 0)
        {
            Vector3 vctr = new Vector3(hr, 0, ver);
            Vector3 movement = Quaternion.Euler(0f,cam.transform.eulerAngles.y,0f) * vctr;

            charcont.Move(movement * 2 * Time.deltaTime);
            anim.SetBool("Walking", true);
        }
        else
        {
            anim.SetBool("Walking", false);
        }

        if (!charcont.isGrounded)
        {
            charcont.Move(Vector3.down * 5 * Time.deltaTime);
        }
    }
}
