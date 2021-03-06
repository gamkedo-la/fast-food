using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "Word Object", menuName = "Scriptable Object/Word Object", order = 0)]
public class WordObject : ScriptableObject
{
    [Header("Typed Words")]
    public string englishWord;
    public string albanianWord;
    public string georgianWord;
    public string turkishWord;

    [Header("Image File")]
    public Sprite sprite;

    [Header("Audio")]
    public AudioClip englishAudio;
    public AudioClip albanianAudio;
    public AudioClip georgianAudio;
    public AudioClip turkishAudio;
}
