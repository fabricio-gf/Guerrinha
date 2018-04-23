using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Metralhadora : Arma{

    GameObject sphere;
    private float timer = 0f;
    [SerializeField] private float shootDelay = 0.1f;
    [SerializeField] private float force = 100;

    // Use this for initialization
    void Start(){
        sphere = (GameObject)Resources.Load("Bullet", typeof(GameObject));
    }

    // Update is called once per frame
    void Update(){
        timer -= Time.deltaTime;
    }

    public override void Shoot(){
        if (Input.GetKey(KeyCode.Mouse0) && timer <= 0f){
            timer = shootDelay;
            GameObject project = Instantiate(sphere, Camera.main.transform.position + Camera.main.transform.forward, Camera.main.transform.rotation);
            project.name = transform.tag + "Bullet";
            project.GetComponent<Rigidbody>().AddForce(Camera.main.transform.forward * force, ForceMode.Impulse);
            project.GetComponent<BulletBehaviour>().damage = this.damage;
            Destroy(project, 2f);
			ShootSoud ();
        }
    }
}
