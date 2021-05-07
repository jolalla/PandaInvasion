using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SugarMeterScript : MonoBehaviour {

	//Variable que indica donde se mostrarán los puntos
	private Text sugarMeter;
	//Variable que guarda el número de puntos
	private int sugarScore = 50;
	
	public int getSugarScore(){
		return sugarScore;
	}


	// Use this for initialization
	void Start () {
		sugarMeter = GetComponent<Text>();
		UpdateSugarMeter();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	public void AddSugar(int sugar){
		
		sugarScore += sugar;
		
		if (sugarScore<0)
		{
			sugarScore=0;
		}
		
		UpdateSugarMeter();
		
	}
	
	void UpdateSugarMeter(){
		sugarMeter.text = sugarScore.ToString();
	}
}
