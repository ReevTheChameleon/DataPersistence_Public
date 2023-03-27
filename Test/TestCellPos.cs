using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine.Tilemaps;

public class TestCellPos : MonoBehaviour{
	public Vector2 v2Test;
	public Color color;
}

#if UNITY_EDITOR
[CustomEditor(typeof(TestCellPos))]
class TestCellPosEditor : Editor{
	private TestCellPos targetAs;

	void OnEnable(){
		targetAs = target as TestCellPos;
	}
	public override void OnInspectorGUI(){
		DrawDefaultInspector();
		if(GUILayout.Button("Click"))
			Debug.Log(targetAs.GetComponent<Tilemap>().WorldToCell(targetAs.v2Test));
	}
}
#endif
