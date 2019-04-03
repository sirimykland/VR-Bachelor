using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Molecule : MonoBehaviour
{
    private List<Atom> atomsList;
    public ParticleSystem explosion;

    public EscapeAtomsGameManager gameManager;
    public Material[] materials;

    // Use this for initialization
    private int BadCollision;
    private int outer;
    private int give;

    private bool _init = false;


    public void SetupWall(Atom gObj)
    {
        atomsList = new List<Atom>();
        Atom newAtom = (Atom)Instantiate(gObj, transform.parent.position, Quaternion.Euler(0, -90, 0));
        //gObj.Start();

        outer = 0;
        BadCollision = 0;
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
        else if (outer == 1 && atomsList.Count == 1 && atomsList[0].electrons == 1)
        {   //hydrogen
            give = 1;
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
        Debug.Log(outer + "color");
        this.gameObject.GetComponentInChildren<Renderer>().material = new Material(materials[outer]);
    }


    public void OnCollisionEnter(Collision col)
    {
        //Debug.Log("collision");

        if (_init)
        {
            if (col.gameObject.GetComponent<Atom>())
            {
                Atom colAtom = col.gameObject.GetComponent<Atom>();
                //Debug.Log(_init+": "+ colAtom.Name + " collided with " + atomsList[0].Name);

                int sum = outer + colAtom.outer;

                //Debug.Log("GiveState: " + colAtom.Give + " collided with givestate " + give);
                //Debug.Log("Outer: " + colAtom.Outer + " collided with Outer " + outer);
                if (sum <= 8)
                {

                    Debug.Log("give + colAtom.Give: " + give + "  " + colAtom.state);
                    if (((give + colAtom.state) < 4 && (give + colAtom.state) > 0)) // give: 0+1,1+0 | 1+1,0+2,2+0 | 1+2,2+1
                    {
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

    void AddAtom(Atom newAtom)
    {
        //sky av collisjon elns

        //Atom atomScript = newAtom.GetComponent<Atom>();
        //fjerner ridgid body
        Destroy(newAtom.GetComponent<Rigidbody>());
        int min = Math.Min(outer, newAtom.state);
        int max = Math.Max(newAtom.state, outer);
        if ((give + newAtom.state) == 1)
        {
            outer = max - min; //H can absorb electons so that i.e. H and Li will react
        }
        else
        {
            outer += newAtom.outer;
        }

        atomsList.Add(newAtom);//.GetComponent<Atom>());

        //Debug.Log("Atom is "+newAtom+". Outer of molecule is: "+ outer);


        // her og nedover må noe gjøres for å få posisjon 000
        newAtom.transform.parent = gameObject.transform;

        //Debug.Log(newAtom.transform.localPosition);
        SetLocation(newAtom.transform);
        newAtom.transform.rotation = Quaternion.Euler(0, -90, 0);//gameObject.transform.parent.rotation;
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
                trans.localPosition = new Vector3(0, 0, 0);
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

    IEnumerator FullMolecule()
    {

        yield return new WaitForSeconds(1);
        Debug.Log("Destroying");
        //eksplosjon 
        Explode();
        EscapeAtomsGameManager.moleculesLeft--;
        Destroy(gameObject);

    }

    public void Explode()
    {
        explosion = Instantiate(explosion, transform.position, Quaternion.identity);
    }
}




/*using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Molecule : MonoBehaviour {
    private List<Atom> atomsList;
    public ParticleSystem explosion;

    public EscapeAtomsGameManager gameManager;
    public Material[] materials;

    // Use this for initialization
    private int badCollision;
    private int outer;
    private int state;

    private bool init= false;


    public void SetupWall(Atom gObj){
        atomsList = new List<Atom>();
        Atom newAtom = Instantiate(gObj, transform.parent.position, Quaternion.Euler(0, -90, 0));
        
        outer = 0;
        badCollision=0;
        //AddAtom(newAtom);
        init = true;

    }


    * State() sets the give state to the molecule
     * with numbered meaning:
     *       0: give electrons
     *       1: give and receive (Hydrogen only)
     *       2: absorbs electrons
     *       4: full outer shell, must be destroyed
     *

    void State()
    {
        if (outer == 0 || outer == 8 || (outer == 2 && atomsList.Count == 2))
        {
            state = 4;
            StartCoroutine(FullMolecule());
        }
        else if (outer==1 && atomsList.Count==1 && atomsList[0].electrons == 1)
        {   //hydrogen
            state = 1;
        }
        else if (outer <= 4)
        {
            state = 0;     
        }
        else if (outer >= 5)
        {
            state = 2;
        }
    }

    * GiveAbsorb() computes outer.
     * if the sum of the colided atom's state and the molecule's state  is 1,
     *      (meaning one is hydrogen, one is state=0), 
     *      then the hydrogen will absorb an electron, and outer decreases with 1
     * Otherwise the colided atom's outer shell is added to the molecule's outer shell 
     *
    void GiveAbsorb(Atom newAtom)
    {
        if ((state + newAtom.state) == 1) // one of them is a hydrogen
        {
            int hydrogen = Math.Min(outer, newAtom.outer);
            int other = Math.Max(newAtom.outer, outer);
            outer = other - hydrogen; 
        }
        else
        {
            outer += newAtom.outer;
        }
    }

    void ChangeColor()
    {
        this.gameObject.GetComponentInChildren<Renderer>().material = new Material(materials[outer]);
    }


    public void OnCollisionEnter(Collision col)
    {
        if (init)
        {
            if (col.gameObject.GetComponent<Atom>())
            {
                Atom colAtom = col.gameObject.GetComponent<Atom>();

                int sum = outer + colAtom.outer;
                badCollision++;
                if (sum <= 8)
                { 
                    Debug.Log("give + colAtom.Give: "+ state +"  " + colAtom.state);
                    if (((state + colAtom.state) <4 && (state + colAtom.state) > 0)) // give: 0+1,1+0 | 1+1,0+2,2+0 | 1+2,2+1
                    {
                        AddAtom(colAtom);
                        badCollision = 0;
                    }

                }
                
                gameManager.Points(badCollision, colAtom.electrons);
            }
        }
    }

    void AddAtom(Atom newAtom)
    {
        //fjerner ridgid body
        Destroy(newAtom.GetComponent<Rigidbody>());

        GiveAbsorb(newAtom);

        atomsList.Add(newAtom);
        
        // her og nedover må noe gjøres for å få posisjon 000
        newAtom.transform.parent = gameObject.transform;

        SetLocation(newAtom.transform);
        newAtom.transform.rotation =  Quaternion.Euler(0, -90, 0);

        //sjekker om fullt ytterskal
        State();
        ChangeColor();

    }

    void SetLocation(Transform trans)
    {
        int length = atomsList.Count;
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

    IEnumerator FullMolecule()
    {
        yield return new WaitForSeconds(1);
        Explode();
        EscapeAtomsGameManager.moleculesLeft--;
        Destroy(gameObject);
    }

    public void Explode()
    { 
        explosion= Instantiate(explosion, transform.position, Quaternion.identity);
    }
}
*/
