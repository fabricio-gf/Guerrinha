using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Arma : MonoBehaviour {
 
	[SerializeField] protected float damage;
    public abstract void Shoot();
 
}
