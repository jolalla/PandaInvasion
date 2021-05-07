using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TradeCupcakeTowerUpgrade : TradeCupcakeTower {

	public override void OnPointerClick(PointerEventData eventData){
		//Este método se ejecutará cuando queramos subir de nivel una torreta
		//Comprobamos si hay una torreta seleccionada para subirla de nivel
		if (currentActiveTower == null)
		{
			return;
		}
		//Si estamos aquí, hay una torreta seleccionada
		//Solo podremos subirla de nivel si no está ya al máximo y si tenemos suficiente dinero
		int upgradePrice = currentActiveTower.upgradeCost;
		if (currentActiveTower.isUpgradable && upgradePrice <= sugarMeter.getSugarScore())
		{
			//Le descontamos el dinero al medidor de azucar del jugador
			sugarMeter.AddSugar(-upgradePrice);
			//Subo de nivel la torreta actual
			currentActiveTower.UpgradeTower();
		}
		
	}
	
}
