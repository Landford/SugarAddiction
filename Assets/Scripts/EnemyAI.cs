using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour {

	private UIDebug uiDebug;
	private Transform playerTransform;

	// Use this for initialization
	void Start () {
		try{
			uiDebug = GameObject.Find("Canvas").GetComponentInChildren<UIDebug>();
			playerTransform = GameObject.Find("Player").GetComponentInChildren<Transform>();
		}catch{

		}
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		CheckVision();
	}

	public void CheckVision(){
		float playerDistance;
		playerDistance = Vector3.Distance(playerTransform.position, this.transform.position);

		if(uiDebug != null){
			if(playerDistance < 15) uiDebug.SetMsg("I see Hood!");
			else uiDebug.SetMsg("I see nothing!");
		}
	}
}
