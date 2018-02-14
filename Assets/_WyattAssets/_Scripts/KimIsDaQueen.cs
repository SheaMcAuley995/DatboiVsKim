using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KimIsDaQueen : MonoBehaviour
{
    public GameObject kim;
    public AudioSource audio;
    public AudioClip aaaclip;

    void Start ()
    {
        audio = GetComponent<AudioSource>();
    }
	
	void Update ()
    {
        kim = GameObject.FindGameObjectWithTag("Kim");
        if(kim == null)
        {
            if (audio.isPlaying == false)
            {
                audio.PlayOneShot(aaaclip);
            }
        }
	}
}
