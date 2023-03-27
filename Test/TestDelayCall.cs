using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class TestDelayCall : MonoBehaviour{

}

#if UNITY_EDITOR
[CustomEditor(typeof(TestDelayCall))]
class TestDelayCallEditor : Editor{
	private TestDelayCall targetAs;

	void OnEnable(){
		targetAs = target as TestDelayCall;
	}
	public override void OnInspectorGUI(){
		DrawDefaultInspector();
		if(GUILayout.Button("Click")){
			for(int i=0; i<100; ++i)
				EditorApplication.delayCall += func;
		}
		Debug.Log(EditorApplication.delayCall?.GetInvocationList().Length);
	}
	void func(){
		Debug.Log("Whatever");
	}
}
#endif
