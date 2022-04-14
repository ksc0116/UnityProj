using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    private AudioSource audio;
    public AudioSource Audio {  get { return audio; } }

    private void Awake()
    {
        audio = GetComponent<AudioSource>();
    }

    [Header("Clip")]
    [SerializeField]
    private  AudioClip step;
    [SerializeField]
    private AudioClip jump;


    public AudioClip Step {  get { return step; } } 
    public AudioClip Jump { get { return jump; } }
}
