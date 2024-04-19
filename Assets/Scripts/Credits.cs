using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Credits : MonoBehaviour
{
    // Start is called before the first frame update
   public GameObject CreditsUI;


    public void ShowCredits()
    {
        if(CreditsUI != null){
            CreditsUI.SetActive(true);
        }
    }

}
