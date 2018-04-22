using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiateBullet : MonoBehaviour{

    public GameObject sphere;
    public float force = 100;

    // Use this for initialization
    void Start(){

    }

    // Update is called once per frame
    void Update(){
        if (Input.GetButtonDown("Fire1"))
        {
            GameObject project = Instantiate(sphere,Camera.main.transform.position + Camera.main.transform.forward , Camera.main.transform.rotation);
            project.GetComponent<Rigidbody>().AddForce(Camera.main.transform.forward * force , ForceMode.Impulse);
            Destroy(project, 2f);
        }
    }
}
