using DG.Tweening;
using System.ComponentModel;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    [SerializeField] private LivesDisplay LivesDisplay; 
    [SerializeField] private int lives = 3;

    [SerializeField] private AudioSource _audioControl;
    [SerializeField] private SOAudioClip _winingClip;
    [SerializeField] private SOAudioClip _deathClip;
    


    // Simple singleton script. This is the easiest way to create and understand a singleton script.

    private void Awake()
    {
        var numGameManager = FindObjectsOfType<GameManager>().Length;

        if (numGameManager > 1)
        {

            Destroy(gameObject);
        }
        else
        {
            LivesDisplay.UpdateLives(lives);
            DontDestroyOnLoad(gameObject);
        }
    }
    
    public void ProcessPlayerDeath()
    {
        DeathSound();
        SceneManager.LoadScene(GetCurrentBuildIndex());
    }

    public void LoadNextLevel()
    {
        var nextSceneIndex = GetCurrentBuildIndex() + 1;
        
        if (nextSceneIndex == SceneManager.sceneCountInBuildSettings)
        {
            nextSceneIndex = 0;
        }

        LoadScene(nextSceneIndex);
        
        

    }

    private int GetCurrentBuildIndex()
    {
        return SceneManager.GetActiveScene().buildIndex;
    }

    public void LoadScene(int buildIndex)
    {
        if (buildIndex == 0)
        {
            SceneManager.LoadScene(buildIndex);
            Destroy(gameObject);
            DOTween.KillAll();
        }
        else
        {
            SceneManager.LoadScene(buildIndex);
            DOTween.KillAll();
        }
        
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void MainMenu()
    {
        LoadScene(0);
        BGMusicController.Instance.gameObject.GetComponent<AudioSource>().Play();
        Destroy(gameObject);
    }

 
    public void DamagePlayer()
    {
        lives -= 1;
        
        if (lives == 0)
        {
            SceneManager.LoadScene(0);
            Destroy(gameObject);
            BGMusicController.Instance.gameObject.GetComponent<AudioSource>().Pause();
            DOTween.KillAll();
        }
        else
        {
           ProcessPlayerDeath();
        }
        UpdateLives();
    }

    private void UpdateLives()
    {
        LivesDisplay.UpdateLives(lives);
    }

    public void WinSound()
    {
        _audioControl.PlayOneShot(_winingClip.GetAudioClip());
    }

    public void DeathSound()
    {
        _audioControl.PlayOneShot(_deathClip.GetAudioClip());
    }

    
  
}
