using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Canhao_Script : MonoBehaviour {

	[SerializeField] GameObject proton_Inspector;
	[SerializeField] GameObject eletron_Inspector;

	private const float diametro_eletron = 0.5f;
	private const float diametro_proton = 1f;
	private const float sentido_contrario = -1f;
	private int direcao_disparo;
	private int sentido_disparo;
	private const float velocidade_disparo = 0.7f;
	private GameObject disparado;

	private void setDirecao_disparo(){
		if(this.transform.position.x != 0f){
			direcao_disparo = 1;
			sentido_disparo = this.transform.position.x < 0 ? 1 : -1;
		}else if(this.transform.position.y != 0f){
			direcao_disparo = 2;
			sentido_disparo = this.transform.position.y < 0 ? 1 : -1;
		}else if(this.transform.position.z != 0f){
			direcao_disparo = 3;
			sentido_disparo = this.transform.position.z < 0 ? 1 : -1;
		}
	}

	public bool atingiu_alvo(){
		if(disparado.tag.Equals("Proton")){
			return (disparado.GetComponent(typeof(Proton_Script)) as Proton_Script).colidiu();
		}
		return false;
	}

	public void disparar_eletron(float raio, Vector3 foco, GameObject pai){
		GameObject eletron_projetil = null;
		eletron_projetil = Instantiate(eletron_Inspector, transform.position, Quaternion.identity) as GameObject;
		eletron_projetil.transform.localScale = new Vector3(diametro_eletron, diametro_eletron, diametro_eletron);
		(eletron_projetil.GetComponent(typeof(Eletron_Script)) as Eletron_Script).setDisparado(direcao_disparo, velocidade_disparo * sentido_disparo, raio, foco, pai);
	}

	public void disparar_proton(GameObject alvo, Material material){
		GameObject proton_projetil = null;
		proton_projetil = Instantiate(proton_Inspector, transform.position, Quaternion.identity) as GameObject;
		proton_projetil.transform.localScale = new Vector3(diametro_proton, diametro_proton, diametro_proton);
		proton_projetil.GetComponent<SphereCollider>().radius = diametro_proton / 2f;
		Renderer r = proton_projetil.GetComponent<Renderer>();
		r.enabled = true;
		r.sharedMaterial = material;
		disparado = proton_projetil;
		(proton_projetil.GetComponent(typeof(Proton_Script)) as Proton_Script).setDisparado(direcao_disparo, velocidade_disparo * sentido_disparo, alvo);
	}

	void Awake(){
		setDirecao_disparo();
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
