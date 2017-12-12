using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nucleo_Script : MonoBehaviour {

	[SerializeField] GameObject esfera_Inspector;
	private List<GameObject> protons = new List<GameObject>();

	private int n_protons;
	private bool finalizada, executando;

	public void animacao(){
		executando = true;
	}

	public int pronto(){
		return finalizada ? 1 : 0;
	}

	private void posicoes(){
		
	}

	public void setProtons(int elem_a, int elem_b){
		this.n_protons = elem_a + elem_b;
		for(int i = 0; i < n_protons; i++){
			protons.Add(Instantiate(esfera_Inspector, Vector3.zero, Quaternion.identity) as GameObject);
			protons[i].transform.SetParent(this.transform);
			protons[i].SetActive(false);
		}
	}

	void Awake(){
		finalizada = false;
		executando = false;
	}

	// Use this for initialization
	void Start () {
		
	}
	
	//int cont = 0;
	// Update is called once per frame
	void Update () {
		if(executando){

			/*if(cont == 10){
				Debug.Log("Nucleo Pronto");
				executando = false;
				finalizada = true;
			}
			cont++;*/
			//incrementar posicao das esferas para fazer a animacao
			//quando terminar definir finalizada = true executando = false
		}
	}
}
