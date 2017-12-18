using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using System.IO;
using Vuforia;

[System.Serializable]
public class Elementos
{
	public Elemento[] elementos;
}
	
[System.Serializable]
public class Combinacao
{
	public string other;
	public string result;
}


[System.Serializable]
public class Elemento
{
	public string nome;
	public string simbolo;
	public int protons;
	public int neutrons;
	public int[] eletrons;
	public Combinacao[] combinacoes;
}

public class Marcadores : MonoBehaviour, ITrackableEventHandler
{
		
	public int Elemento;

	private string DataFileName = "elementos.json";
	private Elemento Atomo;

	private TrackableBehaviour mTrackableBehaviour;
	     
	private static string Elemento1, Elemento2;
	private int posicao;

	void Start ()
	{
		mTrackableBehaviour = GetComponent<TrackableBehaviour> ();
		if (mTrackableBehaviour) {
			mTrackableBehaviour.RegisterTrackableEventHandler (this);
		}
		string filePath = Path.Combine (Application.streamingAssetsPath, DataFileName);
				
		string dataAsJson = File.ReadAllText (filePath);
				
		Elementos array = JsonUtility.FromJson<Elementos> (dataAsJson);
		this.Atomo = array.elementos [this.Elemento];
	}

	public void OnTrackableStateChanged (
		TrackableBehaviour.Status previousStatus,
		TrackableBehaviour.Status newStatus)
	{
		if (newStatus == TrackableBehaviour.Status.DETECTED ||
		            newStatus == TrackableBehaviour.Status.TRACKED) {
			if (string.IsNullOrEmpty(Elemento1)) {
				Elemento1 = this.Atomo.simbolo;
				posicao = 1;
			} else if (string.IsNullOrEmpty(Elemento2)) {
				Elemento2 = this.Atomo.simbolo;
				posicao = 2;
			}
		} else {
			if (posicao == 1) {
				Elemento1 = null;
				posicao = 0;
			} else if (posicao == 2) {
				Elemento2 = null;
				posicao = 0;
			}
		}
	}

	void OnGUI ()
	{
		if (posicao != 0) {
			GUI.Box (new Rect (posicao == 1? 0 : Screen.width - 90, 0, 90, 25), this.Atomo.nome);
			GUI.Box (new Rect (posicao == 1? 0 : Screen.width - 90, 25, 90, 25), "Simbolo:" + this.Atomo.simbolo);
			GUI.Box (new Rect (posicao == 1? 0 : Screen.width - 90, 50, 90, 25), "Protons:" + this.Atomo.protons);
			GUI.Box (new Rect (posicao == 1? 0 : Screen.width - 90, 75, 90, 25), "Neutrons:" + this.Atomo.neutrons);
			GUI.Box (new Rect (posicao == 1? 0 : Screen.width - 90, 100, 90, 50), "Eletrons:\nK" + this.Atomo.eletrons[0] + " L" +  this.Atomo.eletrons[1] + " M" +  this.Atomo.eletrons[2] + " N" +  this.Atomo.eletrons[3] + "\nO" +  this.Atomo.eletrons[4] + " P" +  this.Atomo.eletrons[5] + " Q" +  this.Atomo.eletrons[6]);
		}
		if (posicao == 2) {
			int y = 25;
			GUI.Box (new Rect ((Screen.width - 180) / 2, 0, 180, 25), "Combinações Possiveis");
			foreach (Combinacao c in this.Atomo.combinacoes) {
				if (c.other.Equals (Elemento1)) {
					GUI.Box (new Rect ((Screen.width - 90) / 2, y, 90, 25), c.result);
					y = y + 25;
				}
			}
		}
	}
}