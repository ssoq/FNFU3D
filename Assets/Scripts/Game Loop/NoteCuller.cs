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
        if (arrowInner == null) arrowInner = transform.GetChild(0).gameObject;

        arrowInner.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (arrowInner == null) return;

        if (collision.gameObject.CompareTag("Note Enable")) 
        {
            arrowInner.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (arrowInner == null) return;

        if (collision.gameObject.CompareTag("Note Enable"))
        {
            arrowInner.SetActive(false);
        }
    }
}
