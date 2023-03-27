using UnityEngine;
using UnityEngine.SceneManagement;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class TestSceneIndex : MonoBehaviour{
	public Chameleon.SceneIndex s;
}

#if UNITY_EDITOR
[CustomEditor(typeof(TestSceneIndex))]
class TestSceneIndexEditor : Editor{
	private TestSceneIndex targetAs;

	void OnEnable(){
		targetAs = target as TestSceneIndex;
	}
	public override void OnInspectorGUI(){
		DrawDefaultInspector();
		if(GUILayout.Button("Click")){
			Debug.Log(SceneManager.sceneCountInBuildSettings);
			for(int i=0; i<SceneManager.sceneCountInBuildSettings; ++i){
				Debug.Log(SceneUtility.GetScenePathByBuildIndex(i));
				Debug.Log(EditorBuildSettings.scenes[i].enabled);
			}
			Debug.Log(EditorBuildSettings.scenes.Length);
		}
	}
}
#endif
