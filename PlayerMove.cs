using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class PlayerMove : NetworkBehaviour
{
	public GameObject prefab;

	public override void OnStartLocalPlayer()
	{
		GetComponent<MeshRenderer>().material.color = Color.black;
	}

	[Command]
	void CmdFire()
	{
		var bullet = (GameObject)Instantiate(
			prefab,
			transform.position - transform.forward,
			Quaternion.identity);

		bullet.GetComponent<Rigidbody>().velocity = -transform.forward*30;


		NetworkServer.Spawn(bullet);

		Destroy(bullet, 1.0f);
	}

	void Update()
	{
		if (!isLocalPlayer)
			return;

		var x = Input.GetAxis("Horizontal")*0.1f;
		var z = Input.GetAxis("Vertical")*0.1f;

		transform.Translate(x, 0, z);

		if (Input.GetKeyDown(KeyCode.Space))
		{
			CmdFire();
		}
	}
}