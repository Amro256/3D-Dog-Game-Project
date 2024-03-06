using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManger : MonoBehaviour
{
    AudioSource audioSource;
    public AudioClip bonecollect;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    public void boneSound()
    {
        audioSource.PlayOneShot(bonecollect, 0.7f);
    }
}
