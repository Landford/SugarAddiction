using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIDebug : MonoBehaviour {

	PlayerAnimation pAnim;
	PlayerMovement pMovement;
	Text textDebug;
	string msg;

	// Use this for initialization
	void Start () {
		textDebug =  this.GetComponent<Text>();
		pMovement = GameObject.Find("Player").GetComponent<PlayerMovement>();
	}
	
	// Update is called once per frame
	void Update () {
		if(pMovement != null)  textDebug.text = "Debug\n" + pMovement.GetMoveDebug();
		textDebug.text = textDebug.text + msg;
	}

	public void SetMsg(string newMsg){
		msg = "\n" + newMsg;
	}
}
