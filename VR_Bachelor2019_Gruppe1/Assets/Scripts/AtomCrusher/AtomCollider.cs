/* AtomCollider.cs - 02.04.2019
 * Handles game functionality when an atom collides with the lightsaber GameObject.
 * The atom explodes and the variables score/lives are updated.
 */


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtomCollider : MonoBehaviour {

    public GameBehaviour gameBehaviour;

    public AudioClip positiveHitSound;
    public AudioClip negativeHitSound;
    private AudioSource source;

    public Material nonMetalMaterial;
    public Material metalMaterial;

    void Awake()
    {
        source = GetComponent<AudioSource>();
    }

    //Destroys atom and updates score when hit with sword.
    void OnTriggerEnter(Collider atom)
    {
        if (!gameBehaviour.gameOver)
        {

            if (atom.gameObject.CompareTag("NonMetal"))
            {
                AtomExplode(atom.gameObject, nonMetalMaterial);
                source.PlayOneShot(positiveHitSound, 0.3f);
                Destroy(atom.gameObject);
                gameBehaviour.score++;
            }
            if (atom.gameObject.CompareTag("Metal"))
            {
                AtomExplode(atom.gameObject, metalMaterial);
                source.PlayOneShot(negativeHitSound, 0.4f);
                Destroy(atom.gameObject);
                gameBehaviour.lives--;
            }
        }
    }

    //Simulates an atom exploding by creating 3x3x3 cubes and then use the AddExplosionForce() function for a rigidbody
    private void AtomExplode(GameObject atom, Material material)
    {
        float cubeSize = 0.08f;
        float explosionRadius = 0.3f;
        float explosionForce = 40f;
        float explosionUpwards = 0.2f;
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                for (int k = 0; k < 3; k++)
                {
                    CreateCube(i, j, k, cubeSize, material);
                }
            }
        }
        Vector3 explosionPos = transform.position;
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

    //Creates a primitive cube and adds necessary components to it
    void CreateCube(int x, int y, int z, float cubeSize, Material material)
    {

        GameObject cube;
        cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
        cube.GetComponent<Renderer>().material = material;
        cube.transform.position = transform.position + new Vector3(cubeSize * x, cubeSize * y, cubeSize * z);
        cube.transform.localScale = new Vector3(cubeSize, cubeSize, cubeSize);
        cube.AddComponent<Rigidbody>();
        cube.GetComponent<Rigidbody>().mass = cubeSize;
        cube.GetComponent<BoxCollider>().isTrigger = true;
        cube.tag = "Cube";
    }

}
