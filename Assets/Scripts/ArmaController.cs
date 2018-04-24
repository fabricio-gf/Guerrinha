using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ArmaController : MonoBehaviour {
	//lista de referencia para todas as armas(scripts/componnetes) que este objeto possui
	[SerializeField]private List<Arma> _ArmaList;
	//indice da arma atualmente selecionada;
	private int _ActualWeapon;
    // indice de armas que podem ser usadas
    public bool[] armasUsaveis;
    // arma na mao;
    public Image holdingWeapon;

    [SerializeField] Sprite[] sprites;

	// Use this for initialization
	void Start () {
        holdingWeapon.sprite = sprites[0];
        Arma[] armas = GetComponents<Arma> ();
        armasUsaveis = new bool[armas.Length];
		foreach(Arma a in armas){
			_ArmaList.Add (a);
		}
		_ActualWeapon = 0;
		armasUsaveis[0] = true;
		armasUsaveis[1] = true;
		armasUsaveis[2] = true;

    }
	
	// Update is called once per frame
	void Update () {
		//selecionando a arma que foi atirada
		for(int i = 0; i < _ArmaList.Count; i++) {
			if(Input.GetKeyDown((i+1).ToString()) && armasUsaveis[i] == true){
				_ActualWeapon = i;
                holdingWeapon.sprite = sprites[i];
				break;
			}
		}
		_ArmaList [_ActualWeapon].Shoot ();
        if (Input.GetKeyDown(KeyCode.R)) {
            _ArmaList[_ActualWeapon].Reload();
        }
	}

    public void getAmmo(int i){
        _ArmaList[i].GetAmmo();
    }

}
