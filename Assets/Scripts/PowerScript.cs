using UnityEngine;
using System.Collections;

public class PowerScript : MonoBehaviour 
{
	private float lifetime = 5.0f;

	// Use this for initialization
	public virtual void Start () 
	{
		Destroy(gameObject, lifetime);
	}

	void OnTriggerEnter2D(Collider2D coll)
	{
		if(coll.tag == "Player")
		{
			PlayerScript player = coll.gameObject.GetComponent<PlayerScript>();
			
			if(player.getNumberOfPowers() < player.maxPowers)
				usePower(player);
			
			Destroy(gameObject);
		}
		else if(coll.tag == "Ball")
			Physics2D.IgnoreCollision(coll, collider2D);
	}

	protected virtual void usePower(PlayerScript player)
	{
		Debug.Log(player.name);
		player.numberOfPowersAddBy(1);
	}
}
