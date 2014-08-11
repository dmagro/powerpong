using UnityEngine;
using System.Collections;

public class BigPaddlePowerScript : PowerScript 
{
	
	void Start () 
	{
		base.Start();
	}

	protected override void usePower(PlayerScript player)
	{
		base.usePower(player);
		player.transform.localScale = new Vector3(0.5f, 4f, 1f);
	}
}
