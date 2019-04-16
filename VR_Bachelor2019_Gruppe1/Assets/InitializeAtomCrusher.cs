/* InitializeAtomCrusher.cs - 16.04.2019
 * Handels the opening scene in Atom Crusher. Allows the player to choose difficulty. 
 */


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InitializeAtomCrusher : MonoBehaviour
{

    void OnTriggerEnter(Collider atom)
    {
        if (atom.gameObject.CompareTag("NonMetal"))
        {
            Global.level = 1;
            StartCoroutine(WaitToStart());
            SceneManager.LoadScene("AtomCrusherEasy");
        }
        if (atom.gameObject.CompareTag("Metal"))
        {
            Global.level = 2;
            StartCoroutine(WaitToStart());
            SceneManager.LoadScene("AtomCrusherNormal");
        }
    }


    public static IEnumerator WaitToStart()
    {
        Debug.Log("wait 3 sec");
        yield return new WaitForSeconds(3);
    }


    private void AtomExplode(GameObject atom, GameObject cube)
    {
        float cubeSize = 0.2f;
        float explosionRadius = 0.5f;
        float explosionForce = 500f;
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
                    Vector3 explosionPos = new Vector3(-1.17f, 0.73f, 1.52f);
                    //Vector3 explosionPos = partOfAtom.transform.position;
                    Collider[] colliders = Physics.OverlapSphere(explosionPos, explosionRadius);
                    foreach (Collider col in colliders)
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
    }
}
