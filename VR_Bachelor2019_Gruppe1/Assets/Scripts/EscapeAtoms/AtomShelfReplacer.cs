using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtomShelfReplacer : MonoBehaviour
{
    public GameObject atomobject;


    // Update is called once per frame
    void Update()
    {
        if(gameObject.transform.childCount == 0)
        {
            StartCoroutine(ReplaceAtom());
        }
    }

    IEnumerator ReplaceAtom()
    {
        yield return new WaitForSeconds(2);
        Instantiate(atomobject, transform.position, transform.rotation);
    }
}
