using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Arma : MonoBehaviour {

    protected GameObject sphere;

	[SerializeField] protected float damage;
	[SerializeField] private AudioClip[] ShootAudioClips;
	[SerializeField] private AudioClip ReloadAudioClip;
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
	}
 

    [SerializeField] protected int clipAmmo;
    protected int ammoLeft;
    [SerializeField] protected int totalAmmo;

    [SerializeField] protected float reloadTime;

    [SerializeField] protected int groundBullets;

    protected float timer;

    public abstract void Shoot();

    // Use this for initialization
    void Start() {
        timer = 0;
        ammoLeft = clipAmmo;
        sphere = (GameObject)Resources.Load("Bullet", typeof(GameObject));
    }

    public void GetAmmo() {
        totalAmmo += groundBullets;
    }

    public void Reload() {
		_MAudioSource.PlayOneShot(ReloadAudioClip);
        if (totalAmmo > 0) {
            if (clipAmmo - ammoLeft > totalAmmo) {
                ammoLeft += totalAmmo;
                totalAmmo = 0;
            }
            else {
                totalAmmo -= clipAmmo - ammoLeft;
                ammoLeft = clipAmmo;
            }
            timer = reloadTime;
        }
    }
}
