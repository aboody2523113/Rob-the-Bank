using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class main : MonoBehaviour
{

     public AudioSource button;
     public AudioClip clip;

     void start()
     {
          button = GetComponent<AudioSource>();
     }
    public void game()
     {
          button.PlayOneShot(clip);
     }



   IEnumerator sound()
   {
   yield return new WaitForSeconds(1);
   }

   public void load()
   {
      SceneManager.LoadScene(0);
   }
   public void gide()
   {
      SceneManager.LoadScene(1);
   }
}
