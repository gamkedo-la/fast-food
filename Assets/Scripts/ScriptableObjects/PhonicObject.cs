using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "Phonic Object", menuName = "Scriptable Object/Phonic Object", order = 2)]
public class PhonicObject : ScriptableObject
{
    [Header("Typed Words")]
    public string character;

    [Header("Audio")]
    public AudioClip audio;
}
