using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camada_Script : MonoBehaviour {

	[SerializeField] GameObject canhao1_Inspector;
	[SerializeField] GameObject canhao2_Inspector;
	[SerializeField] GameObject canhao3_Inspector;
	[SerializeField] GameObject canhao4_Inspector;
	[SerializeField] GameObject canhao5_Inspector;
	[SerializeField] GameObject canhao6_Inspector;

	private bool finalizada, executando;
	private int n_eletrons;
	private int eletrons_disparados;
	private float raio;
	private Vector3 foco;

	public void animacao(float raio, Vector3 foco){
		if(this.raio == -1f){
			this.raio = raio;
			this.foco = foco;
		}
		if(n_eletrons > 0 && eletrons_disparados != n_eletrons){
			executando = true;
		}else{
			finalizada = true;
		}
	}

	public int pronto(){
		return finalizada ? 1 : 0;
	}

    public void setEletrons(int n_eletrons){
		this.n_eletrons = n_eletrons;
	}

	void Awake(){
		raio = -1f;
		finalizada = false;
		executando = false;
		eletrons_disparados = 0;
	}

	// Use this for initialization
	void Start () {
		
	}
	
	//int cont = 0;
	// Update is called once per frame
	void Update () {
		if(executando){
			switch(Random.Range(1, 6)){
				case 1:
					(canhao1_Inspector.GetComponent(typeof(Canhao_Script)) as Canhao_Script).disparar_eletron(raio, foco, this.gameObject);
				break;

				case 2:
					(canhao2_Inspector.GetComponent(typeof(Canhao_Script)) as Canhao_Script).disparar_eletron(raio, foco, this.gameObject);
				break;

				case 3:
					(canhao3_Inspector.GetComponent(typeof(Canhao_Script)) as Canhao_Script).disparar_eletron(raio, foco, this.gameObject);
				break;

				case 4:
					(canhao4_Inspector.GetComponent(typeof(Canhao_Script)) as Canhao_Script).disparar_eletron(raio, foco, this.gameObject);
				break;

				case 5:
					(canhao5_Inspector.GetComponent(typeof(Canhao_Script)) as Canhao_Script).disparar_eletron(raio, foco, this.gameObject);
				break;

				case 6:
					(canhao6_Inspector.GetComponent(typeof(Canhao_Script)) as Canhao_Script).disparar_eletron(raio, foco, this.gameObject);
				break;
			}
			eletrons_disparados++;
			if(eletrons_disparados == n_eletrons){
				executando = false;
				finalizada = true;
			}
		}
	}
}
