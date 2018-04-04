using UnityEngine;
using System.Collections;
using System;

public class PoolObjects : MonoBehaviour {

	// make an array of poolSize enemies:
	public GameObject myPrefab;
	public int poolSize;
	public ArrayList gameObjects;

	// Use this for initialization
	void Start () {
		gameObjects = new ArrayList();
		GameObject go;
		
		for(int i = 0; i < poolSize; i++) {
			go = Instantiate(myPrefab, transform.position , Quaternion.Euler(0,0,0)) as GameObject;
			go.gameObject.name = go.gameObject.name.Replace("(Clone)", "");
			
			go.gameObject.transform.parent = this.gameObject.transform;
			
			gameObjects.Add(go.gameObject);
			
			// disable
			go.gameObject.SetActive(false);

			if(i == 0) gameObject.name = "_Pool" + go.gameObject.name;
		}
	}
	
	//To "spawn" one in the game, grab an inactive one. If it has lots of variables, have to reset them all.
	public GameObject MakeGameObject( Vector3 pos, Quaternion rot){
		// search list for unused enemy:
		int goNum = -1;
		GameObject result = null;
		try{
			foreach(GameObject go in gameObjects){
				if(!go.gameObject.activeSelf){
					goNum = 1;
					result = go;
					break;
				}
			}
		}catch (Exception e){
			print("error: " + e.ToString());
			return null;
		}
		
		// found one (if we couldn't find unused enemy, no spawn):
		if(goNum == 1) { 
			// Activate this enemy, move it to spawn point:
			result.gameObject.SetActive(true);
			result.transform.position = pos;
			result.transform.rotation = rot;
			
		}else{
			GameObject goNew;
			goNew = Instantiate(myPrefab, pos, rot) as GameObject;
			
			goNew.gameObject.transform.parent = this.gameObject.transform;
			
			gameObjects.Add(goNew.gameObject);
			result = goNew;		
			//Debug.Log("Created:" + goNew.gameObject.name);
		}
		
		return result.gameObject;
	}
}
