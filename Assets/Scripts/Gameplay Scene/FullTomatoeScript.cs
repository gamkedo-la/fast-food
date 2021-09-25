using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FullTomatoeScript : MonoBehaviour
{
    private GameObject tomatoeOnBurgerGameObject;
    private SpriteRenderer tomatoeOnBurgerSpriteRenderer;
    private SpriteRenderer fullTomatoeSpriteRenderer;

    private void Start()
    {
        tomatoeOnBurgerGameObject = GameObject.FindGameObjectWithTag("TomatoeOnBurger");
        tomatoeOnBurgerSpriteRenderer = tomatoeOnBurgerGameObject.GetComponent<SpriteRenderer>();
        fullTomatoeSpriteRenderer = gameObject.GetComponent<SpriteRenderer>();

        EventManagerScript.AddEventHandlerToTargetEvent(EventManagerScript.anyBurgerSubmissionEvent, Reappear);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Chef" && GameManagerScript.chefHasBurger)
        {
            GameManagerScript.burgerHasTomatoe = true;
            tomatoeOnBurgerSpriteRenderer.enabled = true;
            fullTomatoeSpriteRenderer.enabled = false;
            Camera.main.GetComponent<AudioSource>().PlayOneShot(LanguageDictionary.audioLanguageDictionary[GameManagerScript.currentLanguage]["tomatoe pickup"]);
        }
    }

    private void Reappear()
    {
        fullTomatoeSpriteRenderer.enabled = true;
    }
}
