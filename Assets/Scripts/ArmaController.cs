using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmaController : MonoBehaviour {
	//lista de referencia para todas as armas(scripts/componnetes) que este objeto possui
	[SerializeField]private List<Arma> _ArmaList;
	//indice da arma atualmente selecionada;
	private int _ActualWepon;
    // indice de armas que podem ser usadas
    public bool[] armasUsaveis;

	// Use this for initialization
	void Start () {
		Arma[] armas = GetComponents<Arma> ();
        armasUsaveis = new bool[armas.Length];
		foreach(Arma a in armas){
			_ArmaList.Add (a);
		}
		_ActualWepon = 0;
        armasUsaveis[0] = true;
    }
	
	// Update is called once per frame
	void Update () {
		//selecionando a arma que foi atirada
		for(int i = 0; i < _ArmaList.Count; i++) {
			if(Input.GetKeyDown((i+1).ToString()) && armasUsaveis[i] == true){
				_ActualWepon = i;			
				break;
			}
		}
		_ArmaList [_ActualWepon].Shoot ();
        if (Input.GetKeyDown(KeyCode.R)) {
            _ArmaList[_ActualWepon].Reload();
        }
	}

    public void getAmmo(int i){
        _ArmaList[i].GetAmmo();
    }

}
