using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TradeCupcakeTowerBuy : TradeCupcakeTower {

	[Tooltip("Variable para identificar el prefab de la torreta que debemos instanciar con este botón")]
	public GameObject cupcakeTowerPrefab;

	
	public override void OnPointerClick(PointerEventData eventData){
		//Aquí va el código de cuando hagamos click
		
		//Recuperamos el precio de crear una torreta
		int price = cupcakeTowerPrefab.GetComponent<TowerScript>().initialCost;
		//Comprobaremos si el usuario tiene suficiente dinero como para comprar esta torreta
		if (price<=sugarMeter.getSugarScore())
		{
			//Aquí tengo suficiente dinero, así que puedo comprar la torreta
			//Descuento el precio del contador
			sugarMeter.AddSugar(-price);
			//Instanciamos ese prefab en pantalla
			GameObject newTower = Instantiate(cupcakeTowerPrefab);
			//El prefab instanciado, lo asignamos a la torreta actual
			currentActiveTower = newTower.GetComponent<TowerScript>();
		}
	}
	
	
}
