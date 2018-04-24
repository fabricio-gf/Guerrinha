using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour {
	private NavMeshAgent _myAgent;
	private Transform _Player;
	private EnemyArma _Arma;
	public bool _DrawDebugLine;
	public float ErrorRange = 0.5f;
	public GameObject drop;

	// Use this for initialization
	void Start () {
		_myAgent = GetComponent<NavMeshAgent> ();
		_Player = GameObject.FindGameObjectWithTag ("Player").transform;
		_Arma = GetComponent<EnemyArma> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (CanSeeTarget ()) {
			_myAgent.destination = _Player.position;
			//atirar
			Vector3 origin = transform.position + (Vector3.up/2f);
			Vector3 ErrorVector = new Vector3(Random.Range(-ErrorRange,ErrorRange),Random.Range(-ErrorRange,ErrorRange),Random.Range(-ErrorRange,ErrorRange));
			Vector3 dir = (_Player.transform.position + ErrorVector + (Vector3.up/2f)) - origin;
			if(_DrawDebugLine) Debug.DrawRay (origin, dir, Color.red);
			_Arma.Shoot(origin, dir);
		}
	}

	bool CanSeeTarget (){
		RaycastHit hit;
		Vector3 origin = transform.position + (Vector3.up/2f);
		Vector3 dir = _Player.transform.position - gameObject.transform.position;

		if (Physics.Raycast (origin, dir, out hit)) {
			if(_DrawDebugLine) Debug.DrawRay (origin, dir.normalized * hit.distance, Color.green);
			if (hit.collider.gameObject.tag == "Player") {
				return true;
			}
		}
		return false;
	}

	void OnDestroy() {
		print(name + " was destroyed");
		if(drop!=null)Instantiate (drop).transform.position = transform.position - Vector3.up;

	}

	void OnTriggerEnter(Collider col){
		if (col.CompareTag ("Bullet") && !col.name.Contains (transform.tag)) {
			Debug.Log ("AI");
		}
	}
}
