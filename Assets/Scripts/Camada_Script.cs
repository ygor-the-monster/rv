using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camada_Script : MonoBehaviour {

	[SerializeField] GameObject esfera_Inspector;
	private List<GameObject> eletrons = new List<GameObject>();
	private bool finalizada, executando;
	private int n_eletrons;

	public void animacao(){
		if(!finalizada){
			executando = true;
		}
	}

	public int pronto(){
		return finalizada ? 1 : 0;
	}

    public void setEletrons(int n_eletrons){
		//Se o número de elétrons for zero não há nada para executar
		if(n_eletrons == 0){
			this.n_eletrons = 0;
			executando = false;
			finalizada = true;
			return;
		}
		this.n_eletrons = n_eletrons;
		for(int i = 0; i < this.n_eletrons; i++){
			eletrons.Add(Instantiate(esfera_Inspector, Vector3.zero, Quaternion.identity) as GameObject);
			eletrons[i].SetActive(false);
			eletrons[i].transform.SetParent(transform);
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
			
			/*if(cont == 120){
				Debug.Log("Camada Pronto");
				executando = false;
				finalizada = true;
			}
			cont++;*/
			//incrementar posição de cada esfera da camada
			//se a posição final de todas for atingida executar = false e finalizada = true;
		}
	}
}
