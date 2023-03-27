using UnityEngine;
using System.Collections;
using UnityEngine.InputSystem;

public class TestLoneCoroutine : MonoBehaviour{
	Coroutine coroutine;
	void Start(){
		//StopCoroutine(coroutine);
		coroutine = StartCoroutine(testRoutine());
		Debug.Log(coroutine==null);
	}

	private IEnumerator testRoutine(){
		yield return null;
	}
	bool bIsRunning = false;
	void Update(){
		for(int i=0; i<1000000; ++i)
			if(bIsRunning)
				StopCoroutine(coroutine);
	}
}
