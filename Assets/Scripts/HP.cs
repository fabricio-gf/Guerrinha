using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HP : MonoBehaviour {
	private float _actualHP;
	[SerializeField] private float _MaxHP = 100f;

	// Use this for initialization
	void Start () {
		_actualHP = _MaxHP;
	}

	public void TakeDamage(float damage){
		_actualHP -= damage;
		if (_actualHP <= 0f) {
			Destroy (gameObject);
		}
	}
}
