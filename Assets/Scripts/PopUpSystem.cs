using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PopUpSystem : MonoBehaviour
{

    [SerializeField] private GameObject popUpBox;
    [SerializeField] private Animator animator;
    [SerializeField] private TMP_Text popUpText;


    public void PopUp(string text)
    {
        popUpBox.SetActive(true);
        popUpText.text = text;
        animator.SetTrigger("pop");
    }
}
