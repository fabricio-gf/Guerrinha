using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HP : MonoBehaviour {
	private float _actualHP;
	[SerializeField] private float _MaxHP = 100f;
	private Image hpbar;

	// Use this for initialization
	void Start () {
		_actualHP = _MaxHP;
		if (gameObject.CompareTag ("Player")) {
			hpbar = GameObject.FindGameObjectWithTag ("hpbar").GetComponent<Image>();
		}
	}

	public void TakeDamage(float damage){
		_actualHP -= damage;
		if (hpbar != null) {
			hpbar.fillAmount = _actualHP / _MaxHP;
		}
		if (_actualHP <= 0f) {
			Destroy (gameObject);
		}
	}
}
