using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Arma : MonoBehaviour {
	/*lui não entendi esse codigo... essa start serve pra achar as outras armas, 
	 * não seria melhor fazer uma "arma controller" pra achar essas armas, em vez 
	 * de uma classe pai para achar? Pq as classes filhas tbm vão ficar tentando 
	 * achar armas filahs apra ter acesso, não faz sentido pra mim...*/
    Arma arma;
	[SerializeField] protected float _Damage;
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
