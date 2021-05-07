using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RigidbodyTest : MonoBehaviour {


	private Rigidbody2D rb;


	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D>();
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	
	
	void FixedUpdate(){
		
		/*
		//Solo para dinámicos...
		Vector2 force = new Vector2(2,-3); 
		ForceMode2D mode = ForceMode2D.Force;
		
		rb.AddForce(force, mode);
		
		Vector2 pos = new Vector2(0,0);
				
		rb.AddForceAtPosition(force, pos, mode);
		
		rb.AddRelativeForce(force, mode);
		
		float torque = 5.0f;
		
		rb.AddTorque(torque, mode);
		
		
		//Solo para cinemáticos

		Vector2 finalPos = new Vector(50, 32);
		rb.MovePosition(finalPos);
		float angle = 30;
		rb.MoveRotation(angle);
		
		
		// S = V * t
		// x1 = x0 + V * t
		rb.MovePosition(rb.position + velocity * Time.fixedDeltaTime);
		
		rb.IsAwake(); //true si el rigidbody está despierto, y falso si está dormido
		rb.IsSleeping(); //true si el rigidbody duerme y falso si está despierto
		
		rb.IsTouching(Collider2D otherCollider); //devuelve true si mi rigidbody está colisionando con el otro collider
		rb.OverlapPoint(Vector2 point); // devuelve true si el punto se encuentra dentro del rigidbody
		
		
		rb.Sleep();//pone el rigidbody a dormir
		rb.WakeUp();//despierta el rigidbody
		*/
	}
}
