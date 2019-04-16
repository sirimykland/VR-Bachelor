/* WallCollider.cs - 02.04.2019
 * Handles action when atom gameObjects collides with the South Wall.
 * Updates the player's lives.
 */


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallCollider : MonoBehaviour {
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
            source.PlayOneShot(negativeWallSound, 0.4f);

            gameBehaviour.lives--;
            Destroy(atom.gameObject);
        }
        
        if (atom.gameObject.CompareTag("Metal"))
        {
            source.PlayOneShot(positiveWallSound, 0.4f);
            Destroy(atom.gameObject);
        }
    }
}
