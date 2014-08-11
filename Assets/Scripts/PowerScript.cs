﻿using UnityEngine;
using System.Collections;

public class PowerScript : MonoBehaviour 
{
	private float lifetime = 5.0f;

	// Use this for initialization
	public virtual void Start () 
	{
		Destroy(gameObject, lifetime);
	}

	void OnCollisionEnter2D(Collision2D coll)
	{
		if(coll.collider.tag == "Player")
		{
			PlayerScript player = coll.gameObject.GetComponent<PlayerScript>();

			if(player.getNumberOfPowers() < player.maxPowers)
				usePower(player);

			Destroy(gameObject);
		}
	}

	protected virtual void usePower(PlayerScript player)
	{
		Debug.Log(player.name);
		player.numberOfPowersAddBy(1);
	}
}
