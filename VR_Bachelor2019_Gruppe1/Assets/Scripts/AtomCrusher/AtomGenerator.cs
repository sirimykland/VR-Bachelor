/* AtomGenerator.cs - 02.04.2019
 * Spawns the atoms into the game. The velocity/fire rate is also regulated in this script.
 */


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AtomGenerator : MonoBehaviour {

    //Connects script with the script AtomCollider to get its public variables
    public GameBehaviour gameBehaviour;
    public TextMesh infoText;
    private int score;

    public GameObject[] nonMetal;
    public GameObject[] metal;

    private Rigidbody rB;
    private SphereCollider sC;
    private ConstantForce cF;

    private float fireRate;
    private float nextFire;
    private System.Random random = new System.Random();

    private bool tutorialNonMetal;
    private bool tutorialMetal;

    // Initialization
    void Start () {
        fireRate = 3f;
        nextFire = 25f;
        score = gameBehaviour.score;
        tutorialNonMetal = true;
        tutorialMetal = false;
    }
	
	void Update () {
        score = gameBehaviour.score;

        if (!gameBehaviour.gameOver)
        {
            if (tutorialNonMetal)
            {
                //Vector3 position = new Vector3(-1.3f, 2f, 21f);
                Vector3 position = new Vector3(-1.3f, 2f, 5f);
                GameObject atom = Instantiate(nonMetal[0]);
                AddComponents(atom, -0.5f, position);
                atom.tag = "NonMetal";
                tutorialNonMetal = false;
                tutorialMetal = true;
            }
            else if (tutorialMetal && Time.time > 10f)
            {
                Vector3 position = new Vector3(1.3f, 2f, 21f);
                GameObject atom = Instantiate(metal[0]);
                AddComponents(atom, -0.5f, position);
                atom.tag = "Metal";
                infoText.text = "Avoid metal atoms like this one";
                tutorialMetal = false;
            }

            if ((!tutorialMetal && !tutorialNonMetal) && score < 8 && Time.time > 25)
            {
                fireRate = 2f;
                infoText.text = "";
            }

            if (Time.time > nextFire)
            {
                nextFire = Time.time + fireRate;
                GenerateAtom();
            }
        }
    }

    /* Decides type of atom (metal/nonmetal), the path it takes, and the name of the atom by randomizing numbers.
     * Regulates the velocity and fire rate based on the score of the game.
     */
    private void GenerateAtom()
    {
        int typeOfAtom = random.Next(1, 5);
        int atomPath = random.Next(1, 5);
        int atomNumber;
        Vector3 position = new Vector3(0f,0f,21f);
        float velocity = -0.5f;

        if (score >= 8 && score < 12)
        {
            velocity = -1f;
        }
        else if (score >= 12 && score < 20)
        {
            velocity = -1.5f;
            fireRate = 1.5f;
        }
        else if (score >= 20 && score < 27)
        {
            velocity = -2f;
            fireRate = 1.2f;
        }
        else if (score >= 27 && score < 32)
        {
            velocity = -2.5f;
            fireRate = 1f;
        }
        else if (score >= 32 && score < 40)
        {
            velocity = -3f;
            fireRate = 0.8f;
        }
        else if (score >= 40 && score < 50)
        {
            velocity = -4f;
            fireRate = 0.5f;
        }
        else if (score >= 50 && score < 65)
        {
            velocity = -4.7f;
        }
        else if (score >= 65 && score < 80)
        {
            velocity = -5.5f;
        }
        else if (score >= 80)
        {
            velocity = -6f;
            fireRate = 0.4f;
        }

        switch (atomPath)
        {
            case 1:
                position = new Vector3(-2f, 0.5f, 21f);
                break;
            case 2:
                position = new Vector3(-1.3f, 2f, 21f);
                break;
            case 3:
                position = new Vector3(1.3f, 2f, 21f);
                break;
            case 4:
                position = new Vector3(2f, 0.5f, 21f);
                break;
        }

        //If atom is of type metal
        if (typeOfAtom == 4)
        {
            atomNumber = random.Next(0,4);
            GameObject atom = Instantiate(metal[atomNumber]);
            AddComponents(atom, velocity, position);
            atom.tag = "Metal";
        }
        else if (typeOfAtom < 4)
        {
            atomNumber = random.Next(0, 6);
            GameObject atom = Instantiate(nonMetal[atomNumber]);
            AddComponents(atom, velocity, position);
            atom.tag = "NonMetal";
        }
    }

    //Adds necessary components to the atom gameobjects.
    private void AddComponents(GameObject gO, float velocity, Vector3 position)
    {
        sC = gO.AddComponent<SphereCollider>();
        rB = gO.AddComponent<Rigidbody>();
        cF = gO.AddComponent<ConstantForce>();
        sC.isTrigger = true;
        //sC.center = new Vector3(0f, 0f, 0f);
        rB.useGravity = false;
        cF.force = new Vector3(0f, 0f, velocity);
        gO.transform.position = position;
        gO.transform.rotation = Quaternion.Euler(0f, 90f, 0f);
        gO.transform.localScale = new Vector3(2.2f, 2.2f, 2.2f);
    }

}
