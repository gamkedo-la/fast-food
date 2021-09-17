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
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Chef" && GameManagerScript.chefHasBurger)
        {
            GameManagerScript.burgerHasLettuce = true;
            lettuceOnBurgerSpriteRenderer.enabled = true;
            fullHeadOfLettuceSpriteRenderer.enabled = false;
            Camera.main.GetComponent<AudioSource>().PlayOneShot(LanguageDictionary.audioLanguageDictionary[GameManagerScript.currentLanguage]["lettuce pickup"]);
        }
    }
}
