using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceCupcakeTower : MonoBehaviour {
	
	//Variable para referenciar el Game Manager del videojuego
	private GameManager gameManager;
	

	// Use this for initialization
	void Start () {
		//Objetenos una referencia al Game Manager de la escena
		gameManager = FindObjectOfType<GameManager>();
	}
	
	// Update is called once per frame
	void Update () {
		//Conocer las coordenadas del ratón
		float x = Input.mousePosition.x;
		float y = Input.mousePosition.y;
		float z = 7.0f; 
		//La torreta se colocará 7 unidades delante de la cámara, como esta estaba en -10, la torreta quedará en z = -3 como queríamos al principio...
		transform.position = Camera.main.ScreenToWorldPoint(new Vector3(x,y,z));
		
		
		//Si el jugador hace click en esa posición, vamos a ver si podemos plantar una torreta en dicho punto
		if (Input.GetMouseButtonDown(0) && gameManager.isPointerOnAllowedArea())
		{
			//Habilitamos el script de la torreta para que pueda disparar
			GetComponent<TowerScript>().enabled = true;
			//Le añadimos un collider para evitar que se plante otra torreta encima de la misma
			gameObject.AddComponent<BoxCollider2D>();
			Destroy(this);
		}
	}
}
