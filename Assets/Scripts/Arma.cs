using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Arma : MonoBehaviour {

    protected GameObject sphere;

	[SerializeField] protected float damage;

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
