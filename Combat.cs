using System.Collections;
using System.Collections.Generic;
using UnityEngine;


using UnityEngine.Networking;

public class Combat :  NetworkBehaviour 
{
	public const int max = 100;

	[SyncVar]
	public int health = max;

	public void TakeDamage(int amount)
	{
		if (!isServer)
			return;

		health -= amount;
		if (health <= 0)
		{
			health = max;
			RpcRespawn();
		}
	}

	[ClientRpc]
	void RpcRespawn()
	{
		if (isLocalPlayer)
		{
			transform.position = Vector3.zero;
		}
	}
}