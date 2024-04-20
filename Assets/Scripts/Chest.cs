using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour
{

    [SerializeField] private bool isOpen;
    [SerializeField] private Animator chestAnimator;

    public void openChest()
    {
        if(!isOpen)
        {
            isOpen = true;
            chestAnimator.SetBool("IsOpen", isOpen);
        }
    }
}
