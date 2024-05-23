using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NewBehaviourScript : MonoBehaviour
{
   public void game()
   {
    SceneManager.LoadScene(0);
   }
   public void set()
   {
    SceneManager.LoadScene(1);
   }
}