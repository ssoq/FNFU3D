using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBob : MonoBehaviour
{
    [Header("GameObjects")]
    [SerializeField] private GameObject cam;

    [Header("Customisable")]
    [SerializeField] private float rotationSmoothing = 15f;

    [Space(10f)]

    [SerializeField] private Quaternion normal = Quaternion.identity;
    [SerializeField] private Quaternion rotLeft = Quaternion.Euler(0, -20f, 0);
    [SerializeField] private Quaternion rotRight = Quaternion.Euler(0, 20f, 0);
    [SerializeField] private Quaternion rotUp = Quaternion.Euler(20f, 0, 0);
    [SerializeField] private Quaternion rotDown = Quaternion.Euler(-20f, 0, 0);

    void Start()
    {
        cam = Camera.main.gameObject;
    }

    void Update()
    {
        LerpToKey();
        KeyAnimations();
    }

    private void LerpToKey() 
    {
        if (Input.GetKey(GameManager.Instance.left))
        {
            cam.transform.localRotation = Quaternion.Slerp(cam.transform.localRotation, rotLeft, rotationSmoothing * Time.deltaTime);
        }

        if (Input.GetKey(GameManager.Instance.right))
        {
            cam.transform.localRotation = Quaternion.Slerp(cam.transform.localRotation, rotRight, rotationSmoothing * Time.deltaTime);
        }

        if (Input.GetKey(GameManager.Instance.up))
        {
            cam.transform.localRotation = Quaternion.Slerp(cam.transform.localRotation, rotDown, rotationSmoothing * Time.deltaTime);
        }

        if (Input.GetKey(GameManager.Instance.down))
        {
            cam.transform.localRotation = Quaternion.Slerp(cam.transform.localRotation, rotUp, rotationSmoothing * Time.deltaTime);
        }

        if (!Input.GetKey(GameManager.Instance.left) && !Input.GetKey(GameManager.Instance.right) && !Input.GetKey(GameManager.Instance.up) && !Input.GetKey(GameManager.Instance.down))
        {
            cam.transform.localRotation = Quaternion.Slerp(cam.transform.localRotation, normal, rotationSmoothing * Time.deltaTime);
        }
    }

    private void KeyAnimations() 
    {
        if (Input.GetKeyDown(GameManager.Instance.left))
        {
            GameManager.Instance.leftAnim.SetBool("isPressed", true);
        }
        else if (Input.GetKeyUp(GameManager.Instance.left)) GameManager.Instance.leftAnim.SetBool("isPressed", false);


        if (Input.GetKeyDown(GameManager.Instance.right))
        {
            GameManager.Instance.rightAnim.SetBool("isPressed", true);
        }
        else if (Input.GetKeyUp(GameManager.Instance.right)) GameManager.Instance.rightAnim.SetBool("isPressed", false);


        if (Input.GetKeyDown(GameManager.Instance.up))
        {
            GameManager.Instance.upAnim.SetBool("isPressed", true);
        }
        else if (Input.GetKeyUp(GameManager.Instance.up)) GameManager.Instance.upAnim.SetBool("isPressed", false);


        if (Input.GetKeyDown(GameManager.Instance.down))
        {
            GameManager.Instance.downAnim.SetBool("isPressed", true);
        }
        else if (Input.GetKeyUp(GameManager.Instance.down)) GameManager.Instance.downAnim.SetBool("isPressed", false);
    }
}
