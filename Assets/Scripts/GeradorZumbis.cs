using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeradorZumbis : MonoBehaviour {

	public GameObject zumbiPrefab;

	public float intervalo;
	public float area;

	// Use this for initialization
	void Start () {
		InvokeRepeating ("CriarZumbi", 0f, intervalo);
	}

	void CriarZumbi() {
		GameObject zumbi = Instantiate (zumbiPrefab);
		Vector2 posicaoAleatoria = Random.insideUnitCircle.normalized * area;
		zumbi.transform.position = new Vector3 (posicaoAleatoria.x, 0f, posicaoAleatoria.y);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
