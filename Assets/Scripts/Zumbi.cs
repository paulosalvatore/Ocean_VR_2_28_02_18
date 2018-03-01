using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zumbi : MonoBehaviour {

	private bool andando;

	public int vidas = 2;

	public float delayAndar = 1f;
	public float delayRecuperacao = 1f;

	public Animator animator;
	public Rigidbody rb;

	public Transform jogador;
	public float velocidade = 0.35f;

	// Use this for initialization
	void Start () {
		jogador = GameObject.Find ("Jogador").transform;

		transform.LookAt (jogador);

		Invoke ("Andar", delayAndar);
	}
	
	// Update is called once per frame
	void Update () {
		if (andando) {
			rb.velocity = (jogador.position - transform.position).normalized * velocidade;
		}
	}

	void Andar () {
		andando = true;
	}

	void AplicarDano ()
	{
		vidas = vidas - 1;
		animator.SetTrigger ("Damage");
		andando = false;
		Invoke ("Andar", delayRecuperacao);
	}

	void Matar ()
	{
		vidas = vidas - 1;
		animator.SetTrigger ("Die");
		andando = false;
	}

	void OnTriggerEnter(Collider colisor) {
		if (andando && colisor.CompareTag ("Projétil")) {
			Destroy (colisor.gameObject);

			if (vidas > 1) {
				AplicarDano ();
			} else {
				Matar ();
			}
		}
	}
}
