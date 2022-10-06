using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAudioController : MonoBehaviour
{

    [SerializeField] private AudioSource audioSource;
    [SerializeField] private SOAudioClip jumpAudioClip;
    [SerializeField] private SOAudioClip walkAudioClip;
    [SerializeField] private SOAudioClip collectAudioClip;
    [SerializeField] private SOAudioClip respawnAudioClip;
    [SerializeField] private SOAudioClip deathAudioClip;
    [SerializeField] private SOAudioClip jumpPadAudioClip;
    [SerializeField] private SOAudioClip winningAudioClip;
    [SerializeField] private SOAudioClip fallingAudioClip;


    public void PlayJumpSound()
    {
        audioSource.PlayOneShot(jumpAudioClip.GetAudioClip());
    }

    public void PlayWalkSound()
    {
        audioSource.PlayOneShot(walkAudioClip.GetAudioClip());
    }

    public void PlayCollectSound()
    {
        audioSource.PlayOneShot(collectAudioClip.GetAudioClip());
    }
    public void PlayRespawnSound()
    {
        audioSource.PlayOneShot(respawnAudioClip.GetAudioClip());
    }

    public void PlayDeathSound()
    {
        audioSource.PlayOneShot(deathAudioClip.GetAudioClip());
    }
    public void PlayJumpPadSound()
    {
        audioSource.PlayOneShot(jumpPadAudioClip.GetAudioClip());
    }
    public void PlayWinningSound()
    {
        audioSource.PlayOneShot(winningAudioClip.GetAudioClip());
    }
    public void PlayFallingSound()
    {
        audioSource.PlayOneShot(fallingAudioClip.GetAudioClip());
    }
}
