using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerScript : MonoBehaviour
{

	public readonly int maxPowers = 3;

	const string verticalCommandsPlayer1 = "VerticalAlt";
	const string horizontalCommandsPlayer1 = "HorizontalAlt";

	const string verticalCommandsPlayer2 = "Vertical";
	const string horizontalCommandsPlayer2 = "Horizontal";

	public Vector2 speed = new Vector2(7,7);
	public bool isPlayer1 = true;

	private Queue<int> activePowers = new Queue<int>();
	private Vector2 movement;
	private int numberOfPowers = 0;

	void Update()
	{
		float inputY;
		float inputX;

		if(isPlayer1)
		{
			inputY = Input.GetAxis(verticalCommandsPlayer1);
			inputX = Input.GetAxis(horizontalCommandsPlayer1);
		}
		else
		{
			inputY = Input.GetAxis(verticalCommandsPlayer2);
			inputX = Input.GetAxis(horizontalCommandsPlayer2);
		}
	
		movement = new Vector2(speed.x * inputX, speed.y * inputY);

		playerBoundaries();
	}

	void FixedUpdate()
	{
		rigidbody2D.velocity = movement;
	}

	//Determines the area that a player can move
	private void playerBoundaries()
	{
		Tuple<float, float, float, float> cameraBorders = Utilities.getCameraBorders(transform);

		float leftBorder = cameraBorders.Item1;
		float rightBorder = cameraBorders.Item2;
		float topBorder = cameraBorders.Item3;
		float bottomBorder = cameraBorders.Item4;

		Tuple<float, float, float, float> playerBorders = Utilities.getPlayerHorizontalBorders(leftBorder, rightBorder, isPlayer1);
		
		transform.position = new Vector3(
			Mathf.Clamp(transform.position.x, playerBorders.Item1, playerBorders.Item2),
			Mathf.Clamp(transform.position.y, topBorder, bottomBorder),
			transform.position.z
			);
	}



	//Return the number of powers that a player is using
	public int getNumberOfPowers()
	{
		return numberOfPowers;
	}

	/*	Add the value parameter to modify the number of powers in use by the player
		The value will not be under zero, even if the value parameter is a negative
		greater in module than the current number of powers value
	*/
	public void numberOfPowersAddBy(int value)
	{
		numberOfPowers += value;

		if(numberOfPowers < 0)
			numberOfPowers = 0;
	}

	public void enqueuePower(int power)
	{
		activePowers.Enqueue(power);
	}

	public void dequeuePower()
	{
		if(activePowers.Count > 0)
		{
			int power = activePowers.Dequeue();
			PowersUtilities.reversePower(this, power);
		}
	}

}
