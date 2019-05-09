using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Molecule : MonoBehaviour {
    private List<Atom> atomsList;
    public Explotion explotion;

    public EscapeAtomsGameManager gameManager;
    public Material[] materials;

    // Use this for initialization
    private int badCollision;
    private int outer;
    private int state;

    private bool init = false;

    private AudioSource source;
    public AudioClip hitSound;
    public AudioClip positiveSound;


    public void SetupWall(Atom gObj){
        atomsList = new List<Atom>();
        Atom newAtom = Instantiate(gObj, transform.parent.position, Quaternion.Euler(0, -90, 0));

        outer = 0;
        badCollision=0;
        AddAtom(newAtom);

        source = GetComponent<AudioSource>();
        init = true;
    }


    /* State() sets the give state to the molecule
     * with numbered meaning:
     *       0: give electrons
     *       1: give and receive (Hydrogen only)
     *       2: absorbs electrons
     *       4: full outer shell, must be destroyed
     */

    void NewState()
    {
        if (outer == 0 || outer == 8 )
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

    /* GiveAbsorb() computes outer.
     * if the sum of the colided atom's state and the molecule's state  is 1,
     *      (meaning one is hydrogen, one is state=0),
     *      then the hydrogen will absorb an electron, and outer decreases with 1
     * Otherwise the colided atom's outer shell is added to the molecule's outer shell
     */
    void GiveAbsorb(Atom newAtom)
    {

        if (init && (state + newAtom.state) == 1) // one of them is a hydrogen
        {
            int hydrogen = Math.Min(outer, newAtom.outer);
            int other = Math.Max(newAtom.outer, outer);

            Debug.Log("m/a" + outer + newAtom.outer + " min/max" + hydrogen + other);
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

    /* OnCollisionEnter() determines if a collison is valid.
     * If the game is initialized, it will play a sound on collision, then
     *  If the collided object has a Atom component, then
     *     If it passes the conditions of a reaction between atoms it calls AddAtom()
     *     else it will be counted as a badCollision
     *  Points() in EscapeAtomsGameManager.cs is called.
     */
    public void OnCollisionEnter(Collision col)
    {
        if (init)
        {
            source.PlayOneShot(hitSound, 0.4f);

            if (col.gameObject.GetComponent<Atom>())
            {
                Atom colAtom = col.gameObject.GetComponent<Atom>();

                 int sumOuter = outer + colAtom.outer;
                 int sumState = state + colAtom.state;

                // States that goes together: 0 & 1 | 1 & 1, 0 & 2 | 1+2,2+1
                if ((sumOuter <= 8) && (sumState < 4) && (sumState > 0))
                {
                    AddAtom(colAtom);
                    source.PlayOneShot(positiveSound, 0.4f);
                }

                else
                {
                    badCollision++;
                }

                gameManager.Points(badCollision, colAtom);
            }
        }
    }


    /* AddAtom() adds the collided atom to the Molecule.
     *  Removes the Ridgidbody, adds new atom to the list of atoms.
     *  Sets the molecule to be its parent/placeholder.
     *  Sets the atoms new rotation and calls SetLocation() for new scaleing and location
     *  Calls GiveAbsorb(), NewState(), ChangeColor(), to set the molecules new conditions
     */
    void AddAtom(Atom newAtom)
    {
        Destroy(newAtom.GetComponent<Rigidbody>());
        atomsList.Add(newAtom);

        newAtom.transform.parent = gameObject.transform;
        newAtom.transform.rotation =  Quaternion.Euler(0, -90, 0);
        SetLocation(newAtom.transform);

        GiveAbsorb(newAtom);
        NewState();
        ChangeColor();

    }

    /* SetLocation() sets the scale and position of the Atom
     * based on number of atom in the molecule.
     */
    void SetLocation(Transform trans)
    {
        int length = atomsList.Count;
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
            case 5:
                trans.localScale = new Vector3(3, 3, 3);
                trans.localPosition = new Vector3(-1, 0, 0);
                break;
            case 6:
                trans.localScale = new Vector3(3, 3, 3);
                trans.localPosition = new Vector3(0.65f, .65f, 0);
                break;
            case 7:
                trans.localScale = new Vector3(3, 3, 3);
                trans.localPosition = new Vector3(-0.65f, -0.65f, 0);
                break;

        }
    }

    // FullMolecule() destroyes this gameObject and calls Explode()
    IEnumerator FullMolecule()
    {
        yield return new WaitForSeconds(1);
        string str="";
        foreach (Atom a in atomsList)
            str += (" " + a.atomname);
        Debug.Log(str);
        Explode();
        gameManager.moleculesLeft--;
        Destroy(gameObject);
    }

    // Creates an explotion of the Prefab Explotion at the molecule's position
    public void Explode()
    {
        explotion = Instantiate(explotion, transform.position, Quaternion.identity);
    }
}
