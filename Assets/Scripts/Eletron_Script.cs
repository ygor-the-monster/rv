using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Eletron_Script : MonoBehaviour {

	private GameObject pai_Obj;
	private float raio;
	private Vector3 foco;
	private Vector3 eixo_rot;
	private bool aproximar;
	private int direcao;
	private float velocidade;
	private bool pronto;
	private float velocidade_rot;

	public bool chegou(){
		return pronto;
	}

	public void setDisparado(int direcao, float velocidade, float raio, Vector3 foco, GameObject pai_Obj){
		this.pai_Obj = pai_Obj;
		this.raio = raio;
		this.foco = foco;
		aproximar = true;
		this.direcao = direcao;
		this.velocidade = velocidade;
		switch(direcao){
			case 1:
				eixo_rot = new Vector3(0, 1, 0);
			break;
				
			case 2:
				eixo_rot = new Vector3(0, 0, 1);
			break;

			case 3:
				eixo_rot = new Vector3(1, 0, 0);
			break;
		}
	}

	void Awake(){
		aproximar = false;
		pronto = false;
		velocidade_rot = Random.Range(50, 500);
		
	}

	// Use this for initialization
	void Start () {	
	}

	// Update is called once per frame
	void Update () {
		if(aproximar){
			float dist = Vector3.Distance(transform.position, foco);
			if(dist > raio){
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
			}else if(dist <= raio){
				aproximar = false;
				pronto = true;
				transform.SetParent(pai_Obj.transform);
			}
		}else if(pronto){
			this.transform.RotateAround(foco, eixo_rot, velocidade_rot * Time.deltaTime);
		}
	}
}
