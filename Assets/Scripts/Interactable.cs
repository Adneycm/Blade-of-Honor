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
    [SerializeField] private GameObject chestLoot;
    [SerializeField] private Vector3 velocity;
    private bool interactionHappened;


    void Start()
    {
        canvasObject.gameObject.SetActive(false);
        chestLoot.SetActive(false);
        interactionHappened = false;
    }

    void Update()
    {
        if (isInRange)
        {
            if (Input.GetKeyDown(interactionKey))
            {
                interactAction.Invoke();
                canvasObject.gameObject.SetActive(false);
                chestLoot.SetActive(true);
                chestLoot.transform.position = transform.position;
                Rigidbody2D rb = chestLoot.GetComponent<Rigidbody2D>();
                if (rb != null)
                {
                    rb.velocity = velocity;
                }
                interactionHappened =true;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && !interactionHappened)
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
