using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elemento_Script{
	public int s1, s2, s3, s4, s5, s6; //eletrons das camadas de valência
	public int n_atomos_elemA, n_atomos_elemB; //números de átomos de cada elemento da combinação

	public Elemento_Script(int n_atomos_elemA, int n_atomos_elemB, int s1, int s2, int s3, int s4, int s5, int s6){
		this.n_atomos_elemA = n_atomos_elemA; 
		this.n_atomos_elemB = n_atomos_elemB;
		this.s1 = s1;
		this.s2 = s2; 
		this.s3 = s3; 
		this.s4 = s4;
		this.s5 = s5; 
		this.s6 = s6;
	}
}

public class SystemController_Script : MonoBehaviour {

	[SerializeField] GameObject elemento_Prefab; //prefab do elemento

	private GameObject elemento_Instancia; //elemento que é mantido no estado atual da execução
	
	public void novo_Elemento(Elemento_Script elemento){
		elemento_Instancia = Instantiate(elemento_Prefab, Vector3.zero, Quaternion.identity);
		(elemento_Instancia.GetComponent(typeof(ElementoController_Script)) as ElementoController_Script).set_Elemento(elemento);
	}

	// Use this for initialization
	void Start () {
		elemento_Prefab.SetActive(false); // Apagar essa linha depois
		novo_Elemento(new Elemento_Script(1, 2, 3, 4, 0, 6, 0, 8));  // Apagar essa linha depois
		elemento_Instancia.SetActive(true); // Apagar essa linha depois
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
