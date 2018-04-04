using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour {

	public float throwPower;
	public float throwAngle;
	public int damage;
	public bool isPlayerShot;
	public PoolObjects impactFX;

	private Rigidbody rb;

	public void ShootMe(Transform shootPoint, float speedX){
		if(rb == null) rb = gameObject.GetComponent<Rigidbody>();
		rb.velocity = shootPoint.forward * throwPower + new Vector3 (0,0,speedX);
	}
	
	void OnTriggerEnter(Collider other) {
		//Check tag
		if(other.CompareTag("Player") && isPlayerShot || other.CompareTag("shot")) return;

		//particle
		if(impactFX == null) impactFX = GameObject.Find("Pools/_PoolFXStarExplosion").GetComponent<PoolObjects>();
		else impactFX.MakeGameObject(transform.position, Quaternion.identity);

		//print("HIT: " + other.name);
		gameObject.SetActive(false);
	}
}
