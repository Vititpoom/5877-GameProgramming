using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomColor : MonoBehaviour
{
    public characterColor color;
    [SerializeField] private Sprite[] sprites;
    [SerializeField] private int randomNumber;
    private SpriteRenderer spriteRenderer;


    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        randomNumber = Random.Range(0, sprites.Length);

        switch (randomNumber)
        {
            case 0:
                color = characterColor.Red;
                break;
            case 1:
                color = characterColor.Green;
                break;
            case 2:
                color = characterColor.Blue;
                break;
            case 3:
                color = characterColor.Yellow;
                break;
        }

        spriteRenderer.sprite = sprites[randomNumber];

        
    }

}
