using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FocusCurrentSinger : MonoBehaviour
{
    private Camera cam;
    [SerializeField] private Animator switchFocusAnim;

    [SerializeField] private float smoothing = 10f;
    [SerializeField] private float defaultFov = 4f;
    [SerializeField] private float playerFov = 3f;
    [SerializeField] private float playerDeadFov = 5f;
    [SerializeField] private float enemyFov = 2f;

    [SerializeField] private Vector3 normal = new Vector3(0, 0, 0);
    [SerializeField] private Vector3 aiSinger = new Vector3(0, 0, 0);
    [SerializeField] private Vector3 playerSinger = new Vector3(0, 0, 0);
    [SerializeField] private Vector3 playerSingerDead = new Vector3(0, 0, 0);

    private void Start()
    {
        cam = Camera.main;
    }

    void Update()
    {
        if (!GameManager.Instance.dead)
        {
            if (switchFocusAnim.GetBool("player") && !switchFocusAnim.GetBool("both"))
            {
                transform.localPosition = Vector3.Lerp(transform.localPosition, playerSinger, smoothing * Time.deltaTime);
                cam.orthographicSize = Mathf.Lerp(cam.orthographicSize, playerFov, smoothing * Time.deltaTime);
            }
            else if (!switchFocusAnim.GetBool("player") && !switchFocusAnim.GetBool("both"))
            {
                transform.localPosition = Vector3.Lerp(transform.localPosition, aiSinger, smoothing * Time.deltaTime);
                cam.orthographicSize = Mathf.Lerp(cam.orthographicSize, enemyFov, smoothing * Time.deltaTime);
            }
            else if (switchFocusAnim.GetBool("both") && !switchFocusAnim.GetBool("player"))
            {
                transform.localPosition = Vector3.Lerp(transform.localPosition, normal, smoothing * Time.deltaTime);
                cam.orthographicSize = Mathf.Lerp(cam.orthographicSize, defaultFov, smoothing * Time.deltaTime);
            }
            else if (switchFocusAnim.GetBool("both") && switchFocusAnim.GetBool("player"))
            {
                transform.localPosition = Vector3.Lerp(transform.localPosition, normal, smoothing * Time.deltaTime);
                cam.orthographicSize = Mathf.Lerp(cam.orthographicSize, defaultFov, smoothing * Time.deltaTime);
            }
        }
        else 
        {
            transform.localPosition = Vector3.Lerp(transform.localPosition, playerSingerDead, smoothing * Time.deltaTime);
            cam.orthographicSize = Mathf.Lerp(cam.orthographicSize, playerDeadFov, smoothing * Time.deltaTime);
        }
    }
}
