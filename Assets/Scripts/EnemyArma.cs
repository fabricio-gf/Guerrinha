using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyArma : MonoBehaviour {

    [SerializeField] protected float damage;
	public abstract void Shoot(Vector3 origin, Vector3 direction);
	[SerializeField] private AudioClip[] ShootAudioClips;

	private AudioSource _MAudioSource;

	protected void ShootSoud(){
		if (_MAudioSource == null) {
			if (ShootAudioClips.Length > 0) {
				_MAudioSource = GetComponent<AudioSource> ();
				_MAudioSource.loop = false;
			} else {
				this.enabled = false;
			}
		}
		_MAudioSource.clip = ShootAudioClips [Random.Range (0, ShootAudioClips.Length - 1)];
		_MAudioSource.PlayOneShot(_MAudioSource.clip);
		Debug.Log ("PAPAPAPPAPAPPA");
	}

}
