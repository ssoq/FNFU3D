using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Loader : MonoBehaviour
{
    [Header("Animations")]
    [SerializeField] private Animator loadAnim;

    [Header("Music")]
    [SerializeField] private AudioSource mainAudio;

    [Header("Scenes To Load")]
    [SerializeField] public string nextSceneName;

    void Awake()
    {
        loadAnim = GetComponent<Animator>();

        GameObject[] loaderObjs = GameObject.FindGameObjectsWithTag("Loader");

        if (loaderObjs.Length > 1) 
        {
            Destroy(loaderObjs[1]);
        }

        DontDestroyOnLoad(GameObject.Find("Loader Canvas"));
        if (loadAnim != null) loadAnim.SetBool("toLoad", true);
        mainAudio = GameObject.FindGameObjectWithTag("Main Music Source").GetComponent<AudioSource>();
    }

    void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (loadAnim != null) StartCoroutine(LoaderWait());
    }

    // animation event for animation, duh
    public void CheckForLoad() 
    {
        StartCoroutine(MusicVolumeDown());
    }

    public void CheckForUnLoad()
    {
        StartCoroutine(MusicVolumeUp());
    }

    public void ToMenu() 
    {
        StartCoroutine(LoadSceneMenu()); // callable for buttons within UI
    }

    public void Play() 
    {
        StartCoroutine(LoadScene());
    }

    private IEnumerator LoadScene() 
    {
        if (loadAnim != null) loadAnim.SetBool("toLoad", true);
        StartCoroutine(MusicVolumeDown());

        yield return new WaitForSeconds(2f);

        SceneManager.LoadScene(nextSceneName);
    }

    private IEnumerator LoadSceneMenu()
    {
        if (loadAnim != null) loadAnim.SetBool("toLoad", true);
        StartCoroutine(MusicVolumeDown());

        yield return new WaitForSeconds(2f);

        SceneManager.LoadScene("Menu");
    }

    private IEnumerator LoaderWait() 
    {
        yield return new WaitForSeconds(2f);

        if (loadAnim != null) loadAnim.SetBool("toLoad", false);
    }

    private IEnumerator MusicVolumeUp() 
    {
        yield return new WaitUntil(() => !loadAnim.GetBool("toLoad"));

        mainAudio = GameObject.FindGameObjectWithTag("Main Music Source").GetComponent<AudioSource>();

        yield return new WaitUntil(() => mainAudio != null);

        if (mainAudio != null) mainAudio.Play();
        if (mainAudio != null) mainAudio.volume = GameManager.Instance.playerVolume;
        GameManager.Instance.canPlay = true;

        yield return new WaitUntil(() => mainAudio.volume == GameManager.Instance.playerVolume);
    }

    private IEnumerator MusicVolumeDown()
    {
        yield return new WaitUntil(() => loadAnim.GetBool("toLoad"));
        GameManager.Instance.canPlay = false;

        if (mainAudio != null) mainAudio.Pause();
    }
}