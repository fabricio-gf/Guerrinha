using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour {
	private NavMeshAgent _myAgent;
	private Transform _Player;

	public bool _Debug;
	// Use this for initialization
	void Start () {
		_myAgent = GetComponent<NavMeshAgent> ();
		_Player = GameObject.FindGameObjectWithTag ("Player").transform;
	}
	
	// Update is called once per frame
	void Update () {
		if (CanSeeTarget ()) {
			_myAgent.destination = _Player.position;
		}
	}

	bool CanSeeTarget (){
		RaycastHit hit;
		Vector3 dir = _Player.transform.position - gameObject.transform.position;

		if (Physics.Raycast (transform.position, dir, out hit)) {
			if(_Debug) Debug.DrawRay (transform.position, dir.normalized * hit.distance, Color.red);
			if (hit.collider.gameObject.tag == "Player") {
				return true;
			}
		}
		return false;
	}
}
