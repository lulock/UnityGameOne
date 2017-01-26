using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour {

	public float speed;
	private Rigidbody rb;
	private int count;
	public Text countText;
	public Text winText;
	private bool gameOver;
	private bool restart;
	public Text restartText;


	void Start(){
		gameOver = false;
		restart = false;
		restartText.text = "";
		rb = GetComponent<Rigidbody>();
		count = 0;
		setCountText ();
		winText.text = "";

	}
		
	void FixedUpdate()
	{
		if (restart)
		{
			if (Input.GetKeyDown (KeyCode.R))
			{
				SceneManager.LoadScene ("MiniGame", LoadSceneMode.Single);
			}
		}
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");

		Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);

		rb.AddForce (movement * speed);

		if (gameOver)
		{
			restartText.text = "Press 'R' for Restart";
			restart = true;
		}
	}

	void OnTriggerEnter(Collider other) 
	{
		if(other.gameObject.CompareTag("PickUp")){
			other.gameObject.SetActive(false);
			count += 1;
			setCountText ();
		}
	}

	public void GameOver ()
	{
		gameOver = true;
	}

	void setCountText()
	{
		countText.text = "Count: " + count.ToString ();
		if (count >= 10) {
			winText.text = "You win!";
			GameOver ();
		}
	}

}