using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Canvas_Script : MonoBehaviour {
	[SerializeField] GameObject nome_Composto;
	[SerializeField] GameObject elem1;
	[SerializeField] GameObject elem2;
	[SerializeField] GameObject s1;
	[SerializeField] GameObject s2;
	[SerializeField] GameObject s3;
	[SerializeField] GameObject s4;
	[SerializeField] GameObject s5;
	[SerializeField] GameObject s6;

	public void setGUI(Elemento_Script e){
		if(e == null){
			nome_Composto.GetComponent<UnityEngine.UI.Text>().text = "Nome: ";
			elem1.GetComponent<UnityEngine.UI.Text>().text = "Composto A: ";
			elem2.GetComponent<UnityEngine.UI.Text>().text = "Composto B: ";
			s1.GetComponent<UnityEngine.UI.Text>().text = "S1: ";
			s2.GetComponent<UnityEngine.UI.Text>().text = "S2: ";
			s3.GetComponent<UnityEngine.UI.Text>().text = "S3: ";
			s4.GetComponent<UnityEngine.UI.Text>().text = "S4: ";
			s5.GetComponent<UnityEngine.UI.Text>().text = "S5: ";
			s6.GetComponent<UnityEngine.UI.Text>().text = "S6: ";
			return;
		}

		nome_Composto.GetComponent<UnityEngine.UI.Text>().text = "Nome: " + e.nome;
		elem1.GetComponent<UnityEngine.UI.Text>().text = "Composto A: " + e.elem1;
		elem2.GetComponent<UnityEngine.UI.Text>().text = "Composto B: " + e.elem2;
		s1.GetComponent<UnityEngine.UI.Text>().text = "S1: " + e.s1 + " eletrons";
		s2.GetComponent<UnityEngine.UI.Text>().text = "S2: " + e.s2 + " eletrons";
		s3.GetComponent<UnityEngine.UI.Text>().text = "S3: " + e.s3 + " eletrons";
		s4.GetComponent<UnityEngine.UI.Text>().text = "S4: " + e.s4 + " eletrons";
		s5.GetComponent<UnityEngine.UI.Text>().text = "S5: " + e.s5 + " eletrons";
		s6.GetComponent<UnityEngine.UI.Text>().text = "S6: " + e.s6 + " eletrons";
	}


	// Use this for initialization
	void Start () {
		setGUI(null); //De início a GUI não tem nada para exibir além das legendas
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
