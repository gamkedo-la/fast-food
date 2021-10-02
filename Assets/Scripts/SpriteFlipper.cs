using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteFlipper : MonoBehaviour
{
    public float minFrametime = 0.25f;
    public float maxFrametime = 1.5f;
    public bool oddFramesBlinkFast = true;
    public Sprite[] mySprites;
    
    private SpriteRenderer flipMe;
    private int spriteIndex = 0;
    
    // Start is called before the first frame update
    void Start()
    {
        flipMe = gameObject.GetComponent<SpriteRenderer>();
        spriteIndex = Random.Range(0,mySprites.Length-1);
        StartCoroutine(flippingSprite());    
    }

    IEnumerator flippingSprite() {
        while(true) { // forever

            float sec = Random.Range(minFrametime,maxFrametime);
            
            // odd frames are FAST BLINKS!
            if (oddFramesBlinkFast && (spriteIndex%2==1)) sec = 0.1f;

            yield return new WaitForSeconds(sec);
            
            spriteIndex++;
            //Debug.Log("Flipping sprite index: "+spriteIndex);
            if (spriteIndex>mySprites.Length-1) spriteIndex = 0;
            flipMe.sprite = mySprites[spriteIndex];
            
        }
    }

}
