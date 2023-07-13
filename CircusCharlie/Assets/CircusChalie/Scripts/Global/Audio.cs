using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audio : MonoBehaviour
{
    public AudioClip bgmClip;
    public AudioClip jumpClip;
    public AudioClip coinClip;
    public AudioClip dieClip;

    private AudioSource audioSource;


    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = bgmClip;
    }
    public void PlayMusic()
    {
        // audioSource.Play(); // 노래 재생
    }


    public void JumpSound()
    {
        audioSource.PlayOneShot(jumpClip);
    }

    public void CoinSound()
    {
        audioSource.PlayOneShot(coinClip);
    }
    public void DieSound()
    {
        audioSource.clip = dieClip;
        audioSource.Play();
    }
   

}
