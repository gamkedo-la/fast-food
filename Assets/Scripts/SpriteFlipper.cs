using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteFlipper : MonoBehaviour
{
    public float minFrametime = 0.25f;
    public float maxFrametime = 1.5f;
    public bool oddFramesBlinkFast = true;
    public bool iAmBlinking = false;
    public float walkingTimeFrame = 0.2f;

    public float timeRemainingUntilNextSpriteFlip;
    public float longDurationOfSpriteFlip;//starts by walking

    [Header("When customer is happy")]
    public Sprite[] mySprites;

    [Header("When waiting too long")]
    public Sprite[] impatientSprites;

    [Header("When walking")]
    public Sprite[] walkingSprites;

    [Header("Rotated Rainbow Shirt Sprites")]
    public Sprite[] rotatedRainbowShirtSprites;

    public Sprite[] currentArrayOfSprites;

    private SpriteRenderer baseCustomerSpriteRenderer;
    public int spriteIndex = 0;
    private bool wasImpatientLastFrame = false;

    private CustomerOrderingScript myOrderingScript;

    [SerializeField] GameObject rainbowShirt;
    private SpriteRenderer rainbowShirtSpriteRenderer;
    [SerializeField] Sprite nonWalkingRainbowShirtSprite;
    
    // Start is called before the first frame update
    void Start()
    {
        spriteIndex = 0;
        longDurationOfSpriteFlip = walkingTimeFrame;
        currentArrayOfSprites = walkingSprites;

        baseCustomerSpriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        rainbowShirtSpriteRenderer = rainbowShirt.GetComponent<SpriteRenderer>();
        myOrderingScript = gameObject.GetComponent<CustomerOrderingScript>();   
        
        //StartCoroutine(flippingSprite());  
    }

    private void Update()
    {
        timeRemainingUntilNextSpriteFlip -= Time.deltaTime;

        if (timeRemainingUntilNextSpriteFlip <= 0)
        {
            spriteIndex++;

            timeRemainingUntilNextSpriteFlip = longDurationOfSpriteFlip;

            if (iAmBlinking)
            {
                iAmBlinking = false;
            }


            else if (myOrderingScript.myStateEnumeration == CustomerStateEnumerations.WaitingForMyOrder &&
                     spriteIndex % 2 == 1 &&
                     !iAmBlinking)
            {
                //blink fast
                timeRemainingUntilNextSpriteFlip = 0.1f;
                iAmBlinking = true;
            }

        }

        if (spriteIndex >= currentArrayOfSprites.Length)
        {
            spriteIndex = 0;
        }

        baseCustomerSpriteRenderer.sprite = currentArrayOfSprites[spriteIndex];

        if (myOrderingScript.myStateEnumeration != CustomerStateEnumerations.WaitingForMyOrder)
        {
            rainbowShirtSpriteRenderer.sprite = rotatedRainbowShirtSprites[spriteIndex];
        }
        else
        {
            rainbowShirtSpriteRenderer.sprite = nonWalkingRainbowShirtSprite;
        }  
    }

    IEnumerator flippingSprite() 
    {
        while(true) 
        { // forever

            float sec;

            if (myOrderingScript.myStateEnumeration != CustomerStateEnumerations.WaitingForMyOrder)
            {
                sec = 0.2f;
            }
            else
            {
                sec = Random.Range(minFrametime, maxFrametime);

                // odd frames are FAST BLINKS!
                if (oddFramesBlinkFast && (spriteIndex % 2 == 1)) sec = 0.1f;
            }

            yield return new WaitForSeconds(sec);
            
            spriteIndex++;
            //Debug.Log("Flipping sprite index: "+spriteIndex);

            if (myOrderingScript.myStateEnumeration != CustomerStateEnumerations.WaitingForMyOrder)
            {
                if (spriteIndex > walkingSprites.Length - 1) spriteIndex = 0;
                baseCustomerSpriteRenderer.sprite = walkingSprites[spriteIndex];
                rainbowShirtSpriteRenderer.sprite = rotatedRainbowShirtSprites[spriteIndex];
            }
            else if (myOrderingScript.losingPatience) 
            {
                // IMPATIENT SPRITES
                if (!wasImpatientLastFrame) spriteIndex = 0; // start at frame 1
                if (spriteIndex>impatientSprites.Length-1) spriteIndex = 0;
                baseCustomerSpriteRenderer.sprite = impatientSprites[spriteIndex];
                wasImpatientLastFrame = true;
                rainbowShirtSpriteRenderer.sprite = nonWalkingRainbowShirtSprite;            
            }
            else if (myOrderingScript.myStateEnumeration == CustomerStateEnumerations.WaitingForMyOrder)
            {
                // NORMAL HAPPY SPRITES
                if (wasImpatientLastFrame) spriteIndex = 0; // start at frame 1
                if (spriteIndex>mySprites.Length-1) spriteIndex = 0;
                baseCustomerSpriteRenderer.sprite = mySprites[spriteIndex];
                wasImpatientLastFrame = false;
                rainbowShirtSpriteRenderer.sprite = nonWalkingRainbowShirtSprite;
            }//end of WaitingForMyOrder enum check
        }//end of while loop
    }//end of sprite flip Ienumerator
}//ebd of class
