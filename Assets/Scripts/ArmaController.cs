using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmaController : MonoBehaviour {
	//lista de referencia para todas as armas(scripts/componnetes) que este objeto possui
	[SerializeField] private List<Arma> _ArmaList;
    public Sprite[] sprites;
    private SpriteRenderer spriteR;
    private bool[] armasUsaveis;
	//indice da arma atualmente selecionada;
	private int _ActualWepon;

	// Use this for initialization
	void Start () {
        spriteR = GetComponent<SpriteRenderer>();
		Arma[] armas = GetComponents<Arma> ();
        armasUsaveis = new bool[armas.Length];
		foreach(Arma a in armas){
			_ArmaList.Add (a);
		}
		_ActualWepon = 0;
        armasUsaveis[0] = true;
        armasUsaveis[1] = true;
        armasUsaveis[2] = true;
    }
	
	// Update is called once per frame
	void Update () {
		//selecionando a arma que foi atirada
		for(int i = 0; i < _ArmaList.Count; i++) {
			if(Input.GetKeyDown((i+1).ToString()) && armasUsaveis[i] == true){
				_ActualWepon = i;
                spriteR.sprite = sprites[i];				
				break;
			}
		}
		_ArmaList [_ActualWepon].Shoot ();
	}
}
