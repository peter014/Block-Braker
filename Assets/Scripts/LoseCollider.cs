using UnityEngine;
using System.Collections;

public class LoseCollider : MonoBehaviour {
	
	private LevelManager lvlManager;
	
	void OnTriggerEnter2D(Collider2D trigger){
		lvlManager.LoadLevel("Loose Screen");
	}	
	/*void OnCollisionEnter2D(Collision2D colision){
		print("Colision"); 
	}*/
	
	void OnCollisionEnter2D(Collision2D collision){
		GetComponent<AudioSource>().Play();
	}
		
	void Start () {
		lvlManager = GameObject.FindObjectOfType<LevelManager>();
	}
}
