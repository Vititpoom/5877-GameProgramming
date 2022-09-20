using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;




public class PlayerCollision : MonoBehaviour
{
    [SerializeField] private PlayerControl playerControl;

    [SerializeField] private SpriteRenderer spriteRenderer;
    private characterColor playerColor;
    private Collider2D _playerCollider;


    // Start is called before the first frame update
    void Start()
    {
        _playerCollider = GetComponent<Collider2D>();   
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.TryGetComponent(out Collect collect))
        {
            characterColor playerColor = collect.color;

            switch (playerColor)
            {
                case characterColor.Red:
                    spriteRenderer.color = Color.red;
                    break;

                case characterColor.Blue:
                    spriteRenderer.color = Color.blue;
                    break;

                case characterColor.Green:
                    spriteRenderer.color = Color.green;
                    break;
                case characterColor.Yellow:
                    spriteRenderer.color = Color.yellow;
                    break;
            }
            collision.gameObject.SetActive(false);
        }
        if (collision.gameObject.TryGetComponent(out RandomColor randomColor))
        {
            characterColor playerColor = randomColor.color;

            switch (playerColor)
            {
                case characterColor.Red:
                    spriteRenderer.color = Color.red;
                    break;

                case characterColor.Blue:
                    spriteRenderer.color = Color.blue;
                    break;

                case characterColor.Green:
                    spriteRenderer.color = Color.green;
                    break;
                case characterColor.Yellow:
                    spriteRenderer.color = Color.yellow;
                    break;
            }
            Destroy(randomColor.gameObject);
        }

        if (_playerCollider.IsTouchingLayers(LayerMask.GetMask("Hazard")))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        

        

        /*if (_playerCollider.IsTouchingLayers(LayerMask.GetMask("Portal")))
        {
            Debug.Log(message: "Wooozzz");
        }*/
    }

}
