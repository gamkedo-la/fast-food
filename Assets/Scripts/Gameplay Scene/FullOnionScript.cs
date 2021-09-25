using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FullOnionScript : MonoBehaviour
{
    private GameObject onionOnBurgerGameObject;
    private SpriteRenderer onionOnBurgerSpriteRenderer;
    private SpriteRenderer fullOnionSpriteRenderer;

    private void Start()
    {
        onionOnBurgerGameObject = GameObject.FindGameObjectWithTag("OnionOnBurger");
        onionOnBurgerSpriteRenderer = onionOnBurgerGameObject.GetComponent<SpriteRenderer>();
        fullOnionSpriteRenderer = gameObject.GetComponent<SpriteRenderer>();

        EventManagerScript.AddEventHandlerToTargetEvent(EventManagerScript.anyBurgerSubmissionEvent, Reappear);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Chef" && GameManagerScript.chefHasBurger)
        {
            GameManagerScript.burgerHasOnion = true;
            onionOnBurgerSpriteRenderer.enabled = true;
            fullOnionSpriteRenderer.enabled = false;
            Camera.main.GetComponent<AudioSource>().PlayOneShot(LanguageDictionary.audioLanguageDictionary[GameManagerScript.currentLanguage]["onion pickup"]);
        }
    }

    private void Reappear()
    {
        fullOnionSpriteRenderer.enabled = true;
    }
}
