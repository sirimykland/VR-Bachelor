using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Molecule : MonoBehaviour {
    private List<Atom> _atomsList;

    // Use this for initialization
    private int _noElectrons=0;
    [HideInInspector]
    public int starterAtom;
    private bool _give;
    private bool _init= false;
    
    public void setupWall(){
        _atomsList = new List<Atom>();
        Atom a = Instantiate(GetComponentInParent<MoleculeManagement>().Atoms[starterAtom]);
        a.transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);
        Destroy(a.GetComponent<Rigidbody>());
        Destroy(a.GetComponent<SphereCollider>());
        gameObject.AddComponent<SphereCollider>().radius=0.75f;

        addAtom(a);
        giveAwayState();
        _init = true;

    }

    public void giveAwayState() {
        if (_noElectrons > 4 && _noElectrons < 8)
            _give = true;
        else
            _give = false;
    }

    public int NoElectrons{
        get { return _noElectrons; }
    }

    void OnTriggerEnter(Collider col) {
        if (_init)
        {
            if (col.gameObject.GetComponent<Atom>())
            {
                Atom _collidedAtom = col.gameObject.GetComponent<Atom>();
                Debug.Log(_init+": "+_collidedAtom.Name + " collided with " + _atomsList[0].Name);
                int sum = _noElectrons + _collidedAtom.NoElectrons;

                if ((_give && !_collidedAtom.Give) || (!_give && _collidedAtom.Give))
                {

                    if (sum <= 8)
                        Debug.Log("Collition valid");
                    {
                        addAtom(_collidedAtom);
                    }
                }

            }
        }
    }

    void addAtom(Atom newAtom){
        //sky av collisjon elns

        //fjerner ridgid body
        Destroy(newAtom.GetComponent<Rigidbody>());
        _atomsList.Add(newAtom);
        _noElectrons = newAtom.NoElectrons;

        // her og nedover må noe gjøres for å få posisjon 000
        newAtom.transform.parent = gameObject.transform;
        newAtom.transform.localScale += new Vector3(1, 1, 1);

        Debug.Log(newAtom.transform.localPosition + "  =   " + setLocation());
        newAtom.transform.localPosition = setLocation();
        Debug.Log(newAtom.transform.localPosition );
        

        //sjekker om fullt ytterskal
        fullMolecule();
    }
    Vector3 setLocation()
    {
        int length = _atomsList.Count;
        Debug.Log("atomlist is of length "+length);
        switch (length)
        {
            case 1:
                return new Vector3(0, 0, 0);
            case 2:
                return new Vector3(1, 0, 0);
            case 3:
                return new Vector3(-1, -1, 0);
            case 4:
                return new Vector3(0, 1, 0);
            default:
                return new Vector3(0, 0, 0);
        }
    }

    void fullMolecule(){
        if (_noElectrons == 8)
        {
            //eksplosjon 
            Explode(gameObject.GetComponent<Vector3>());
            Destroy(gameObject);
        }
    }

    public ParticleSystem explosion;

    public void Explode(Vector3 position)
    { 
        Instantiate(explosion, position, Quaternion.identity);
    }
}
