using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainStory : MonoBehaviour
{
   public void Next()
   {
       SceneManager.LoadScene("SampleScene", LoadSceneMode.Single);
   }
   
}
