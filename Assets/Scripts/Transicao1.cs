using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Transicao1 : MonoBehaviour
{
     void OnEnable()
   {
       SceneManager.LoadScene("Desert", LoadSceneMode.Single);
   }
}
