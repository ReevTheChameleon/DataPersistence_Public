using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif
using TMPro;

public class TestAlphaTmpro : MonoBehaviour{
	public TextMeshProUGUI txt;
}

#if UNITY_EDITOR
[CustomEditor(typeof(TestAlphaTmpro))]
class TestAlphaTmproEditor : Editor{
	private TestAlphaTmpro targetAs;

	void OnEnable(){
		targetAs = target as TestAlphaTmpro;
	}
	public override void OnInspectorGUI(){
		DrawDefaultInspector();
		if(GUILayout.Button("Click")){
			targetAs.GetComponent<TextMeshProUGUI>().color = new Color32(255,0,0,128);
		}
	}
}
#endif
