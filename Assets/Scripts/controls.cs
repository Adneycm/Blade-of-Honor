using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class controls : MonoBehaviour
{

    public GameObject ControlsUI;
    public GameObject pauseMenuUI;
    // Update is called once per frame
     void Update(){
         CloseControls();
   }


   private void CloseControls()
    {
        if(Input.GetKeyDown("mouse 0")){
            // Debug.Log("Clicou");
            ControlsUI.SetActive(false);
            pauseMenuUI.SetActive(true);

        }
    }

}
