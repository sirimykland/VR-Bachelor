using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtomCollider : MonoBehaviour {

    public GameBehaviour gameBehaviour;

    public AudioClip positiveHitSound;
    public AudioClip negativeHitSound;
    private AudioSource source;

    public Material dissolveMaterial;

    void Awake()
    {
        source = GetComponent<AudioSource>();
    }

    //Destroys atom and updates score when hit with sword
    void OnTriggerEnter(Collider atom)
    {
        if (!gameBehaviour.gameOver)
        {

            if (atom.gameObject.CompareTag("NonMetal"))
            {
                source.PlayOneShot(positiveHitSound, 1f);
                Destroy(atom.gameObject);
                gameBehaviour.score++;
                gameBehaviour.scoreText.text = "Score: " + gameBehaviour.score.ToString();
            }
            if (atom.gameObject.CompareTag("Metal"))
            {
                source.PlayOneShot(negativeHitSound, 1f);
                Destroy(atom.gameObject);
                gameBehaviour.lives--;
                gameBehaviour.livesText.text = "Lives: " + gameBehaviour.lives.ToString();
            }
        }
    }



    /*
    private void DissolveAtom(Collider atom)
    {
        //GameObject sphere = atom.transform.GetChild(0).gameObject;
        //Renderer rend = sphere.GetComponent<Renderer>();
        if (atom.gameObject.GetComponent<MeshRenderer>() == null)
        {
            Renderer rend = atom.gameObject.AddComponent<MeshRenderer>();
            rend.material = dissolveMaterial;
        }

    }

    IEnumerator WaitMethod(float seconds)
    {
        yield return new WaitForSeconds(seconds);
    }
    */
}
