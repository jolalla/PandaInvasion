using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TradeCupcakeTowerSell : TradeCupcakeTower {

	public override void OnPointerClick(PointerEventData eventData){
		//Aquí irá el código de cuando queramos vender una torreta
		//Comprobaré si hay una torreta seleccionada para ser vendida
		if (currentActiveTower == null)
		{
			return;
		}
		//Si llego aquí, es que tengo una torreta seleccionada...
		//Consulto el precio de venta de la torreta
		int sellingPrice = currentActiveTower.sellCost;
		//Sumamos ese dinero al medidor de azucar del usuario
		sugarMeter.AddSugar(sellingPrice);
		//Destruimos el cupcake actual ya que acabamos de venderlo
		currentActiveTower.DestroyTower();
	}

}
