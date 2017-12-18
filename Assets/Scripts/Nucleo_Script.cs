using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nucleo_Script : MonoBehaviour {

	[SerializeField] GameObject esfera_Inspector;
	[SerializeField] GameObject canhao1_Inspector;
	[SerializeField] GameObject canhao2_Inspector;
	[SerializeField] GameObject canhao3_Inspector;
	[SerializeField] GameObject canhao4_Inspector;
	[SerializeField] GameObject canhao5_Inspector;
	[SerializeField] GameObject canhao6_Inspector;
	[SerializeField] Material[] materiais;

	private GameObject nucleo_go;
	private GameObject _nucleo_invisivel;
	private int n_protons;
	private bool finalizada, executando;
	private Canhao_Script canhao_da_vez = null;
	private bool vermelho_azul = false; //false azul, true vermelho

	public void animacao(){
		executando = true;
	}

	public int pronto(){
		return finalizada ? 1 : 0;
	}

	public void setProtons(int elem_a, int elem_b, GameObject nucleo_go){
		this.n_protons = elem_a + elem_b;
		this.nucleo_go = nucleo_go;
	}

	private void disparar(){
		Material color;
		if(!vermelho_azul){
			color = materiais[0];
		}else{
			color = materiais[1];
		}
		vermelho_azul = !vermelho_azul;

		switch(Random.Range(1, 6)){
			case 1:
				canhao_da_vez = canhao1_Inspector.GetComponent(typeof(Canhao_Script)) as Canhao_Script;
				canhao_da_vez.disparar_proton(nucleo_go, color);
			break;

			case 2:
				canhao_da_vez = canhao2_Inspector.GetComponent(typeof(Canhao_Script)) as Canhao_Script;
				canhao_da_vez.disparar_proton(nucleo_go, color);
			break;

			case 3:
				canhao_da_vez = canhao3_Inspector.GetComponent(typeof(Canhao_Script)) as Canhao_Script;
				canhao_da_vez.disparar_proton(nucleo_go, color);
			break;

			case 4:
				canhao_da_vez = canhao4_Inspector.GetComponent(typeof(Canhao_Script)) as Canhao_Script;
				canhao_da_vez.disparar_proton(nucleo_go, color);
			break;

			case 5:
				canhao_da_vez = canhao5_Inspector.GetComponent(typeof(Canhao_Script)) as Canhao_Script;
				canhao_da_vez.disparar_proton(nucleo_go, color);
			break;

			case 6:
				canhao_da_vez = canhao6_Inspector.GetComponent(typeof(Canhao_Script)) as Canhao_Script;
				canhao_da_vez.disparar_proton(nucleo_go, color);
			break;
		}
		protons_disparados++;
		if(protons_disparados == n_protons){
			executando = false;
			finalizada = true;
		}
	}

	void Awake(){
		finalizada = false;
		executando = false;
	}

	// Use this for initialization
	void Start () {
		
	}
	
	#region Variaveis do Update
	 	private int protons_disparados = 0;	
	#endregion
	
	// Update is called once per frame
	void Update () {
		if(executando){
			if(canhao_da_vez == null){
				disparar();
			}else{
				if(canhao_da_vez.atingiu_alvo()){
					disparar();
				}
			}		
		}

		transform.Rotate (50 * Time.deltaTime, 50 * Time.deltaTime, 50 * Time.deltaTime);
	}
}
