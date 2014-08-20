using UnityEngine;
using System.Collections;

public class BigPaddlePowerScript : PowerScript 
{
	private float addSize = 1.5f;

	public override void Start () 
	{
		base.Start();
	}

	protected override void usePower(PlayerScript player)
	{
		base.usePower(player);
		player.enqueuePower((int)PowersUtilities.Powers.BigPaddle);
		player.transform.localScale = new Vector3(PowersUtilities.xPlayerSize + addSize,
		                                          PowersUtilities.yPlayerSize + addSize,
		                                          PowersUtilities.zPlayerSize);
	}
}
