using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "Script/collectible")]
public class SoCollectible : ScriptableObject
{
    [SerializeField] private Sprite sprite;
    [SerializeField] private Sprite outlinesprite;
    [SerializeField] private bool _isRespawn;

    [SerializeField] private ScriptableType scriptableType; 


    public ScriptableType GetName()
    {
        return scriptableType;
    }
   
}
