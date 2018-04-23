using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundWeapon : MonoBehaviour {

    [SerializeField] int weapon;
    ArmaController arma;

	// Use this for initialization
	void Start () {
	}

    // Update is called once per frame
    void OnTriggerEnter(Collider col) {
        if (col.CompareTag("Player")) {
            arma = col.GetComponent<ArmaController>();
            if (arma.armasUsaveis[weapon] == false) {
                arma.armasUsaveis[weapon] = true;
            }
            else {
                arma.getAmmo(weapon);
                Destroy(gameObject);
            }
        }
    }
}
