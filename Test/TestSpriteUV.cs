using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class TestSpriteUV : MonoBehaviour{
	public Sprite sprite;
}

#if UNITY_EDITOR
[CustomEditor(typeof(TestSpriteUV))]
class TestSpriteUVEditor : Editor{
	private TestSpriteUV targetAs;

	void OnEnable(){
		targetAs = target as TestSpriteUV;
	}
	public override void OnInspectorGUI(){
		DrawDefaultInspector();
		if(GUILayout.Button("UV"))
			foreach(Vector2 v in targetAs.sprite.uv)
				Debug.Log(v.x+","+v.y);
	}
}
#endif
