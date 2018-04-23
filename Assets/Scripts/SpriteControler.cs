using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteControler : MonoBehaviour {

    private SpriteRenderer spriteR;
    public Sprite[] sprites;
    private int spritePos = 0;
    private float deltaDegree;
    private float actualDegree; 
    private float actualRotation;

	// Use this for initialization
	void Start () {
        spriteR = GetComponent<SpriteRenderer>();
		if (sprites.Length <= 0) {
			sprites	= new Sprite[1];
			sprites [0] = spriteR.sprite;
		}
		spriteR.sprite = sprites[0];
		deltaDegree = 360 / sprites.Length;
		actualDegree = transform.eulerAngles.y;
        actualRotation = 0f;
	}
	
	// Update is called once per frame
	void Update () {
        //transform.LookAt(Camera.main.transform.position); // nao deu certo
        transform.forward = Camera.main.transform.forward; // deu certo
        if (Mathf.Abs((transform.eulerAngles.y - actualDegree)) < 350){ 
            actualRotation += actualDegree - transform.eulerAngles.y;
        }
        actualDegree = transform.eulerAngles.y;

        if(actualRotation >= deltaDegree){
            spritePos++;
            actualRotation -= deltaDegree;
            if (spritePos >= sprites.Length){
                spritePos = spritePos - sprites.Length;
            }
            spriteR.sprite = sprites[spritePos];
        }
        else if (actualRotation <= -deltaDegree){
            spritePos--;
            actualRotation += deltaDegree;
            if (spritePos < 0){
                spritePos = sprites.Length + spritePos;
            }
            spriteR.sprite = sprites[spritePos];
        }

    }
}
