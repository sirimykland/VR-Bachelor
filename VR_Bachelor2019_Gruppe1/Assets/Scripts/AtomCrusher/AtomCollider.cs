﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtomCollider : MonoBehaviour
{

    public GameBehaviour gameBehaviour;

    public AudioClip positiveHitSound;
    public AudioClip negativeHitSound;
    private AudioSource source;

    public GameObject nonMetalCube;
    public GameObject metalCube;

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
                AtomExplode(atom.gameObject, nonMetalCube);
                source.PlayOneShot(positiveHitSound, 0.3f);
                Destroy(atom.gameObject);
                gameBehaviour.score++;
            }
            if (atom.gameObject.CompareTag("Metal"))
            {
                AtomExplode(atom.gameObject, metalCube);
                source.PlayOneShot(negativeHitSound, 0.4f);
                Destroy(atom.gameObject);
                gameBehaviour.lives--;
            }
        }
    }


    private void AtomExplode(GameObject atom, GameObject cube)
    {
        float cubeSize = 0.2f;
        float explosionRadius = 0.5f;
        float explosionForce = 5f;
        float explosionUpwards = 0.2f;
        GameObject partOfAtom;
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                for (int k = 0; k < 3; k++)
                {
                    partOfAtom = Instantiate(cube);
                    partOfAtom.transform.position = atom.transform.position + new Vector3(cubeSize * i, cubeSize * j, cubeSize * k);
                    partOfAtom.tag = "Cube";
                    Vector3 explosionPos = partOfAtom.transform.position;
                    Collider[] colliders = Physics.OverlapSphere(explosionPos, explosionRadius);
                    foreach (Collider col in colliders)
                    {
                        Rigidbody rB = col.GetComponent<Rigidbody>();
                        if (rB != null)
                        {
                            rB.AddExplosionForce(explosionForce, explosionPos, explosionRadius, explosionUpwards);
                        }
                    }
                }
            }
        }
    }

}
