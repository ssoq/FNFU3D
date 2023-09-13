using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteCuller : MonoBehaviour
{
    private GameObject arrowInner;

    private void Awake()
    {
        arrowInner = transform.GetChild(0).gameObject;
    }

    private void Start()
    {
        arrowInner.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Note Enable")) 
        {
            arrowInner.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Note Enable"))
        {
            arrowInner.SetActive(false);
        }
    }
}
