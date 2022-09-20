using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Portal : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.CompareTag("Player")) return;

        var nextSceanBuildIndex = SceneManager.GetActiveScene().buildIndex + 1;
        if(nextSceanBuildIndex == SceneManager.sceneCountInBuildSettings)
        {
            SceneManager.LoadScene(0);
        }
        else
        {
            SceneManager.LoadScene(nextSceanBuildIndex);
        }
        
        
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        
    }


}
