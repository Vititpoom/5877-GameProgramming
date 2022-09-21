using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReSpawnControl : MonoBehaviour
{
    [SerializeField] private float time = 4f;
    [SerializeField] private GameObject respawnObject;

    public void RespawnObject()
    {
        StartCoroutine(reSpawn());
    }
    private IEnumerator reSpawn()
    {
        yield return new WaitForSeconds(time);
        respawnObject.SetActive(true);
    }
}
