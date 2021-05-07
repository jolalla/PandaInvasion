using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderTest : MonoBehaviour {

	// Use this for initialization
	void Start () {
		//Physics2D.NombreDeLaFuncion();
		
		//Devuelve el array de colliders 2D que se encuentran dentro de
		//la circunferencia de centro center y radio radius
		//Physics2D.OverlapCircleAll(Vector2 center, float radius, [...]);
		
		//Este método devuelve la primera ocurrencia
		//Physics2D.OverlapCircle(Vector2 center, float radious, [...]);
		
		//Devuleve un array de RayCastHit2D que se encuentren en dicha dirección 
		//Physics2D.RaycastAll(Vector2 origin, Vector2 direction, [...]);
		
		//Devuelve el primer RayCastHit2D de la dirección en la que hemos lanzado el rayo
		//Physics2D.Raycast(Vector2 origin, Vector2 direction, [...]);
		
		
		/*RayCastHit2D:
		- centroid: centro de gravedad del objeto usado para lanzar el rayo
		- collider: el collider con el que ha chocado el rayo
		- distance: distancia desde el origen hasta el punto de impacto 
		- fraction: la fracción de la distancia del rayo total a la que ha tenido lugar el impacto 
		- normal: el vector noram a la superfície de impacto 
		- point: el punto de las coordenadas espaciales donde ha tenido lugar el impacto
		- rigidbody: el rigidbody del objeto contra el que hemos chocado
		- transform: pos, rot, scale del objeto contra el que hemos chocado
		*/

	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	
	//FUNCIONES PARA TRIGGERS
	
	//Este método se llama cuando otro collider choca contra
	//el game object que tiene este script añadido como parte
	//de la jeraquía
	void OnTriggerEnter2D(Collider2D otherCollider){
		
	}
	
	//Se llama a cada frame mientras el otherCollider se encuentre
	//dentro de mi propio collider
	void OnTriggerStay2D(Collider2D otherCollider){
		
	}

	//Se llama justo cuando el otro collider sale del mío propio 
	void OnTriggerExit2D(Collider2D otherCollider){
	
	}	
	
	
	//FUNCIONES PARA COLLIDERS
	
	void OnCollisionEnter2D(Collision2D collision){
		
	}
	
	void OnCollisionStay2D(Collision2D collision){
		
	}
	
	void OnCollisionExit2D(Collision2D collision){
		
	}
	
	
}
