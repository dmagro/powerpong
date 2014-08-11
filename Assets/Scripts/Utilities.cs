using UnityEngine;


public static class Utilities
{
	//public static Utilities Instance;
	const float slack = 2.5f;

	//Get the main camera boundaries and return them as a tuple
	public static Tuple<float, float, float, float> getCameraBorders(Transform transform)
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
	public static Tuple<float, float, float, float> getPlayerHorizontalBorders(float leftCameraBorder, float rightCameraBorder, bool isPlayer1)
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
