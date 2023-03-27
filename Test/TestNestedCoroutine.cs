using UnityEngine;
using System.Collections;

public class TestNestedCoroutine : MonoBehaviour{
	void Start(){
		//StartCoroutine(func());
		func2(1).MoveNext();
	}
	private IEnumerator func(){
		Debug.Log("What");
		for(int i=0; i<500; ++i){
			Debug.Log("Here");
			func2(i);
		}
		Debug.Log("End");
		yield return null;
	}
	private IEnumerator func2(int i){
		Debug.Log("Hi");
		yield return null;
		Debug.Log("Hi2");
	}
}
