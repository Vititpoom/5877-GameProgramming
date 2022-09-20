using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collect : MonoBehaviour
{
    public characterColor color;

    [SerializeField] private SoCollectible soCollectible;
    [SerializeField] private ReSpawnControl spawnControl;
    void Start()
    {
       

        if (TryGetComponent(out RandomColor randomColor))
        {
            color = randomColor.color;
        }


    }

    private void OnDisable()
    {
        spawnControl.RespawnObject();
    }

}
