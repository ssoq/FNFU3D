using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuLogic : MonoBehaviour
{
    [Header("Animation")]
    [SerializeField] private Animator menuAnim;

    void Start()
    {
        menuAnim = GetComponent<Animator>();
    }

    public void TriggerSettings() 
    {
        menuAnim.SetTrigger("settings");
    }

    public void TriggerFreeplay()
    {
        menuAnim.SetTrigger("freeplay");
    }
}
