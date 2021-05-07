using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarScript : MonoBehaviour {

	[Tooltip("Vida máxima que tendrá el jugador")]
	public int maxHealth;
	//Referencia a la health bar filling de la UI de Unity
	private Image fillingImage;
	//Vida actual del jugador
	private int currentHealth;


	// Use this for initialization
	void Start () {
		fillingImage = GetComponent<Image>();
		
		currentHealth = maxHealth;
				
		UpdateHealthBar();
	}
	
	// Update is called once per frame
	void Update () {
		
		
	}
	
	
	//El método aplica daño al jugador y devuelve el estado de Game Over (true)
	public bool ApplyDamage(int damage){
		
		//Aplicar el daño a la vida actual
		currentHealth -= damage;
		//Si aún me queda vida, debo actualizar la barra de vida actual
		if(currentHealth>0){
			UpdateHealthBar();
			return false;
		}
		
		
		//Si llego a esta línea de código, es que no me queda vida
		currentHealth = 0;
		UpdateHealthBar();
		return true;
	}
	
	
	
	void UpdateHealthBar(){
		//Calculo el porcentaje de vida que me queda (da un valor entre 0 y 1)
		float percentage = currentHealth * 1.0f / maxHealth;
		//Aplico el porcentaje de relleno a la barra de vida
		fillingImage.fillAmount = percentage;
	}
}
