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

    [Header("Rating Objects")]
    [SerializeField] public GameObject shitObj;
    [SerializeField] public GameObject badObj;
    [SerializeField] public GameObject goodObj;
    [SerializeField] public GameObject sickObj;

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
    [SerializeField] public Animator focusAnim;
    [SerializeField] public Animation worldSpaceDeathCuller;
    [SerializeField] public Animation gameUIFade;

    [Space(10f)]

    [SerializeField] public Animator bfAnim;
    [SerializeField] public Animator gfAnim;
    [SerializeField] public Animator oponentAnim;

    [Header("Game State")]
    [SerializeField] public bool canPlay = false;
    [SerializeField] public bool dead = false;
    [SerializeField] public bool pausedGame = false;
    [SerializeField] public int score = 0;
    [SerializeField] public int health = 100;

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
        Screen.SetResolution(550, 300, FullScreenMode.FullScreenWindow);
        Application.targetFrameRate = 80;

        Instance = this;

        if (SceneManager.GetActiveScene().name != "Menu") 
        {
            healthSlider = GameObject.Find("Health Slider").GetComponent<Slider>();
            scoreString = GameObject.Find("Score Text").GetComponent<TextMeshProUGUI>();
            worldSpaceDeathCuller = GameObject.FindGameObjectWithTag("World Death Cull").GetComponent<Animation>();
            gameUIFade = GameObject.FindGameObjectWithTag("Game UI").GetComponent<Animation>();
        }
    }

    void Update()
    {
        if (healthSlider == null) return;
        if (scoreString == null) return;

        #region allows user to start song without loader in scene

        if (SceneManager.GetActiveScene().name != "Menu")
        {
            CheckForPauseInput();

            if (Input.GetKeyDown(KeyCode.T) && !dead)
            {
                canPlay = true;
                GameObject.FindGameObjectWithTag("Main Music Source").GetComponent<AudioSource>().volume = GameManager.Instance.playerVolume;
                GameObject.FindGameObjectWithTag("Main Music Source").GetComponent<AudioSource>().Play();
            }
        }

        #endregion

        HealthSlider();
        ScoreText();
        ReleaseAnimationStates();
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

    private void ReleaseAnimationStates() 
    {
        #region Releasing BF & GF Animation States

        if (SceneManager.GetActiveScene().name == "Menu") return;

        if (!Input.GetKey(left))
        {
            bfAnim.SetBool("left", false);
            gfAnim.SetBool("left", false);
        }
        if (!Input.GetKey(right))
        {
            bfAnim.SetBool("right", false);
            gfAnim.SetBool("right", false);
        }
        if (!Input.GetKey(down))
        {
            bfAnim.SetBool("down", false);
            gfAnim.SetBool("down", false);
        }
        if (!Input.GetKey(up))
        {
            bfAnim.SetBool("up", false);
            gfAnim.SetBool("up", false);
        }

        #endregion
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

    public void ReloadScene()
    {
        Loader loaderScript = GameObject.Find("Loader").GetComponent<Loader>();
        loaderScript.nextSceneName = SceneManager.GetActiveScene().name;

        loaderScript.Play();
    }

    public void LoadEggnog() 
    {
        Loader loaderScript = GameObject.Find("Loader").GetComponent<Loader>();
        loaderScript.nextSceneName = "Eggnog";

        loaderScript.Play();
    }

    public void LoadLitup()
    {
        Loader loaderScript = GameObject.Find("Loader").GetComponent<Loader>();
        loaderScript.nextSceneName = "2hot Erect";

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

        if (health <= 0 && !dead)
        {
            Debug.Log("Dead");
            StartCoroutine(DeathSequence());
            dead = true;
        }
    }

    private void ScoreText() 
    {
        score = Mathf.Clamp(score, 0, score);
        scoreString.text = "Score: " + score.ToString();
    }

    private IEnumerator DeathSequence() 
    {
        bfAnim.SetTrigger("dead");
        worldSpaceDeathCuller.Play();
        gameUIFade.Play();
        canPlay = false;
        AudioSource music = GameObject.FindGameObjectWithTag("Main Music Source").GetComponent<AudioSource>();
        AudioSource deathSound = GameObject.FindGameObjectWithTag("Death Audio Source").GetComponent<AudioSource>();
        music.Stop();
        music.volume = 0;
        deathSound.Play();

        yield return new WaitUntil(() => !deathSound.isPlaying);

        AudioSource deathMusic = GameObject.FindGameObjectWithTag("Death Music Source").GetComponent<AudioSource>();
        deathMusic.Play();

        yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.Space));

        bfAnim.SetTrigger("deadRetry");
        deathMusic.Stop();
        AudioSource retryMusic = GameObject.FindGameObjectWithTag("Retry Music").GetComponent<AudioSource>();
        retryMusic.Play();

        yield return new WaitUntil(() => !retryMusic.isPlaying);

        ReloadScene();

        StopCoroutine(DeathSequence());
    }
}
