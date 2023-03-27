using UnityEngine;

public class Deadzone : MonoBehaviour{
	void OnTriggerEnter2D(Collider2D other){
		SceneMainManager.Instance.onGameOver();
	}
}
