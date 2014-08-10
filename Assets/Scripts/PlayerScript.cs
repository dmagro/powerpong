using UnityEngine;
using System.Collections;

public class PlayerScript : MonoBehaviour
{
	const float slack = 2.5f;

	const string verticalCommandsPlayer1 = "VerticalAlt";
	const string horizontalCommandsPlayer1 = "HorizontalAlt";

	const string verticalCommandsPlayer2 = "Vertical";
	const string horizontalCommandsPlayer2 = "Horizontal";

	public Vector2 speed = new Vector2(7,7);
	public bool isPlayer1 = true;

	private Vector2 movement;

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
		Tuple<float, float, float, float> cameraBorders = getCameraBorders();

		float leftBorder = cameraBorders.Item1;
		float rightBorder = cameraBorders.Item2;
		float topBorder = cameraBorders.Item3;
		float bottomBorder = cameraBorders.Item4;

		Tuple<float, float, float, float> playerBorders = getPlayerHorizontalBorders(leftBorder, rightBorder);
		
		transform.position = new Vector3(
			Mathf.Clamp(transform.position.x, playerBorders.Item1, playerBorders.Item2),
			Mathf.Clamp(transform.position.y, topBorder, bottomBorder),
			transform.position.z
			);
	}

	//Get the main camera boundaries and return them as a tuple
	private Tuple<float, float, float, float> getCameraBorders()
	{

		float dist = (transform.position - Camera.main.transform.position).z;

		float leftBorder = Camera.main.ViewportToWorldPoint(
			new Vector3(0, 0, dist)
			).x;
		
		float rightBorder = Camera.main.ViewportToWorldPoint(
			new Vector3(1, 0, dist)
			).x;
		
		float topBorder = Camera.main.ViewportToWorldPoint(
			new Vector3(0, 0, dist)
			).y;
		
		float bottomBorder = Camera.main.ViewportToWorldPoint(
			new Vector3(0, 1, dist)
			).y;

		return Tuple.Create(leftBorder, rightBorder, topBorder, bottomBorder);
	}

	//Calculate the horizontal boundaries for a player
	//TODO: FIX TUPLE ELEMENTS SIZE TO 2
	private Tuple<float, float, float, float> getPlayerHorizontalBorders(float leftCameraBorder, float rightCameraBorder)
	{
		float leftBorder;
		float rightBorder;

		//Sum, because the values of  this two borders are symmetric
		float center = leftCameraBorder + rightCameraBorder;

		if(isPlayer1)
		{
			leftBorder = Mathf.Ceil(leftCameraBorder);
			rightBorder = center - slack;
		}
		else
		{
			leftBorder = center + slack;
			rightBorder = Mathf.Floor(rightCameraBorder);
		}

		return Tuple.Create(leftBorder, rightBorder, 0f, 0f);
	}

}
