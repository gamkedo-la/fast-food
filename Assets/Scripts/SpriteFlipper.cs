using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteFlipper : MonoBehaviour
{
    public float minFrametime = 0.25f;
    public float maxFrametime = 1.5f;
    public bool oddFramesBlinkFast = true;
    
    [Header("When customer is happy")]
    public Sprite[] mySprites;

    [Header("When waiting too long")]
    public Sprite[] impatientSprites;

    private SpriteRenderer flipMe;
    private int spriteIndex = 0;
    private bool wasImpatientLastFrame = false;

    private CustomerOrderingScript myOrderingScript;
    
    // Start is called before the first frame update
    void Start()
    {
        flipMe = gameObject.GetComponent<SpriteRenderer>();
        myOrderingScript = gameObject.GetComponent<CustomerOrderingScript>();   
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

            if (myOrderingScript.losingPatience) {
                // IMPATIENT SPRITES
                if (!wasImpatientLastFrame) spriteIndex = 0; // start at frame 1
                if (spriteIndex>impatientSprites.Length-1) spriteIndex = 0;
                flipMe.sprite = impatientSprites[spriteIndex];
                wasImpatientLastFrame = true;
            } else {
                // NORMAL HAPPY SPRITES
                if (wasImpatientLastFrame) spriteIndex = 0; // start at frame 1
                if (spriteIndex>mySprites.Length-1) spriteIndex = 0;
                flipMe.sprite = mySprites[spriteIndex];
                wasImpatientLastFrame = false;
            }

            
        }
    }

}
