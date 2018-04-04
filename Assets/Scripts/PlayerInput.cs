using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour {
	public bool isKeyboard;

	private bool isJump;
	private bool isFire;
	private bool isRight;
	private bool isLeft;
	private bool isDown;
	private bool isUp;

	// Use this for initialization
	void Start () {
		isJump = false;
		isFire = false;
		isRight = false;
		isLeft = false;
		isDown = false;
		isUp = false;

		#if UNITY_STANDALONE

		#endif

		#if UNITY_EDITOR
			
		#endif

		#if UNITY_ANDROID
			//isKeyboard = false;
		#endif
	}
	
	// Update is called once per frame
	void Update () {
		if(isKeyboard){
			isRight = (Input.GetKey(KeyCode.RightArrow));
			isLeft = (Input.GetKey(KeyCode.LeftArrow));
			isUp = (Input.GetKey(KeyCode.UpArrow));
			isDown = (Input.GetKey(KeyCode.DownArrow));
			isFire = (Input.GetButton("Fire1"));
			isJump = (Input.GetButton("Jump"));
		}

		if (Input.GetKey("escape")){
			Application.Quit();
		}
	}

	public void SetIsJump(bool b){
		isJump = b;
	}

	public void SetIsLeft(bool b){
		isLeft = b;
	}

	public void SetIsRight(bool b){
		isRight = b;
	}

	public void SetIsFire(bool b){
		isFire = b;
	}

	public bool IsJump(){
		return isJump;
	}

	public bool IsFire(){
		return isFire;
	}

	public bool IsRight(){
		return isRight;
	}

	public bool IsLeft(){
		return isLeft;
	}

	public bool IsUp(){
		return isUp;
	}

	public bool IsDown(){
		return isDown;
	}
}
