using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pistola : Arma{
    
    GameObject sphere;
    private float timer = 0f;
    public float shootDelay = 15;
    public float force = 100;

    // Use this for initialization
    void Start(){
        sphere = (GameObject)Resources.Load("Bullet", typeof(GameObject));
    }

    // Update is called once per frame
    void Update(){
        timer--;
        if (Input.GetButtonDown("Fire1") && timer <= 0){
            Shoot();
        }
    }

    public override void Shoot() {
        timer = shootDelay;
        GameObject project = Instantiate(sphere, Camera.main.transform.position + Camera.main.transform.forward, Camera.main.transform.rotation);
        project.name += transform.parent.name;
        project.GetComponent<Rigidbody>().AddForce(Camera.main.transform.forward * force, ForceMode.Impulse);
        Destroy(project, 2f);
    }

}
