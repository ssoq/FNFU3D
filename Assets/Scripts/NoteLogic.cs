using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteLogic : MonoBehaviour
{
    [Header("Booleans")]
    private bool gotShit = false;
    private bool gotBad = false;
    private bool gotGood = false;
    private bool gotSick = false;

    [Space(10f)]

    [SerializeField] private bool onLeft;
    [SerializeField] private bool onRight;
    [SerializeField] private bool onUp;
    [SerializeField] private bool onDown;

    [Space(10f)]

    [SerializeField] private GameObject ratingPositionObject;

    private void Update()
    {
        CheckForInput();
    }

    private void CheckForInput() 
    {
        // here, we check for the score the player will receieve upon hitting along with the player hitting the note
        #region Left Key

        if (onLeft) 
        {
            if (gotShit && !gotBad && !gotGood && !gotSick && Input.GetKeyDown(GameManager.Instance.left))
            {
                GameManager.Instance.bfAnim.SetBool("left", true);
                GameManager.Instance.gfAnim.SetBool("left", true);
                GameManager.Instance.score += GameManager.Instance.shitScore;
                GameManager.Instance.health -= GameManager.Instance.shitScore / 2;
                gameObject.SetActive(false);
                Instantiate(GameManager.Instance.shitObj, ratingPositionObject.transform.position, Quaternion.identity);
            }
            else if (gotShit && gotBad && !gotGood && !gotSick && Input.GetKeyDown(GameManager.Instance.left))
            {
                GameManager.Instance.bfAnim.SetBool("left", true);
                GameManager.Instance.gfAnim.SetBool("left", true);
                GameManager.Instance.score += GameManager.Instance.badScore;
                GameManager.Instance.health -= GameManager.Instance.badScore / 2;
                gameObject.SetActive(false);
                Instantiate(GameManager.Instance.badObj, ratingPositionObject.transform.position, Quaternion.identity);
            }
            else if (gotShit && gotBad && gotGood && !gotSick && Input.GetKey(GameManager.Instance.left))
            {
                GameManager.Instance.bfAnim.SetBool("left", true);
                GameManager.Instance.gfAnim.SetBool("left", true);
                GameManager.Instance.score += GameManager.Instance.goodScore;
                GameManager.Instance.health += GameManager.Instance.goodScore / 2;
                gameObject.SetActive(false);
                Instantiate(GameManager.Instance.goodObj, ratingPositionObject.transform.position, Quaternion.identity);
            }
            else if (gotShit && gotBad && gotGood && gotSick && Input.GetKey(GameManager.Instance.left))
            {
                GameManager.Instance.bfAnim.SetBool("left", true);
                GameManager.Instance.gfAnim.SetBool("left", true);
                GameManager.Instance.score += GameManager.Instance.sickScore;
                GameManager.Instance.health += GameManager.Instance.sickScore / 2;
                gameObject.SetActive(false);
                Instantiate(GameManager.Instance.sickObj, ratingPositionObject.transform.position, Quaternion.identity);
            }
        }

        #endregion

        #region Right Key

        if (onRight) 
        {
            if (gotShit && !gotBad && !gotGood && !gotSick && Input.GetKeyDown(GameManager.Instance.right))
            {
                GameManager.Instance.bfAnim.SetBool("right", true);
                GameManager.Instance.gfAnim.SetBool("right", true);
                GameManager.Instance.score += GameManager.Instance.shitScore;
                GameManager.Instance.health -= GameManager.Instance.shitScore / 2;
                gameObject.SetActive(false);
                Instantiate(GameManager.Instance.shitObj, ratingPositionObject.transform.position, Quaternion.identity);
            }
            else if (gotShit && gotBad && !gotGood && !gotSick && Input.GetKeyDown(GameManager.Instance.right))
            {
                GameManager.Instance.bfAnim.SetBool("right", true);
                GameManager.Instance.gfAnim.SetBool("right", true);
                GameManager.Instance.score += GameManager.Instance.badScore;
                GameManager.Instance.health -= GameManager.Instance.badScore / 2;
                gameObject.SetActive(false);
                Instantiate(GameManager.Instance.badObj, ratingPositionObject.transform.position, Quaternion.identity);
            }
            else if (gotShit && gotBad && gotGood && !gotSick && Input.GetKeyDown(GameManager.Instance.right))
            {
                GameManager.Instance.bfAnim.SetBool("right", true);
                GameManager.Instance.gfAnim.SetBool("right", true);
                GameManager.Instance.score += GameManager.Instance.goodScore;
                GameManager.Instance.health += GameManager.Instance.goodScore / 2;
                gameObject.SetActive(false);
                Instantiate(GameManager.Instance.goodObj, ratingPositionObject.transform.position, Quaternion.identity);
            }
            else if (gotShit && gotBad && gotGood && gotSick && Input.GetKeyDown(GameManager.Instance.right))
            {
                GameManager.Instance.bfAnim.SetBool("right", true);
                GameManager.Instance.gfAnim.SetBool("right", true);
                GameManager.Instance.score += GameManager.Instance.sickScore;
                GameManager.Instance.health += GameManager.Instance.sickScore / 2;
                gameObject.SetActive(false);
                Instantiate(GameManager.Instance.sickObj, ratingPositionObject.transform.position, Quaternion.identity);
            }
        }

        #endregion

        #region Down Key

        if (onDown) 
        {
            if (gotShit && !gotBad && !gotGood && !gotSick && Input.GetKeyDown(GameManager.Instance.down))
            {
                GameManager.Instance.bfAnim.SetBool("down", true);
                GameManager.Instance.gfAnim.SetBool("down", true);
                GameManager.Instance.score += GameManager.Instance.shitScore;
                GameManager.Instance.health -= GameManager.Instance.shitScore / 2;
                gameObject.SetActive(false);
                Instantiate(GameManager.Instance.shitObj, ratingPositionObject.transform.position, Quaternion.identity);
            }
            else if (gotShit && gotBad && !gotGood && !gotSick && Input.GetKeyDown(GameManager.Instance.down))
            {
                GameManager.Instance.bfAnim.SetBool("down", true);
                GameManager.Instance.gfAnim.SetBool("down", true);
                GameManager.Instance.score += GameManager.Instance.badScore;
                GameManager.Instance.health -= GameManager.Instance.badScore / 2;
                gameObject.SetActive(false);
                Instantiate(GameManager.Instance.badObj, ratingPositionObject.transform.position, Quaternion.identity);
            }
            else if (gotShit && gotBad && gotGood && !gotSick && Input.GetKeyDown(GameManager.Instance.down))
            {
                GameManager.Instance.bfAnim.SetBool("down", true);
                GameManager.Instance.gfAnim.SetBool("down", true);
                GameManager.Instance.score += GameManager.Instance.goodScore;
                GameManager.Instance.health += GameManager.Instance.goodScore / 2;
                gameObject.SetActive(false);
                Instantiate(GameManager.Instance.goodObj, ratingPositionObject.transform.position, Quaternion.identity);
            }
            else if (gotShit && gotBad && gotGood && gotSick && Input.GetKeyDown(GameManager.Instance.down))
            {
                GameManager.Instance.bfAnim.SetBool("down", true);
                GameManager.Instance.gfAnim.SetBool("down", true);
                GameManager.Instance.score += GameManager.Instance.sickScore;
                GameManager.Instance.health += GameManager.Instance.sickScore / 2;
                gameObject.SetActive(false);
                Instantiate(GameManager.Instance.sickObj, ratingPositionObject.transform.position, Quaternion.identity);
            }
        }

        #endregion

        #region Up Key

        if (onUp) 
        {
            if (gotShit && !gotBad && !gotGood && !gotSick && Input.GetKeyDown(GameManager.Instance.up))
            {
                GameManager.Instance.bfAnim.SetBool("up", true);
                GameManager.Instance.gfAnim.SetBool("up", true);
                GameManager.Instance.score += GameManager.Instance.shitScore;
                GameManager.Instance.health -= GameManager.Instance.shitScore / 2;
                gameObject.SetActive(false);
                Instantiate(GameManager.Instance.shitObj, ratingPositionObject.transform.position, Quaternion.identity);
            }
            else if (gotShit && gotBad && !gotGood && !gotSick && Input.GetKeyDown(GameManager.Instance.up))
            {
                GameManager.Instance.bfAnim.SetBool("up", true);
                GameManager.Instance.gfAnim.SetBool("up", true);
                GameManager.Instance.score += GameManager.Instance.badScore;
                GameManager.Instance.health -= GameManager.Instance.badScore / 2;
                gameObject.SetActive(false);
                Instantiate(GameManager.Instance.badObj, ratingPositionObject.transform.position, Quaternion.identity);
            }
            else if (gotShit && gotBad && gotGood && !gotSick && Input.GetKeyDown(GameManager.Instance.up))
            {
                GameManager.Instance.bfAnim.SetBool("up", true);
                GameManager.Instance.gfAnim.SetBool("up", true);
                GameManager.Instance.score += GameManager.Instance.goodScore;
                GameManager.Instance.health += GameManager.Instance.goodScore / 2;
                gameObject.SetActive(false);
                Instantiate(GameManager.Instance.goodObj, ratingPositionObject.transform.position, Quaternion.identity);
            }
            else if (gotShit && gotBad && gotGood && gotSick && Input.GetKeyDown(GameManager.Instance.up))
            {
                GameManager.Instance.bfAnim.SetBool("up", true);
                GameManager.Instance.gfAnim.SetBool("up", true);
                GameManager.Instance.score += GameManager.Instance.sickScore;
                GameManager.Instance.health += GameManager.Instance.sickScore / 2;
                gameObject.SetActive(false);
                Instantiate(GameManager.Instance.sickObj, ratingPositionObject.transform.position, Quaternion.identity);
            }
        }

        #endregion
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Shit")) 
        {
            gotShit = true;
        }

        if (other.gameObject.CompareTag("Bad"))
        {
            gotBad = true;
        }

        if (other.gameObject.CompareTag("Good"))
        {
            gotGood = true;
        }

        if (other.gameObject.CompareTag("Sick"))
        {
            gotSick = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Shit"))
        {
            gotShit = false;
        }

        if (other.gameObject.CompareTag("Bad"))
        {
            gotBad = false;
        }

        if (other.gameObject.CompareTag("Good"))
        {
            gotGood = false;
        }

        if (other.gameObject.CompareTag("Sick"))
        {
            gotSick = false;
        }
    }
}
