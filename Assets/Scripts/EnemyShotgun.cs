using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShotgun : EnemyArma {

    GameObject sphere;
    private float timer = 0f;
    [SerializeField] private float shootDelay = 0.8f;
    [SerializeField] private float force = 100;
	[SerializeField] private int BulletPerShoot = 7;
	[SerializeField] private float Spread = 7;

    // Use this for initialization
    void Start() {
        sphere = (GameObject)Resources.Load("Bullet", typeof(GameObject));
    }

    // Update is called once per frame
    void Update() {
        timer -= Time.deltaTime;
    }

	public override void Shoot(Vector3 origin, Vector3 direction) {
        if (timer <= 0f) {

			timer = shootDelay;
			for (int i = 0; i < BulletPerShoot; i++) {

				Vector3 ErrorVector = new Vector3(Random.Range(-Spread,Spread),Random.Range(-Spread,Spread),Random.Range(-Spread,Spread));
				Vector3 dir = (direction + (ErrorVector.normalized*(Spread/180f)));

				GameObject project = Instantiate(sphere, origin + direction,Quaternion.LookRotation(dir));
				project.name = transform.tag + "Bullet";
				project.GetComponent<Rigidbody>().AddForce(project.transform.forward * force, ForceMode.Impulse);
				project.GetComponent<BulletBehaviour>().damage = this.damage;
				Destroy(project, 2f);
			}
			ShootSoud ();
        }
    }
}
