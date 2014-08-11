using UnityEngine;
using System.Collections;

public class BallScript : MonoBehaviour
{

	public Vector2 rightForce = new Vector2(50,10);
	public Vector2 leftForce = new Vector2(-50,-10);

	//Ball cooldown in seconds
	private const float ballCooldown = 1f;
	
	void Start()
	{
		float randomNumber = Random.Range(0.0f,1.0f);

		StartCoroutine(Wait(ballCooldown, randomNumber));
	}

	void Update()
	{
		if(renderer.IsVisibleFrom(Camera.main) == false)
		{
			if(rigidbody2D.velocity.x > 0)
				MainScript.Instance.score(MainScript.player1);
			else if(rigidbody2D.velocity.x < 0)
				MainScript.Instance.score(MainScript.player2);

			Destroy(gameObject);
		}
	}

	void OnCollisionEnter2D(Collision2D coll)
	{
		if(coll.collider.tag == "Player")
		{
			float newVelocityY = (rigidbody2D.velocity.y*0.7f) + (coll.collider.rigidbody2D.velocity.y*0.3f);
			rigidbody2D.velocity = new Vector2(rigidbody2D.velocity.x, newVelocityY); 
		}
	}

	// Coroutine that executes a cooldown before the ball first move
	private IEnumerator Wait(float seconds, float randomNumber)
	{
		yield return new WaitForSeconds(seconds);
		addForceToBall(randomNumber);
	}

	//Give the impluse to the ball first move in a direction decided by a random number
	private void addForceToBall(float randomNumber)
	{
		if(randomNumber <= 0.5f)
			rigidbody2D.AddForce(leftForce);
		else
			rigidbody2D.AddForce(rightForce);
	}
}
