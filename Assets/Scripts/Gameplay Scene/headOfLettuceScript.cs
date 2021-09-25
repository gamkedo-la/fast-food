using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class headOfLettuceScript : MonoBehaviour
{
    private GameObject lettuceOnBurgerGameObject;
    private SpriteRenderer lettuceOnBurgerSpriteRenderer;
    private SpriteRenderer fullHeadOfLettuceSpriteRenderer;

    private void Start()
    {
        lettuceOnBurgerGameObject = GameObject.FindGameObjectWithTag("LettuceOnBurger");
        lettuceOnBurgerSpriteRenderer = lettuceOnBurgerGameObject.GetComponent<SpriteRenderer>();
        fullHeadOfLettuceSpriteRenderer = gameObject.GetComponent<SpriteRenderer>();

        EventManagerScript.AddEventHandlerToTargetEvent(EventManagerScript.anyBurgerSubmissionEvent, Reappear);
        EventManagerScript.AddEventHandlerToTargetEvent(EventManagerScript.chefPicksUpLettuceEvent, HandleChefPicksUpLettuce);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Chef" && GameManagerScript.chefHasBurger)
        {
            lettuceOnBurgerSpriteRenderer.enabled = true;
            EventManagerScript.chefPicksUpLettuceEvent.Invoke();
        }
    }

    private void HandleChefPicksUpLettuce()
    {
        GameManagerScript.burgerHasLettuce = true;
        Disappear();
        Camera.main.GetComponent<AudioSource>().PlayOneShot(LanguageDictionary.audioLanguageDictionary[GameManagerScript.currentLanguage]["lettuce pickup"]);
    }

    private void Disappear()
    {
        fullHeadOfLettuceSpriteRenderer.enabled = false;
    }

    private void Reappear()
    {
        fullHeadOfLettuceSpriteRenderer.enabled = true;
    }
}
