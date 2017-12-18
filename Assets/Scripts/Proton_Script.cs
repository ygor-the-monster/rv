using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Proton_Script : MonoBehaviour {

	private GameObject alvo;
	private bool disparado;
	private bool colidiu_no_alvo;
	private int direcao;
	private float velocidade;

	public void setDisparado(int direcao, float velocidade, GameObject alvo){
		 this.direcao = direcao;
		 this.velocidade = velocidade;
		 this.alvo = alvo;
		 disparado = true;
		 colidiu_no_alvo = false;
	}

	public bool colidiu(){
		return colidiu_no_alvo;
	}

	void OnTriggerEnter(Collider collider){
		if(collider.gameObject.tag.Equals("Nucleo") || collider.gameObject.tag.Equals("Proton")){
			velocidade = 0f;
			this.transform.SetParent(alvo.transform);
			disparado = false;
			colidiu_no_alvo = true;
		}
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(disparado){
			//se mover até o núcleo
			switch(direcao){
				case 1:
					transform.position = new Vector3(transform.position.x + velocidade, 0f, 0f);
				break;
					
				case 2:
					transform.position = new Vector3(0f, transform.position.y + velocidade, 0f);
				break;

				case 3:
					transform.position = new Vector3(0f, 0f, transform.position.z + velocidade);
				break;
			}
		}
	}
}
