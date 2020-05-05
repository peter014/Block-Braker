using UnityEngine;
using System.Collections;

public class Brick : MonoBehaviour {

	public Sprite[] sprites;
	public static int breakableCount = 0;
	public AudioClip clank;
	public GameObject smoke;
	
	private int timesHit;
	private LevelManager lvlManager;
	private bool isBreakable;
	
	// Use this for initialization
	void Start () {
		//Vector3 brickPosition = new Vector3(Mathf.Clamp(mousePosInBlocks,0.5f,15.5f),this.transform.position.y,0f);
		
		timesHit = 0;
		isBreakable = (this.tag == "Breakable");
		if(isBreakable){
			breakableCount++;
		}
	}
	
	void OnCollisionEnter2D(Collision2D colision){
		if(isBreakable){
			AudioSource.PlayClipAtPoint(clank,transform.position);
			handleHits();
		}
		else{
			GetComponent<AudioSource>().Play();
		}
	}
	
	void handleHits(){
		timesHit++;
		int maxHits = sprites.Length + 1;
		if(timesHit >= maxHits){
			breakableCount--;
			lvlManager = GameObject.FindObjectOfType<LevelManager>();
			lvlManager.brickDestroyed();
			
			GameObject smokePuff = Instantiate (smoke,gameObject.transform.position, Quaternion.identity) as GameObject;
			smokePuff.GetComponent<ParticleSystem>().startColor = gameObject.GetComponent<SpriteRenderer>().color;
			
			Destroy(gameObject);
		}
		else{
			LoadSprites();
		}
	}
	
	void LoadSprites(){
		int spriteIndex = timesHit - 1;
		if(sprites[spriteIndex]){
			this.GetComponent<SpriteRenderer>().sprite = sprites[spriteIndex];
		}
		else{
			Debug.LogError("No Sprite");
		}
	}
	
	
	// Update is called once per frame
	void Update () {
	
	
	}
}
