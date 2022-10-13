using UnityEngine;

public class FinishLine : MonoBehaviour
{
    private const string PlayerTag = "Player";

    private GameManager _gameManager;
    [SerializeField] private int lavel;
    [SerializeField] private PlayerAudioController audioController;
    [SerializeField] private ParticleSystem _winFx;

    // Why are we checking if the player reaches the finish line here? So, we do not
    // have to check for every time the player collides with something for a finish line.

    private void Start()
    {
        _gameManager = FindObjectOfType<GameManager>();
    }
    
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (!col.CompareTag(PlayerTag)) return;
        PlaySound();
        _winFx.Play();
        _gameManager.LoadScene(lavel);
        

    }

    private void PlaySound()
    {
        _gameManager.WinSound();
     }
}
