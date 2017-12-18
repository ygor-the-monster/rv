using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elemento_Script{
	public int s1, s2, s3, s4, s5, s6; //eletrons das camadas de valência
	public int n_atomos_elemA, n_atomos_elemB; //números de átomos de cada elemento da combinação
	public string nome, elem1, elem2;

	public Elemento_Script(int n_atomos_elemA, int n_atomos_elemB, int s1, int s2, int s3, int s4, int s5, int s6, string nome, string elem1, string elem2){
		this.n_atomos_elemA = n_atomos_elemA; 
		this.n_atomos_elemB = n_atomos_elemB;
		this.s1 = s1;
		this.s2 = s2; 
		this.s3 = s3; 
		this.s4 = s4;
		this.s5 = s5; 
		this.s6 = s6;
		this.nome = nome;
		this.elem1 = elem1;
		this.elem2 = elem2;
	}
}

public class SystemController_Script : MonoBehaviour {

	#region Efeitos visuais do componente químico
	[SerializeField] GameObject elemento_Prefab; //prefab do elemento
	[SerializeField] GameObject canvas; //GUI

	private GameObject elemento_Instancia; //elemento que é mantido no estado atual da execução
	
	public void novo_Elemento(Elemento_Script elemento){
		if(elemento_Instancia != null){
			Destroy(elemento_Instancia);
		}
		if(elemento == null){
			(canvas.GetComponent(typeof(Canvas_Script)) as Canvas_Script).setGUI(null);	
			return;
		}
		elemento_Instancia = Instantiate(elemento_Prefab, Vector3.zero, Quaternion.identity);
		(elemento_Instancia.GetComponent(typeof(ElementoController_Script)) as ElementoController_Script).set_Elemento(elemento);
		(canvas.GetComponent(typeof(Canvas_Script)) as Canvas_Script).setGUI(elemento);
		elemento_Instancia.SetActive(true);
	}

	//### ATENÇÃO ###\\ 
	/*
	%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%
	%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%
	%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%// Funções para a animação \\%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%
	//Gera um novo elemento na tela, se um elemento já existir ele o substitui com o novo
	novo_Elemento(new Elemento_Script(10, 10, 3, 4, 0, 6, 0, 8, "CO2", "C", "O2")); 

	//Deixa a visão limpa apagando o elemento do instante atual da tela
	novo_Elemento(null);
	%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%
	%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%
	%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%
	%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%//Código para teste (Inserir na rotina Update)\\%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%
		if(Input.GetKeyDown(KeyCode.J)){
			//Inicia vizualização de acordo como a instancia do elemento passado por parâmetro se pressionar J no teclado 
			novo_Elemento(new Elemento_Script(10, 10, 3, 4, 0, 6, 0, 8, "CO2", "C", "O2"));
		}
		if(Input.GetKeyDown(KeyCode.K)){
			//Destroi elemento do estado atual e sua vizualização se pressionar K no teclado
			novo_Elemento(null);
		}
	%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%
	%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%
	%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%
	*/
	#endregion


	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	}
}
