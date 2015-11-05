using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour {

	public bool playerMove;
	// Use this for initialization
	public float speed;
	public float cooldown;

	public float timer;


	public int width = 6;
	public int height = 10;
	public int[][] flag; 

	void Start () {

		flag = new int[width][];
		for (int i=0; i< width; ++i) {
			flag[i] = new int[height];

		}

		timer = 0;
	}
	
	// Update is called once per frame
	void Update () {

		//BasicMovement ();
		timer += Time.deltaTime;

		playerMove = CanMoveByPlayer ();
		if (timer > cooldown) { 

			if (playerMove) {
				timer = 0;
				MoveByPlayer ();
			}
		}
	}

	bool CanMoveByPlayer(){
		bool result = false;

		result = result || Input.GetKeyDown (KeyCode.DownArrow);
		result = result || Input.GetKeyDown (KeyCode.LeftArrow);
		result = result || Input.GetKeyDown (KeyCode.RightArrow);

		return result;
	}
	void MoveByPlayer(){

		Debug.Log ( Mathf.Round(transform.position.y) + " " + Mathf.Round(transform.position.x) );

		float x = Mathf.Floor(Input.GetAxis("Horizontal"));
		if (Input.GetAxis ("Horizontal") > 0)
			x = 1f;

		float y = Mathf.Floor(Input.GetAxis("Vertical"));


		transform.position += new Vector3(x, y, 0) * speed; 
	}


}
