using UnityEngine;

public class TestOValue : MonoBehaviour{
	int i;
	void Start(){
		object o = i;
		Debug.Log(o.GetType());
	}
}
