using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [Header("Player Settings")]
    [SerializeField] public float playerVolume = 1f;

    [Header("Instancing")]
    [SerializeField] static public GameManager Instance;

    [Header("Input")]
    [SerializeField] public KeyCode left;
    [SerializeField] public KeyCode down;
    [SerializeField] public KeyCode up;
    [SerializeField] public KeyCode right;

    [Header("Animation")]
    [SerializeField] public Animator leftAnim;
    [SerializeField] public Animator rightAnim;
    [SerializeField] public Animator upAnim;
    [SerializeField] public Animator downAnim;
    [SerializeField] public Animator pauseAnim;

    [Space(10f)]

    [SerializeField] public Animator bfAnim;
    [SerializeField] public Animator gfAnim;

    [Header("Game State")]
    [SerializeField] public bool canPlay = false;
    [SerializeField] public bool pausedGame = false;
    [SerializeField] public int score = 0;
    [SerializeField] public int health = 50;

    [Space(10f)]

    [SerializeField] public int shitScore = -40;
    [SerializeField] public int badScore = -20;
    [SerializeField] public int goodScore = 20;
    [SerializeField] public int sickScore = 40;

    [Header("UI Elements")]
    [SerializeField] private GameObject pauseMenu;
    [SerializeField] private Slider healthSlider;
    [SerializeField] private float healthIncrementSmoothing = 20f;

    [Space(10f)]

    [SerializeField] private TextMeshProUGUI scoreString;
    [SerializeField] private TextMeshProUGUI accuracyString;
    [SerializeField] private TextMeshProUGUI ratingString;

    private void Awake()
    {
        Instance = this;

        if (SceneManager.GetActiveScene().name != "Menu") 
        {
            healthSlider = GameObject.Find("Health Slider").GetComponent<Slider>();
            scoreString = GameObject.Find("Score Text").GetComponent<TextMeshProUGUI>();
        }
    }

    void Update()
    {
        if (healthSlider == null) return;
        if (scoreString == null) return;

        if (SceneManager.GetActiveScene().name != "Menu") 
        {
            CheckForPauseInput();

            if (Input.GetKeyDown(KeyCode.T))
            {
                canPlay = true;
                GameObject.FindGameObjectWithTag("Main Music Source").GetComponent<AudioSource>().volume = GameManager.Instance.playerVolume;
                GameObject.FindGameObjectWithTag("Main Music Source").GetComponent<AudioSource>().Play();
            }
        }

        HealthSlider();
        ScoreText();
    }

    private void CheckForPauseInput() 
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !pausedGame) PauseGame();
        else if (Input.GetKeyDown(KeyCode.Escape) && pausedGame) UnPauseGame();
    }

    public void PauseGame() 
    {
        pausedGame = true;
        canPlay = false;
        Time.timeScale = 0f;
        AudioSource music = GameObject.FindGameObjectWithTag("Main Music Source").GetComponent<AudioSource>();
        music.Pause();
        pauseAnim.SetBool("paused", true);
    }

    public void UnPauseGame()
    {
        pausedGame = false;
        canPlay = true;
        Time.timeScale = 1f;
        AudioSource music = GameObject.FindGameObjectWithTag("Main Music Source").GetComponent<AudioSource>();
        music.Play();
        pauseAnim.SetBool("paused", false);
    }

    public void LoadGame() 
    {
        Loader loaderScript = GameObject.Find("Loader").GetComponent<Loader>();

        loaderScript.Play();
    }

    public void LoadMenu()
    {
        Time.timeScale = 1f;
        Loader loaderScript = GameObject.Find("Loader").GetComponent<Loader>();

        loaderScript.ToMenu();
    }

    private void HealthSlider()
    {
        health = Mathf.Clamp(health, 0, 100);
        healthSlider.value = Mathf.Lerp(healthSlider.value, health, healthIncrementSmoothing * Time.deltaTime);
    }

    private void ScoreText() 
    {
        score = Mathf.Clamp(score, 0, score);
        scoreString.text = "Score: " + score.ToString();
    }
}
