using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Jogador : MonoBehaviour {

	public GameObject projetilPrefab;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown (0)) {
			GameObject projetil = Instantiate (projetilPrefab);
			projetil.transform.position = transform.position;
			projetil.transform.forward = transform.forward;
		}
	}

	void OnTriggerEnter(Collider collider) {
		if (collider.CompareTag("Zumbi")) {
			SceneManager.LoadScene (SceneManager.GetActiveScene().buildIndex);
		}
	}
}
