using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

	//La variable waypoints es una lista que contiene posiciones en el mapa
	//public Vector3[] waypoints;

	public Waypoint firstWaypoint;


	//Variable booleana para saber si el ratón se halla sobre una zona donde poder
	//poner torretas
	private bool _isPointerOnAllowedArea = false;
	//Función que devuelve el valor de la variable privada anterior...
	public bool isPointerOnAllowedArea(){
		return _isPointerOnAllowedArea;
	}
	
	//Se llama automáticamente cuando el ratón entra dentro de alguno de los colliders del GM.
	void OnMouseEnter(){
		//Como estoy dentro de un collider, puedo plantar torretas...
		_isPointerOnAllowedArea = true;
	}
	//Se llama automáticamente cuando el ratón sale de alguno de los colliders del GM.
	void OnMouseExit(){
		//Como salgo de un collider, no puedo plantar nada...
		_isPointerOnAllowedArea = false;
	}
	
	
	/////////////
	//GAME OVER//
	/////////////
	[Header("Pantallas de Game Over")]
	public GameObject winningScreen;
	public GameObject losingScreen;
	
	//Referencia a la barra de vida del castillo de azúcar...
	private HealthBarScript playerHealth;
	//Variable para saber cuantos pandas nos quedan por derrotar y ganar el nivel
	private int numberOfPandasToDefeat;
	//Variable para saber donde spawnear los pandas
	private Transform spawnPoint;
	
	
	//Referencia al medidor de azúcar para sumar puntos cuando matemos un panda
	private static SugarMeterScript sugarMeter;
	
	[Header("Panda y oleadas")]
	public GameObject pandaPrefab; //Enemigo que spawnearemos en las oleadas
	public int numberOfWaves; //Número de oleadas del videojuego
	public int numberOfPandasPerWave; //Número de enemigos por oleada
	
	
	void Start(){
		
		if (sugarMeter == null)
		{
			sugarMeter = FindObjectOfType<SugarMeterScript>();
		}
		
		//Recuperamos una referencia a la barra de vida del jugador...
		playerHealth = FindObjectOfType<HealthBarScript>();
		//Recuperamos el objeto Spawning Point
		spawnPoint = GameObject.Find("Spawning Point").transform;
		
		StartCoroutine(WavesSpawner());
	}
	
	
	/*
		Método privado para ser llamado cuando se cumplan las condiciones de game over
		bien, porque el jugador gane derrotando todas las oleadas o bien porque el jugador
		se ha quedado sin vida en su castillo de azucar
	*/
	private void GameOver(bool playerHasWon){
		//Comprobamos si el jugador ha ganado o no, para activar una pantalla u otra
		if (playerHasWon)
		{
			winningScreen.SetActive(true);
		}else
		{
			losingScreen.SetActive(true);	
		}
		
		//Congelamos el tiempo para que se pare el videojuego detrás de las escenas.
		Time.timeScale = 0;
	}
	
	//Función que llamamos cada vez que matamos un Panda...
	public void OneMorePandaInHell(){
		numberOfPandasToDefeat--;
		sugarMeter.AddSugar(5);
	}
	
	
	//Función que daña la vida del jugador cuando el panda alcanza la tarta
	//Monitorizará además si todavía queda vida, y si se nos agota, llamará al game over con
	//el parámetro has ganado a FALSE...
	public void BiteTheCake(int damage){
		
		//Lo primero es hacer daño a la barra de vida, y saber si aún queda tarta por comer
		bool isCakeAllEaten = playerHealth.ApplyDamage(damage);
		
		//Si los pandas se han comido toda la tarda -> Game Over, hemos perdido
		if (isCakeAllEaten)
		{
			GameOver(false);
		}
		
		//Como hay un panda menos (se ha inmolado), lo notificamos al Game Manager
		OneMorePandaInHell();
		
	}
	
	//Corutina que creará oleadas de enemigos
	private IEnumerator WavesSpawner(){
		//Para cada oleada
		for (int i = 0; i < numberOfWaves; i++)
		{
			//Llamamos a la rutina de Panda Spawner para que gestione la oleada en cuestión
			//y esperamos a que esta haya concluido
			yield return PandaSpawner();
			
			//cuando la corutina acaba, puedo incrementar el numero de pandas para la siguiente oleada
			numberOfPandasPerWave += 3;
		}
		
		//Si hemos acabado con todas las hordas, hay que llamar a Game Over y decir que hemos ganado el juego
		GameOver(true);
	}
	
	//Corutina que crea los pandas de una oleada simple y espera hasta que no queda ninguno
	private IEnumerator PandaSpawner(){
		//Tengo que derrotar tantos pandas como indique la oleada actual
		numberOfPandasToDefeat = numberOfPandasPerWave;
		
		//Vamos a generar progresivamente los pandas de la oleada
		for (int i = 0; i < numberOfPandasPerWave; i++)
		{
			//Instanciamos el panda, en la posición del spawner y sin rotar nada...
			Instantiate(pandaPrefab, spawnPoint.position, Quaternion.identity);
			
			//ponemos la rutina a descansar unos segundos aleatorios, que dependerá de cuantos pandas haya que instanciar
			float ratio = (i*1.0f) / (numberOfPandasPerWave-1);
			//Elijo un tiempo aleatorio basado en la fórmula siguiente...
			float timeToWait = Mathf.Lerp(3f, 5f, ratio) + Random.Range(0f,2f);
			//Indico a la corutina que duerma este tiempo
			yield return new WaitForSeconds(timeToWait);
		}
		
		//Una vez que todos los pandas se han spawneado, esperar a que todos hayan sido derrotados por el jugador
		//o bien este no pueda derrotarlos, y muera...
		yield return new WaitUntil(()=>numberOfPandasToDefeat<=0);
		
	}
	
	
	
	
	
	
	
	
	
}
