using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {
	public float moveSpeed;
	public float moveAcceleration;
	public float jumpSpeed;
	public float gravity;
	public float attackCooldown;

	//Ammo
	public PoolObjects poolAmmoChoco;

	private PlayerInput playerInput;
	private CharacterController characterController;
	private PlayerAnimation playerAnimation;

	private float iniGravity;
	private float moveX;
	private float moveY;
	private bool isJumping;
	private bool canAttack;
	private float attackCount;
	private Transform shootPoint;

	// Use this for initialization
	void Start () {
		playerInput =  this.gameObject.GetComponent<PlayerInput>();
		playerAnimation =  this.gameObject.GetComponent<PlayerAnimation>();
		characterController =  this.gameObject.GetComponent<CharacterController>();
		shootPoint = GameObject.Find("Player/HoodDefault/ShootPoint").transform;
		moveX = .0f;
		moveY = .0f;
		isJumping = false;
		iniGravity = gravity;
		attackCount = .0f;
		canAttack = true;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		Vector3 moveVector;

		if(playerInput.IsRight()){
			if(!playerAnimation.IsFacingRight()) playerAnimation.PlayerAnimationOrientation("right");
				
			if(moveX < 0) moveX = .0f;
			if(moveX < moveSpeed) moveX += moveAcceleration;
		}else{
			if(!playerInput.IsLeft()) moveX = .0f;
		}

		if(playerInput.IsLeft()){
			if(playerAnimation.IsFacingRight()) playerAnimation.PlayerAnimationOrientation("left");

			if(moveX > 0) moveX = .0f;
			if((moveX * -1 ) < moveSpeed) moveX -= moveAcceleration;
		}else{
			if(!playerInput.IsRight()) moveX = .0f;
		}

		if(characterController.isGrounded){
			gravity = iniGravity;

			if(playerInput.IsJump()){
				isJumping = true;
				moveY = jumpSpeed;
			}

		}else{
			if(moveY > .0f){
				isJumping = true;
				gravity = iniGravity;
			}
							
			if(!playerInput.IsJump() && isJumping){
				gravity = iniGravity * 2;
			}

			if((moveY * -1) < jumpSpeed){
				isJumping = false;
				moveY -= gravity;
			}

			if ((characterController.collisionFlags & CollisionFlags.Above) != 0){
				isJumping = false;
				moveY = - 6.0f;
			}
		}
			
		moveVector = new Vector3(moveX, moveY, 0);

		characterController.Move(moveVector * Time.deltaTime);

		if(attackCount < attackCooldown && !canAttack){
			attackCount += Time.deltaTime;
		}else{
			attackCount = .0f;
			canAttack = true;
		}

		if(canAttack && playerInput.IsFire()){
			Attack();
		}
	}

	public string GetMoveDebug(){
		string moveDebug;
		moveDebug = "SpeedX: " + moveX + "\nSpeedY: " + moveY + "\nIsGrounded: "+ characterController.isGrounded;
		return moveDebug;
	}

	public float GetMoveY(){
		return moveY;
	}
	public float GetMoveX(){
		return moveX;
	}

	public float GetSpeedX(){
		float speedX;
		speedX = Mathf.Abs(moveX);
		return speedX;
	}

	void Attack(){
		canAttack = false;
		playerAnimation.PlayAnimationAttack();

		//Attack
		Vector3 shotPosition;
		shotPosition = shootPoint.position;

		//Choco
		GameObject goShot;
		goShot = poolAmmoChoco.MakeGameObject(shotPosition, shootPoint.rotation);

		Projectile goProjectile;
		goProjectile = goShot.GetComponent<Projectile>();
		goProjectile.ShootMe(shootPoint, GetSpeedX()); 
	}

}
