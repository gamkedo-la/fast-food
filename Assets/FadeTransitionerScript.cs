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

    // Start is called before the first frame update
    void Start()
    {
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
                Debug.Log("inside Update() of fadeTransitioner in Gameplay scene and isFadingOut");
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
            }
            else if (isTransitioningAScene)
            {
               // Debug.Log("should be loading scene");
                currentLoadSceneButtonScript.LoadScene();
            }
            isFadingIn = true;
        }
    }

    public void FadeIn()
    {
        Time.timeScale = 1;
        blackFadeImageTemporaryColor = blackFadeImage.color;
        blackFadeImageTemporaryColor.a -= Time.deltaTime * 2;
        blackFadeImage.color = blackFadeImageTemporaryColor;

        if (blackFadeImage.color.a <= 0)
        {
            isFadingIn = false;
        }

        isTransitioningACanvas = false;
        isTransitioningAScene = false;
    }
}
