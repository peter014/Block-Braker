﻿using UnityEngine;
using System.Collections;

public class Paddle : MonoBehaviour {
	
	public bool autoPlay = false;

	private Ball ball;
	// Use this for initialization
	
	void Start () {
		ball = GameObject.FindObjectOfType<Ball>();
	}
	
	void OnCollisionEnter2D(Collision2D collision){
		if(Ball.started){
			GetComponent<AudioSource>().Play();
		}
	}
	
	// Update is called once per frame
	void Update () {
		if(!autoPlay){
			moveWithMouse();
		}
		else{
			testAutoPlay();
		}
	}
	
	void testAutoPlay(){
		float ballPosition = ball.transform.position.x;
		Vector3 paddlePosition = new Vector3(Mathf.Clamp(ballPosition,0.5f,15.5f),this.transform.position.y,0f);
		
		this.transform.position = paddlePosition;
	}
	
	void moveWithMouse(){
		float mousePosInBlocks = (Input.mousePosition.x/Screen.width * 16)/*/1.0f*/;  
		Vector3 paddlePosition = new Vector3(Mathf.Clamp(mousePosInBlocks,0.5f,15.5f),this.transform.position.y,0f);
		
		this.transform.position = paddlePosition;
	}
}
