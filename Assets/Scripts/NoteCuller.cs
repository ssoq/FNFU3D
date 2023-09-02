using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteCuller : MonoBehaviour
{
    [SerializeField] private NoteLogic logicScript;

    private void Awake()
    {
        logicScript = GetComponent<NoteLogic>();
    }

    private void Start()
    {
        logicScript.enabled = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Note Enable")) 
        {
            logicScript.enabled = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Note Enable"))
        {
            logicScript.enabled = false;
        }
    }
}
