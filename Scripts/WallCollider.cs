using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallCollider : MonoBehaviour {

    //Connects script with the script AtomCollider to get its public variables
    public GameBehaviour gameBehaviour;

    public AudioClip positiveWallSound;
    public AudioClip negativeWallSound;
    private AudioSource source;

    void Awake()
    {
        source = GetComponent<AudioSource>();
    }

    void OnTriggerEnter(Collider atom)
    {
        if ((!gameBehaviour.gameOver) && atom.gameObject.CompareTag("NonMetal"))
        {
            source.PlayOneShot(negativeWallSound, 1f);

            gameBehaviour.lives--;
            gameBehaviour.livesText.text = "Lives: " + gameBehaviour.lives.ToString();
            Destroy(atom.gameObject);
        }
        
        if (atom.gameObject.CompareTag("Metal"))
        {
            source.PlayOneShot(positiveWallSound, 1f);
            Destroy(atom.gameObject);
        }
    }
}
