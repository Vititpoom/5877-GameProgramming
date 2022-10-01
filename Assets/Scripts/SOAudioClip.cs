using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "Audio", fileName = "New AudioClip")]
public class SOAudioClip : ScriptableObject
{
    [SerializeField] private AudioClip[] audioClips;

    public AudioClip GetAudioClip()
    {
        var totalAudioClip = audioClips.Length;
        int index;
        switch (totalAudioClip)
        {
            case 1:
                index = 0;
                break;
            default:
                index = Random.Range(0, totalAudioClip);
                break;
                        
        }

        return audioClips[index];
    }
}
