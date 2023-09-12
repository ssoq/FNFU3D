using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AINoteLogic : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("AINote"))
        {
            GameManager.Instance.health -= GameManager.Instance.badScore / 2;
            collision.gameObject.SetActive(false);
        }
    }
}
