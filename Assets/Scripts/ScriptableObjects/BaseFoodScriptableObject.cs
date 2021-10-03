using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Base Food Scriptable Object", menuName = "Scriptable Object/Base Food", order = 1)]

public class BaseFoodScriptableObject : ScriptableObject
{
    [Header("English Word")]
    public string englishWord;

    [Header("Base Food Image")]
    public Sprite baseFoodImage;

    [Header("Base Food Image 2")]
    public Sprite baseFoodImage2;

    [Header("Topping 1 Image")]
    public Sprite topping1Image;

    [Header("Topping 2 Image")]
    public Sprite topping2Image;

    [Header("Topping 3 Image")]
    public Sprite topping3Image;
}
