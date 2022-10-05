using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseAudio : MonoBehaviour
{

    void Start()
    {
        BGMusicController.Instance.gameObject.GetComponent<AudioSource>().Stop();
    }
}

    
