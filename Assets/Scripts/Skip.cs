using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Skip : MonoBehaviour
{
    // button to skip cutscenes
    public void Next()
   {
       SceneManager.LoadScene("SampleScene");
   }
}
