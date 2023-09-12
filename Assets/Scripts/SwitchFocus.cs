using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchFocus : MonoBehaviour
{
    public bool player;
    public bool both;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Note Enable") && player) 
        {
            GameManager.Instance.focusAnim.SetBool("player", true);
        }
        if (collision.gameObject.CompareTag("Note Enable") && !player)
        {
            GameManager.Instance.focusAnim.SetBool("player", false);
        }

        if (collision.gameObject.CompareTag("Note Enable") && both)
        {
            GameManager.Instance.focusAnim.SetBool("both", true);
        }
        if (collision.gameObject.CompareTag("Note Enable") && !both)
        {
            GameManager.Instance.focusAnim.SetBool("both", false);
        }
    }
}
