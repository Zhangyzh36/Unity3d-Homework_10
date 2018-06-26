using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class Bullet : MonoBehaviour
{
	void OnCollisionEnter(Collision collision)
	{
		var hit = collision.gameObject;
		var hitPlayer = hit.GetComponent<PlayerMove>();
		if (hitPlayer != null)
		{
			var combat = hit.GetComponent<Combat>();
			combat.TakeDamage(30);

			Destroy(gameObject);
		}
	}
}