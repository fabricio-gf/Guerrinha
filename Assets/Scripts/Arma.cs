using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Arma : MonoBehaviour {

    Arma arma;

    public abstract void Shoot();
  
	// Use this for initialization
	void Start () {
        int i;
        for ( i=0; i < transform.childCount; i++){
            arma = transform.GetChild(i).gameObject.GetComponent<Arma>();
            if (arma.gameObject.activeSelf) {
                break;
            }
        }
        for (; i<transform.childCount;i++){
            transform.GetChild(i).gameObject.SetActive(false);
        }
	}
	
	// Update is called once per frame
	void Update () {
        arma.Shoot();
	}
}
