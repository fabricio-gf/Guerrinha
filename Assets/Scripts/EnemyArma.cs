using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyArma : MonoBehaviour {
	[SerializeField] protected float damage;

	public abstract void Shoot(Vector3 origin, Vector3 direction);

}
