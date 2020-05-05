using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour {

	private Paddle paddle;
	private Vector3 paddeToBall;
	public static bool started = false;
	// Use this for initialization
	void Start () {
		paddle = GameObject.FindObjectOfType<Paddle>();
		paddeToBall = this.transform.position - paddle.transform.position;		
	}
	
	// Update is called once per frame
	void Update () {
		if(!started){
			this.transform.position = paddle.transform.position + paddeToBall;
			if(Input.GetMouseButtonDown(0)){
				this.GetComponent<Rigidbody2D>().velocity = new Vector2(2f,11f);
				started = true;
			}
		}
	}
	void OnCollisionEnter2D(Collision2D colision){
		if(!started){
			Vector2 tweak = new Vector2(Random.Range(0f,2.2f),Random.Range(0f,2.2f));
			GetComponent<Rigidbody2D>().velocity += tweak;
		}
	}
}
