using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Molecule : MonoBehaviour {
    private List<Atom> atomsList;
    public ParticleSystem explosion;


    // Use this for initialization
    [HideInInspector]
    //public int starterAtom;
    // private int _give;
    //public int Electrons { get; set; }
    public int Outer { get; set; }
    public int Give { get; set; }

    private bool _init= false;


    public void SetupWall(Atom gObj){
        atomsList = new List<Atom>();
        //Atom oldAtom = gObj.GetComponent<Atom>();
        Atom newAtom = (Atom)Instantiate(gObj, transform.parent.position, Quaternion.Euler(0, -90, 0));

        //g.GetComponent<Atom>().SetValues(oldAtom.Electrons, oldAtom.Name);
        
        //Debug.Log("Old atom had "+oldAtom.electrons+" electrons and  was named "+oldAtom.atomname);

        //a.transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);
        
        Outer = 0;
        AddAtom(newAtom);
        _init = true;

    }



    public void GiveAwayState()
    {
        if (Outer == 0 || Outer == 8)
        {
            Give = 3;
            StartCoroutine(FullMolecule());
        }
        else if (Outer <= 4)
        {
            Give = 0;
        }
        else if (Outer >= 5)
        {
            Give = 2;
        }
        
    }


    void OnTriggerEnter(Collider col) {
        if (_init)
        {
            if (col.gameObject.GetComponent<Atom>())
            {
                Atom colAtom = col.gameObject.GetComponent<Atom>();
                Debug.Log(_init+": "+ colAtom.Name + " collided with " + atomsList[0].Name);
                int sum = Outer + colAtom.Outer;
                if (sum <= 8) { 
                    if(((Give + colAtom.Give) > 1))
                    {
                        Debug.Log("Collition valid give > 1");
                        //AddAtom(col.gameObject);
                    }else if ((Give==0 && colAtom.Give ==2) || (Give==2 && colAtom.Give==0))
                    {
                        Debug.Log("Collition valid");
                        //AddAtom(col.gameObject);
                    }else if (Give == 1 && colAtom.Give==1)
                    {
                        Debug.Log("Collition valid");
                        //AddAtom(col.gameObject);
                    }
                    else if (Give == 1 && colAtom.Give == 2 || (Give == 2 && colAtom.Give == 1))
                    {
                        Debug.Log("Collition valid");
                        //AddAtom(col.gameObject);
                    }
                }
            }
        }
    }

    void AddAtom(Atom newAtom){
        //sky av collisjon elns

        //Atom atomScript = newAtom.GetComponent<Atom>();
        //fjerner ridgid body

        atomsList.Add(newAtom);//.GetComponent<Atom>());
        Outer += newAtom.Outer;
        Debug.Log("Atom is "+newAtom+". Outer of molecule is: "+ Outer+" and new atom is"+ newAtom.Outer);


        // her og nedover må noe gjøres for å få posisjon 000
        newAtom.transform.parent = gameObject.transform;

        //Debug.Log(newAtom.transform.localPosition);
        SetLocation(newAtom.transform);
        //Debug.Log(newAtom.transform.localPosition );

        //sjekker om fullt ytterskal
        GiveAwayState();
        
    }
    void SetLocation(Transform trans)
    {
        int length = atomsList.Count;
        Debug.Log("atomlist is of length "+length);
        switch (length)
        {
            case 1:
                trans.localScale = new Vector3(5, 5, 5);
                trans.localPosition=new Vector3(0, 0, 0);
                Debug.Log(trans.localPosition);
                break;
            case 2:
                trans.localScale = new Vector3(3, 3, 3);
                trans.localPosition = new Vector3(1, 0, 0);
                break;
            case 3:
                trans.localScale = new Vector3(2, 2, 2);
                trans.localPosition = new Vector3(-1, -1, 0);
                break;
            case 4:
                trans.localScale = new Vector3(2, 2, 2);
                trans.localPosition = new Vector3(0, 1, 0);
                break;
            default:
                trans.localScale = new Vector3(3, 3, 3);
                trans.localPosition = new Vector3(0, 0, 0);
                break;
        }
    }

    IEnumerator FullMolecule(){

        yield return new WaitForSeconds(2);
        Debug.Log("Destroying");
        //eksplosjon 
        Explode();
        Destroy(gameObject);
    }

    

    public void Explode()
    { 
        Instantiate(explosion, transform.position, Quaternion.identity);
    }
}
