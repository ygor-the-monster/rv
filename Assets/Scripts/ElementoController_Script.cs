using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElementoController_Script : MonoBehaviour {

	[SerializeField] GameObject nucleo_Inspector;
	[SerializeField] GameObject camada1_Inspector;
	[SerializeField] GameObject camada2_Inspector;
	[SerializeField] GameObject camada3_Inspector;
	[SerializeField] GameObject camada4_Inspector;
	[SerializeField] GameObject camada5_Inspector;
	[SerializeField] GameObject camada6_Inspector;

	private int executando_animacao, nucleo_pronto;
	private bool animacoes_finalizadas;

	private Elemento_Script elemento;

	public bool _finalizado(){
		return animacoes_finalizadas;
	}

    public void set_Elemento(Elemento_Script elemento){
		this.elemento = elemento;
		(nucleo_Inspector.GetComponent(typeof(Nucleo_Script)) as Nucleo_Script).setProtons(elemento.n_atomos_elemA, elemento.n_atomos_elemB);
		(camada1_Inspector.GetComponent(typeof(Camada_Script)) as Camada_Script).setEletrons(elemento.s1);
		(camada2_Inspector.GetComponent(typeof(Camada_Script)) as Camada_Script).setEletrons(elemento.s2);
		(camada3_Inspector.GetComponent(typeof(Camada_Script)) as Camada_Script).setEletrons(elemento.s3);
		(camada4_Inspector.GetComponent(typeof(Camada_Script)) as Camada_Script).setEletrons(elemento.s4);
		(camada5_Inspector.GetComponent(typeof(Camada_Script)) as Camada_Script).setEletrons(elemento.s5);
		(camada6_Inspector.GetComponent(typeof(Camada_Script)) as Camada_Script).setEletrons(elemento.s6);
	}

	void Awake(){
		executando_animacao = 7;
		animacoes_finalizadas = false;
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(!animacoes_finalizadas){
			nucleo_pronto = (nucleo_Inspector.GetComponent(typeof(Nucleo_Script)) as Nucleo_Script).pronto();

			if(nucleo_pronto == 0){
				(nucleo_Inspector.GetComponent(typeof(Nucleo_Script)) as Nucleo_Script).animacao();

			}else if(executando_animacao <= 6){
				switch(executando_animacao){
					case 1:
						(camada1_Inspector.GetComponent(typeof(Camada_Script)) as Camada_Script).animacao();
						executando_animacao += (camada1_Inspector.GetComponent(typeof(Camada_Script)) as Camada_Script).pronto();
					break;
						
					case 2:
						(camada2_Inspector.GetComponent(typeof(Camada_Script)) as Camada_Script).animacao();
						executando_animacao += (camada2_Inspector.GetComponent(typeof(Camada_Script)) as Camada_Script).pronto();
					break;

					case 3:
						(camada3_Inspector.GetComponent(typeof(Camada_Script)) as Camada_Script).animacao();
						executando_animacao += (camada3_Inspector.GetComponent(typeof(Camada_Script)) as Camada_Script).pronto();
					break;

					case 4:
						(camada4_Inspector.GetComponent(typeof(Camada_Script)) as Camada_Script).animacao();
						executando_animacao += (camada4_Inspector.GetComponent(typeof(Camada_Script)) as Camada_Script).pronto();
					break;
					
					case 5:
						(camada5_Inspector.GetComponent(typeof(Camada_Script)) as Camada_Script).animacao();
						executando_animacao += (camada5_Inspector.GetComponent(typeof(Camada_Script)) as Camada_Script).pronto();
					break;

					case 6:
						(camada6_Inspector.GetComponent(typeof(Camada_Script)) as Camada_Script).animacao();
						executando_animacao += (camada6_Inspector.GetComponent(typeof(Camada_Script)) as Camada_Script).pronto();
					break;
				}
				if(executando_animacao == 7){
					animacoes_finalizadas = true;
				}
			}else if(nucleo_pronto == 1){
				executando_animacao = 1;
			}
		}
	}
}
