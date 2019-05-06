using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class explosionTest : MonoBehaviour
{
    float cubeSize = 0.2f;
    float explosionRadius = 0.5f;
    float explosionForce = 500f;
    float explosionUpwards = 0.2f;
    int cubesInRow = 3;
    Vector3 cubesPivot;

    public Material nonMetalMaterial;
    public Material metalMaterial;
    float cubesPivotDistance;

    private void Start()
    {
        //calculate pivot distance
        cubesPivotDistance = cubeSize * cubesInRow / 2;
        //use this value to create pivot vector)
        cubesPivot = new Vector3(cubesPivotDistance, cubesPivotDistance, cubesPivotDistance);

    }
    void OnTriggerEnter(Collider atom)
    {
       
            if (atom.gameObject.CompareTag("NonMetal"))
            {
                AtomExplode(nonMetalMaterial);
                Destroy(atom.gameObject);
            }
            if (atom.gameObject.CompareTag("Metal"))
            {
                AtomExplode(metalMaterial);
                Destroy(atom.gameObject);
            }
        
    }


    /*private void AtomExplode(GameObject atom)
    {
        
        //GameObject partOfAtom;
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                for (int k = 0; k < 3; k++)
                {
                    CreatePiece(i,j,k);
                    //partOfAtom.transform.position = atom.transform.position + new Vector3(cubeSize * i, cubeSize * j, cubeSize * k);
                    //partOfAtom.tag = "Cube";
                    Vector3 explosionPos = new Vector3(-1.17f, 0.73f, 1.52f);
                    //Vector3 explosionPos = partOfAtom.transform.position;
                    Collider[] colliders = Physics.OverlapSphere(explosionPos, explosionRadius);
                    /*foreach (Collider col in colliders)
                    {
                        Rigidbody rB = col.GetComponent<Rigidbody>();
                        if (rB != null)
                        {
                            rB.AddExplosionForce(explosionForce, explosionPos, 10f, 1f);
                            Debug.Log("EXPLOSION");
                        }
                    }
                }
            }
        }
    }*/
    public void AtomExplode(Material material)
    {
        //make object disappear
        gameObject.SetActive(false);

        //loop 3 times to create 5x5x5 pieces in x,y,z coordinates
        for (int x = 0; x < 3; x++)
        {
            for (int y = 0; y < 3; y++)
            {
                for (int z = 0; z < 3; z++)
                {
                    CreatePiece(x, y, z, material);
                }
            }
        }

        Vector3 explosionPos = transform.position;
        Collider[] colliders = Physics.OverlapSphere(explosionPos, explosionRadius);
        foreach (Collider hit in colliders)
        {
            Rigidbody rb = hit.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.AddExplosionForce(explosionForce, transform.position, explosionRadius, explosionUpwards);
            }
        }

    }

    void CreatePiece(int x, int y, int z, Material material)
    {
  
        //create piece
        GameObject piece;
        piece = GameObject.CreatePrimitive(PrimitiveType.Cube);
        piece.GetComponent<Renderer>().material = material;

        //set piece position and scale
        piece.transform.position = transform.position + new Vector3(cubeSize * x, cubeSize * y, cubeSize * z) - cubesPivot;
        piece.transform.localScale = new Vector3(cubeSize, cubeSize, cubeSize);

        //add rigidbody and set mass
        piece.AddComponent<Rigidbody>();
        piece.GetComponent<Rigidbody>().mass = cubeSize;

    }

}
