using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Cysharp.Threading.Tasks;
using UnityEngine.SceneManagement;

public enum eGameStates
{
    STARTUP,
    HOME,
    GAME_VILLAGE,
    GAME_HOUSE
}

public class GameManager : MonoBehaviour
{
    private static GameManager instance;
    public static GameManager INSTANCE { get { return instance; } }

    public bool isGamePaused { get; private set; }
    public  bool isOnTutorial { get; private set; }
    public eGameStates currentGameState { get; private set; }

    private int frameRate = 60;


    [Header("Loading Screens")]
    public GameObject[] loadingScreens;
    // Selected Loading Screen
    private GameObject loadingScreen;
    private TMP_Text progressText;
    private Slider progressBar;
    private float target;


    private void Awake()
    {
        if(instance != null && instance != this)
        {
            this.gameObject.DestroyObject();
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(this);
            StartCurrentStatateBehaviour();
        }

        foreach (var screen in loadingScreens)
        {
            screen.SetActive(false);
        }
    }

    private void Start()
    {
        Application.targetFrameRate = frameRate;
    }

    private void Update()
    {
        if(loadingScreen != null)
        {
            progressBar.value = Mathf.MoveTowards(progressBar.value, target, 3 * Time.deltaTime);
            progressText.text = $"{target * 100}";
        }
    }

    public void SetNewGameState(eGameStates newState)
    {
        EndCurrentStatateBehaviour();
        currentGameState = newState;
        StartCurrentStatateBehaviour();
    }

    private void StartCurrentStatateBehaviour()
    {
        switch (currentGameState)
        {
            case eGameStates.STARTUP:
                LoadScene("Home", 0);
                break;
            case eGameStates.HOME:
                LoadScene("Home", 0);
                break;
            case eGameStates.GAME_VILLAGE:
                SceneManager.LoadScene("Gameplay_Village");
                break;
            case eGameStates.GAME_HOUSE:
                SceneManager.LoadScene("Gameplay_PlayerHouse");
                break;
        }
    }

    private void EndCurrentStatateBehaviour()
    {
        switch (currentGameState)
        {
            case eGameStates.STARTUP:
                break;
            case eGameStates.HOME:
                break;
            case eGameStates.GAME_VILLAGE:
                break;
            case eGameStates.GAME_HOUSE:
                break;
        }
    }

    public void PauseGame(bool wantToPause)
    {
        isGamePaused = wantToPause;
        Time.timeScale = isGamePaused ? 0 : 1;
    }

    public void SetLoadingScreen(int index)
    {
        loadingScreen = loadingScreens[index];
        progressBar = loadingScreens[index].GetComponentInChildren<Slider>();
        progressText = loadingScreens[index].GetComponentInChildren<TMP_Text>();
    }

    public async void LoadScene(string sceneName, int loadingScreenIndex)
    {
        SetLoadingScreen(loadingScreenIndex);

        target = 0;
        progressBar.value = 0;
        progressText.text = "0%";

        var scene = SceneManager.LoadSceneAsync(sceneName);
        scene.allowSceneActivation = false;

        loadingScreen.SetActive(true);

        do
        {
            await UniTask.Delay(200);
            target = scene.progress;
        } while (scene.progress < 0.9f);

        await UniTask.Delay(2000);
        target = scene.progress;
        await UniTask.Delay(2000);

        scene.allowSceneActivation = true;

        do
        {
            await UniTask.Delay(200);
        } while (scene.isDone);

        target = 1;

        await UniTask.Delay(1000);
        loadingScreen.SetActive(false);


    }


}
