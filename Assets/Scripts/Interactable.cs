using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Interactable : MonoBehaviour
{
    [SerializeField] private bool isInRange;
    [SerializeField] private KeyCode interactionKey;
    [SerializeField] private UnityEvent interactAction;
    [SerializeField] private Canvas canvasObject;

    void Start()
    {
        canvasObject.gameObject.SetActive(false);
    }

    void Update()
    {
        if (isInRange)
        {
            if (Input.GetKeyDown(interactionKey))
            {
                interactAction.Invoke();
                canvasObject.gameObject.SetActive(false);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isInRange = true;
            canvasObject.gameObject.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isInRange = false;
            canvasObject.gameObject.SetActive(false);
        }
    }
}
