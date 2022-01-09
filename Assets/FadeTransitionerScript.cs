using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class FadeTransitionerScript : MonoBehaviour
{
    public Image blackFadeImage;
    private Color blackFadeImageTemporaryColor;


    public bool isFadingOut;
    public bool isFadingIn;

    public bool isTransitioningACanvas;
    public bool isTransitioningAScene;

    public ToggleOnButtonScript currentToggleOnButtonScript;
    public LoadSceneButtonScript currentLoadSceneButtonScript;

    public bool firstFrameAfterSceneLoadHasPassed = false;
    public bool hasEnteredGameplayScene = false;
    private void Awake()
    {
        //SceneManager.sceneLoaded += OnSceneLoaded;
    }
    // Start is called before the first frame update
    void Start()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
        DontDestroyOnLoad(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        //if (SceneManager.GetActiveScene().name == "Gameplay")
        //{
        //    Debug.Log("inside Update() of fadeTransitioner in Gameplay scene");
        //}
        if (isFadingOut)
        {
            if (SceneManager.GetActiveScene().name == "Gameplay")
            {
                //Debug.Log("inside Update() of fadeTransitioner in Gameplay scene and isFadingOut");
            }
            FadeOutAndToggleAndTriggerFadeIn();
        }

        if (isFadingIn)
        {
            FadeIn();
        }
    }

    public void FadeOutAndToggleAndTriggerFadeIn()
    {
        
        Time.timeScale = 1;
        blackFadeImageTemporaryColor = blackFadeImage.color;
        blackFadeImageTemporaryColor.a += Time.deltaTime * 2;
        blackFadeImage.color = blackFadeImageTemporaryColor;

        //if (isTransitioningAScene)
        //{
        //    Debug.Log("blackFadeImage.color.a: " + blackFadeImage.color.a);
        //}

        if (blackFadeImage.color.a >= 1)
        {
            //if (SceneManager.GetActiveScene().name == "Gameplay")
            //{
            //    Debug.Log("inside FadeOutAndToggleAndTriggerFadeIn()");
            //}
            isFadingOut = false;
            if (isTransitioningACanvas)
            {
                currentToggleOnButtonScript.ToggleOff();
                currentToggleOnButtonScript.ToggleOn();
                isFadingIn = true;
            }
            else if (isTransitioningAScene)
            {
                //Debug.Log("inside is transitioning a scene after fadeOut");
                isFadingIn = true;
                currentLoadSceneButtonScript.LoadScene();
            }
            
        }
    }

    public void FadeIn()
    {
        if (isTransitioningAScene && !firstFrameAfterSceneLoadHasPassed)
        {
            //Debug.Log("inside first frame check");
            firstFrameAfterSceneLoadHasPassed = true;
            return;
        }
        
        //if (SceneManager.GetActiveScene().name == "Gameplay")
        //{
        //    Debug.Log("blackFadeImageTemporaryColor.a: " + blackFadeImageTemporaryColor.a);
        //}
        Time.timeScale = 1;
        blackFadeImageTemporaryColor = blackFadeImage.color;
        blackFadeImageTemporaryColor.a -= Time.deltaTime * 2;
        blackFadeImage.color = blackFadeImageTemporaryColor;

        if (blackFadeImage.color.a <= 0)
        {
            isFadingIn = false;
            isTransitioningACanvas = false;
            isTransitioningAScene = false;
            firstFrameAfterSceneLoadHasPassed = false;
            if (!GameManagerScript.introducingANewWord && GameObject.Find("RewardCanvas") == null &&
                GameObject.Find("StatsCanvas") == null)
            {
                GameManagerScript.extraPauseForTransitions = false;
            }
        }

        
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        //Debug.Log("blackFadeImage.color :" + blackFadeImage.color);
        isFadingIn = true;
        isTransitioningAScene = true;
        firstFrameAfterSceneLoadHasPassed = false;
        
        //GameManagerScript.extraPauseForTransitions = false;
        //blackFadeImageTemporaryColor = blackFadeImage.color;
        //blackFadeImageTemporaryColor.a = 1.0f;
        //blackFadeImage.color = blackFadeImageTemporaryColor;
        //isFadingIn = true;
        //isTransitioningAScene = true;
    }
}
