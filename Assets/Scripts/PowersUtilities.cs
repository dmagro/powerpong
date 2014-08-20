using UnityEngine;
using System.Collections;

public static class PowersUtilities
{

	//Standard dimensions of the players paddle
	public const float xPlayerSize = 2f;
	public const float yPlayerSize = 2.5f;
	public const float zPlayerSize = 1f;

	//Types of powers
	public enum Powers { BigPaddle } ;

	public static void reversePower(PlayerScript player, int power)
	{
		switch (power)
		{
			case (int)Powers.BigPaddle:
				reverseBigPaddle(player);
				break;

		}
	}

	//Methods to reverse the effects of the powers

	private static void reverseBigPaddle(PlayerScript player)
	{
		player.transform.localScale = new Vector3(xPlayerSize, yPlayerSize, zPlayerSize);
	}

}
