using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {
	public static Spawner Instance;
	[SerializeField] private GameObject[] EnemysPrefabs;
	public Transform[] SpawnPoints;
	private int rodada = 0;
	private float _timer = 0;
	public float EnemyDelay = 10;

	private GameObject Player;

	void Awake(){
		if (Instance == null) {
			Instance = this;
		}else if (Instance != this) {
			Destroy (gameObject);
		}
		
		//DontDestroyOnLoad (gameObject);
	}

	// Use this for initialization
	void Start () {
		Player = GameObject.FindGameObjectWithTag ("Player");
	}
	
	// Update is called once per frame
	void Update () {
		_timer += Time.deltaTime;
		if (_timer > EnemyDelay + 1) {
			_timer = 0;
			Instantiate(EnemysPrefabs[Random.Range(0,EnemysPrefabs.Length -1)], SpawnPoints[Random.Range(0,SpawnPoints.Length-1)].position, Quaternion.identity);
		}
	}
}
