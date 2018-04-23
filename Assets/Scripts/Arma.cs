using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Arma : MonoBehaviour {
 
	[SerializeField] protected float damage;
	[SerializeField] private AudioClip[] ShootAudioClips;
	private AudioSource _MAudioSource;
    public abstract void Shoot();

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
	}
 
}
