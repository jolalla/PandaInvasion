using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerScript : MonoBehaviour {


	[Header("Variables de ataque")]
	[Tooltip("Distancia máxima a la que puede disparar la torreta")]
	public float rangeRadius;
	[Tooltip("Tiempo de recarga antes de poder disparar otra vez")]
	public float reloadTime;
	[Tooltip("Prefab del tipo de proyectil que va a disparar mi torreta")]
	public GameObject projectilePrefab;
	[Tooltip("Tiempo que ha pasado desde la última vez que la torreta disparó")]
	private float timeSinceLastShot;
	
	
	[Header("Niveles de torreta")]
	[Tooltip("Nivel actual de la torreta")]
	private int _upgradeLevel;
	
	[Header("Economía de la torreta")]	
	[Tooltip("Precio de comprar la torreta")]
	public int initialCost;
	[Tooltip("Precio de mejorar la torreta de nivel")]
	public int upgradeCost;
	[Tooltip("Precio de venta de la torreta")]
	public int sellCost;
	[Tooltip("Precio de incremento de mejora")]
	public int upgradeIncrementCost;
	[Tooltip("Precio de incremento de venta")]
	public int sellIncrementCost;
	
	public int upgradeLevel{
		get{
			return _upgradeLevel;
		}
		
		set{
			_upgradeLevel = value;
		}
	}
	
	[Tooltip("Sprites de los diferentes niveles de mejora de la torreta")]
	public Sprite[] upgradeSprites;
	[Tooltip("Variable para saber si una torreta se puede actualizar")]
	public bool isUpgradable = true;
	
	[Tooltip("Game Objects de los proyectiles")]
	public GameObject[] projectilePrefabs;
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
		if (timeSinceLastShot >= reloadTime)
		{
			//Encontrar todos los Game Objects que tengan un collider dentro de mi rango de disparo
			Collider2D[] hitColliders = Physics2D.OverlapCircleAll(transform.position, rangeRadius);
			
			if (hitColliders.Length!=0)
			{
				//Programar la lógica de disparo contra los posibles objetivos
				//Bucle entre todos los objetos anteriores para encontrar el panda más cercano
				
				float minDistance = int.MaxValue;
				int index = -1;
				
				for (int i = 0; i < hitColliders.Length; i++)
				{
				
					if (hitColliders[i].tag == "Enemy")
					{
						//Estoy seguro de que he chocado contra un panda
						float distance = Vector2.Distance(hitColliders[i].transform.position, this.transform.position);
						if (distance < minDistance)
						{
							index = i;
							minDistance = distance;
						}
					}
				}
				
				if (index<0)
				{
					return;
				}
				
				
				

				//SI estamos aquí, es que tenemos un objetivo al que disparar!!!
				Transform target = hitColliders[index].transform;
				Vector2 direction = (target.position - this.transform.position).normalized;		
				
				//Creamos el proyectil haciendo una instancia del prefab que tenemos
				GameObject projectile = GameObject.Instantiate(projectilePrefab, this.transform.position, Quaternion.identity) as GameObject;
				projectile.GetComponent<ProjectileScript>().direction = direction;
				
				//Código de disparar
				timeSinceLastShot = 0;

				
			}
		
		}
		
		timeSinceLastShot += Time.deltaTime;
		
	}
	
	
	//Método para subir de nivel una torreta
	public void UpgradeTower(){
		
		//Chequeamos si podemos subir de nivel la torreta
		if (!isUpgradable)
		{
			return;
		}
		
		
		//Si estamos aquí, es que podemos subir de nivel
		this.upgradeLevel++;
		
		
		if (this.upgradeLevel == upgradeSprites.Length)
		{
			isUpgradable = false;
		}
		
		//Mejorar estados de la torreta;
		rangeRadius +=   1f;
		reloadTime  -= 0.5f;
		
		//Subimos los precios de mejora y de venta
		sellCost += sellIncrementCost;
		upgradeCost += upgradeIncrementCost;

		
		this.GetComponent<SpriteRenderer>().sprite = upgradeSprites[upgradeLevel];		
		
		this.projectilePrefab = projectilePrefabs[upgradeLevel];
		
	}
	
	//Este método será llamado cuando el usuario haga click sobre una de las torretas
	void OnMouseDown(){
		//Cuando el usuario clique en una torreta, esta se convierte en la torreta activa actual
		TradeCupcakeTower.setActiveTower(this);
		Debug.Log("He seleccionado una torreta");
		
	}
	
	
	public void DestroyTower(){
		Destroy(gameObject);
	}
	
	
	
	
	
	
}
