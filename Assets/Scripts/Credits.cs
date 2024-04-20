using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Credits : MonoBehaviour
{
    // Start is called before the first frame update
   public GameObject CreditsUI;

   void Update(){
         CloseCredits();
   }


    public void ShowCredits()
    {
        if(CreditsUI != null){
            CreditsUI.SetActive(true);
        }
    }

    // click na tela fechar o panel

    private void CloseCredits()
    {
        if(Input.GetKeyDown("mouse 0")){
            Debug.Log("Clicou");
            CreditsUI.SetActive(false);
        }
    }

}
