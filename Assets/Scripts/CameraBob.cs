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

    private Vector3 normal = new Vector3(0, 0, 0);
    private Vector3 rotLeft = new Vector3(-1.5f, 0, 0);
    private Vector3 rotRight = new Vector3(1.5f, 0, 0);
    private Vector3 rotUp = new Vector3(0, 1.5f, 0);
    private Vector3 rotDown = new Vector3(0, -1.5f, 0);

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
            cam.transform.localPosition = Vector3.Slerp(cam.transform.localPosition, rotLeft, rotationSmoothing * Time.deltaTime);
        }

        if (Input.GetKey(GameManager.Instance.right))
        {
            cam.transform.localPosition = Vector3.Slerp(cam.transform.localPosition, rotRight, rotationSmoothing * Time.deltaTime);
        }

        if (Input.GetKey(GameManager.Instance.up))
        {
            cam.transform.localPosition = Vector3.Slerp(cam.transform.localPosition, rotUp, rotationSmoothing * Time.deltaTime);
        }

        if (Input.GetKey(GameManager.Instance.down))
        {
            cam.transform.localPosition = Vector3.Slerp(cam.transform.localPosition, rotDown, rotationSmoothing * Time.deltaTime);
        }

        if (!Input.GetKey(GameManager.Instance.left) && !Input.GetKey(GameManager.Instance.right) && !Input.GetKey(GameManager.Instance.up) && !Input.GetKey(GameManager.Instance.down))
        {
            cam.transform.localPosition = Vector3.Slerp(cam.transform.localPosition, normal, rotationSmoothing * Time.deltaTime);
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
