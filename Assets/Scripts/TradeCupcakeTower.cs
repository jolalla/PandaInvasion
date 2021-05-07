using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems; //Necesario para detectar interactuación con la UI

public abstract class TradeCupcakeTower : MonoBehaviour, IPointerClickHandler {

	//Medidor de azúcar para saber cuantos puntos para gastar tenemos
	protected static SugarMeterScript sugarMeter;
	
	//Torreta seleccionada actualmente para ser mejorada o vendida
	protected static TowerScript currentActiveTower;

	// Use this for initialization
	void Start () {
		//Comprobamos si el medidor de azúcar ha sido inicializado o no
		if (sugarMeter == null)
		{
			//Si no lo ha sido, lo inicializamos
			sugarMeter = FindObjectOfType<SugarMeterScript>();
		}
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	
	public static void setActiveTower(TowerScript newCupcakeTower){
		currentActiveTower = newCupcakeTower;
	}
	
	//FUnción abstracta que será llamada cuando uno de los tres botones
	//se pulse y cada uno implementará una lógica diferente...
	public abstract void OnPointerClick(PointerEventData eventData);
	
	
}
