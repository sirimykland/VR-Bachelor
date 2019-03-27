using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Molecule : MonoBehaviour {
    private List<Atom> atomsList;
    public ParticleSystem explosion;

    public EscapeAtomsGameManager gameManager;
    public Material[] materials;

    // Use this for initialization
    private int BadCollision;
    private int outer;
    private int give;

    private bool _init= false;


    public void SetupWall(Atom gObj){
        atomsList = new List<Atom>();
        Atom newAtom = (Atom)Instantiate(gObj, transform.parent.position, Quaternion.Euler(0, -90, 0));
        //gObj.Start();
        
        outer = 0;
        BadCollision=0;
        AddAtom(newAtom);
        _init = true;

    }


    /* give meaning:
 * 0: give electrons
 * 1: give and receive (Hydrogen only)
 * 2: receive electrons
 * 4: full outer shell
 */
    private void GiveAwayState()
    {
        if (outer == 0 || outer == 8 || (outer == 2 && atomsList.Count == 2))
        {
            give = 4;
            StartCoroutine(FullMolecule());
        }
        else if (outer <= 4)
        {
            give = 0;
        }
        else if (outer >= 5)
        {
            give = 2;
        }
    }
    private void ChangeStateColor()
    {
        this.gameObject.GetComponentInChildren<Renderer>().material = new Material(materials[outer-1]);
    }


    public void OnCollisionEnter(Collision col) {
        Debug.Log("collision");

        if (_init)
        {
            if (col.gameObject.GetComponent<Atom>())
            {
                Atom colAtom = col.gameObject.GetComponent<Atom>();
                Debug.Log(_init+": "+ colAtom.Name + " collided with " + atomsList[0].Name);

                int sum = outer + colAtom.Outer;

                Debug.Log("GiveState: " + colAtom.Give + " collided with givestate" + give);
                Debug.Log("Outer: " + colAtom.Outer + " collided with Outer" + outer);
                if (sum <= 8) { 
                    if(((give + colAtom.Give) <4 && (give + colAtom.Give) > 0)) // give: 0+1,1+0 | 1+1,0+2,2+0 | 1+2,2+1
                    {
                        Debug.Log("Collition valid give [2 between 1]");
                        AddAtom(colAtom);
                    }
                    BadCollision = 0;
                }
                else
                {
                    BadCollision++;
                }
                gameManager.Points(BadCollision, colAtom.electrons);
            }
        }
    }

    void AddAtom(Atom newAtom){
        //sky av collisjon elns

        //Atom atomScript = newAtom.GetComponent<Atom>();
        //fjerner ridgid body
        Destroy(newAtom.GetComponent<Rigidbody>());

        atomsList.Add(newAtom);//.GetComponent<Atom>());
        outer += newAtom.Outer;
        //Debug.Log("Atom is "+newAtom+". Outer of molecule is: "+ outer);


        // her og nedover må noe gjøres for å få posisjon 000
        newAtom.transform.parent = gameObject.transform;

        //Debug.Log(newAtom.transform.localPosition);
        SetLocation(newAtom.transform);
        newAtom.transform.rotation =  Quaternion.Euler(0, -90, 0);//gameObject.transform.parent.rotation;
        //Debug.Log(newAtom.transform.localPosition );

        //sjekker om fullt ytterskal
        GiveAwayState();
        ChangeStateColor();
    }
    void SetLocation(Transform trans)
    {
        int length = atomsList.Count;
        //Debug.Log("atomlist is of length "+length);
        switch (length)
        {
            case 1:
                trans.localScale = new Vector3(5, 5, 5);
                trans.localPosition=new Vector3(0, 0, 0);
                break;
            case 2:
                trans.localScale = new Vector3(3, 3, 3);
                trans.localPosition = new Vector3(1, 0, 0);

                break;
            case 3:
                trans.localScale = new Vector3(3, 3, 3);
                trans.localPosition = new Vector3(0, -1, 0);
                break;
            case 4:
                trans.localScale = new Vector3(3, 3, 3);
                trans.localPosition = new Vector3(0, 1, 0);
                break;
            default:
                trans.localScale = new Vector3(3, 3, 3);
                trans.localPosition = new Vector3(-1, 0, 0);
                break;
        }
    }

    IEnumerator FullMolecule(){

        yield return new WaitForSeconds(2);
        Debug.Log("Destroying");
        //eksplosjon 
        Explode();
        gameManager.moleculesLeft--;
        Destroy(gameObject);
        
    }

    public void Explode()
    { 
        explosion= Instantiate(explosion, transform.position, Quaternion.identity);
    }
}
