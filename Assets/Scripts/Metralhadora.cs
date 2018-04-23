using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Metralhadora : Arma{

    [SerializeField] private float shootDelay = 0.1f;
    [SerializeField] private float force = 100;


    // Update is called once per frame
    void Update(){
        timer -= Time.deltaTime;
    }

    public override void Shoot(){
        if (Input.GetKey(KeyCode.Mouse0) && timer <= 0f){
			if (ammoLeft > 0) {
				ammoLeft--;
				timer = shootDelay;
				GameObject project = Instantiate (sphere, Camera.main.transform.position + Camera.main.transform.forward, Camera.main.transform.rotation);
				project.name = transform.tag + "Bullet";
				project.GetComponent<Rigidbody> ().AddForce (Camera.main.transform.forward * force, ForceMode.Impulse);
				project.GetComponent<BulletBehaviour> ().damage = this.damage;
				ShootSoud ();
				Destroy (project, 2f);
			} else {
				Reload ();
			}
        }
    }

}
