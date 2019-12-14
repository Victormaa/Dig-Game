using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test_blackhole : MonoBehaviour
{

    // The radius of the "sphere of influence" This can be set to infinity (or a very large number) for more realistic gravity.
    public float soiRadius = 3;

    // The relative mass of the object
    public float mass;

    // Used to alter (unatuarally) the coorelation between the proximity of the objects to the severity of the attraction.  Tweak to make orbits easier to achieve or more intersting.
    public int proximityModifier;

    public int originalG;

    public int maxModifier = 595;

    public GameObject Circle;

    public float test_adjustForRadius;

    private bool setRadiusGiz = false;

    bool SettingbeeffectedDone = false;

    List<GameObject> Gaffectedobjects;

    // Start is called before the first frame update
    void Start()
    {
        Gaffectedobjects = new List<GameObject>();

        mass = mass * 1000; // Mass ^ 5 in order to allow the relative mass input to be more readable

        originalG = maxModifier - proximityModifier;
    }

    public void OnDrawGizmos()
    {
        // Show the Object's Sphere Of Influence
        Gizmos.DrawWireSphere(transform.position, soiRadius);
    }

    // Update is called once per frame
    void Update()
    {
        if (!setRadiusGiz)
        {
            Circle.gameObject.transform.localScale = new Vector3(soiRadius / (test_adjustForRadius * this.transform.localScale.x / 2), soiRadius / (test_adjustForRadius * this.transform.localScale.x / 2), 0);
            setRadiusGiz = true;
        }
    }

    private void FixedUpdate()
    {
        // when it broke the gravity thing temperory stop;
        GravityApply();
    }

    private void GravityApply()
    {
        GameObject[] otherGobjects;
        otherGobjects = GameObject.FindGameObjectsWithTag("affectedByPlanetGravity");

        GameObject _player;
        _player = GameObject.FindGameObjectWithTag("Player");

        if (!SettingbeeffectedDone)
        {

            for (int i = 0; i < otherGobjects.Length; i++)
            {
                Gaffectedobjects.Add(otherGobjects[i]);
            }
            Gaffectedobjects.Add(_player);
            SettingbeeffectedDone = true;
        }

        foreach (GameObject attractedBody in Gaffectedobjects)
        {
            Rigidbody2D attractedRigidBody = attractedBody.GetComponent<Rigidbody2D>();     // Get the object's Rigid Body Component

            float orbitalDistance = Vector3.Distance(this.transform.position, attractedRigidBody.transform.position);   // Get the object's distance from the World Body

            if (orbitalDistance < soiRadius)
            {
                Vector3 objectOffset = transform.position - attractedRigidBody.transform.position; // Get the object's 2d offset relative to this World Body

                objectOffset.z = 0;

                Vector3 objectTrajectory = attractedRigidBody.velocity; // Get object's trajectory vector

                float angle = Vector3.Angle(objectOffset, objectTrajectory); // Calculate object's angle of attack ( Not used here, but potentially insteresting to have )

                float magsqr = objectOffset.sqrMagnitude; // Square Magnitude of the object's offset

                if (magsqr > 0.0001f)
                {
                    // Apply gravitational force to the object
                    Vector3 gravityVector = (mass * objectOffset.normalized / magsqr) * attractedRigidBody.mass;
                    attractedRigidBody.AddForce(gravityVector * (orbitalDistance / proximityModifier), ForceMode2D.Force);
                }
            }
        }
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {

        var hitobject = collision.gameObject;
        if (hitobject.tag == "Player")
        {
            hitobject.GetComponent<Test_ball>().Crushing();
            // for music test 
        }
    }
}
