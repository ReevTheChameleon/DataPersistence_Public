using UnityEngine;

public class MoveUp : MonoBehaviour{
	public Vector2 v2Force;

	void Start(){
		GetComponent<Rigidbody2D>().AddForce(v2Force);
	}
}
