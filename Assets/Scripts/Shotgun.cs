using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shotgun : Arma {

    [SerializeField] private float shootDelay = 0.8f;
    [SerializeField] private float force = 100;
	[SerializeField] private int BulletPerShoot = 7;
	[SerializeField] private float Spread = 7;


    // Update is called once per frame
    void Update() {
        timer -= Time.deltaTime;
    }

    public override void Shoot() {
        if (Input.GetKey(KeyCode.Mouse0) && timer <= 0f) {

			timer = shootDelay;
			for (int i = 0; i < BulletPerShoot; i++) {

				Vector3 ErrorVector = new Vector3(Random.Range(-Spread,Spread),Random.Range(-Spread,Spread),Random.Range(-Spread,Spread));
				Vector3 dir = (Camera.main.transform.forward + (ErrorVector.normalized*(Spread/180f)));

				GameObject project = Instantiate(sphere, Camera.main.transform.position + Camera.main.transform.forward,Quaternion.LookRotation(dir));
				project.name = transform.tag + "Bullet";
				project.GetComponent<Rigidbody>().AddForce(project.transform.forward * force, ForceMode.Impulse);
				project.GetComponent<BulletBehaviour>().damage = this.damage;
				Destroy(project, 2f);
			}
			ShootSoud ();
        }
    }

}
