using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMetralhadora : EnemyArma{

    GameObject bullet;
    private float timer = 0f;
    [SerializeField] private float shootDelay = 0.1f;
    [SerializeField] private float force = 100;

    // Use this for initialization
    void Start(){
		bullet = (GameObject)Resources.Load("Bullet", typeof(GameObject));
    }

    // Update is called once per frame
    void Update(){
        timer -= Time.deltaTime;
    }

	public override void Shoot(Vector3 origin, Vector3 direction) {
		if (timer <= 0f) {
			timer = shootDelay;
			GameObject project = Instantiate(bullet, origin + direction.normalized, Quaternion.LookRotation(direction.normalized));
			project.name = transform.tag + "Bullet";
			project.GetComponent<Rigidbody>().AddForce(direction.normalized * force, ForceMode.Impulse);
			project.GetComponent<BulletBehaviour> ().damage = this.damage;
			Destroy(project, 2f);
			ShootSoud ();
		}
    }
}
