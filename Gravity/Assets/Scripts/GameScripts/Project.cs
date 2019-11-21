using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Project : MonoBehaviour
{
    

    public float ProjectPower;

    private Direction ShootDir;

    private void Awake()
    {
        ShootDir = this.GetComponent<Direction>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void FireRocket()
    {
        Rigidbody2D rig = this.GetComponent<Rigidbody2D>();
        rig.AddForce(ShootDir.ShootingDir * ProjectPower, ForceMode2D.Impulse);
        
    }
}
