using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine.Tilemaps;
using Chameleon;

public class TestInstantiate : MonoBehaviour{
	public GameObject pfG;
}

#if UNITY_EDITOR
[CustomEditor(typeof(TestInstantiate))]
class TestInstantiateEditor : Editor{
	private TestInstantiate targetAs;

	void OnEnable(){
		targetAs = target as TestInstantiate;
	}
	public override void OnInspectorGUI(){
		DrawDefaultInspector();
		if(GUILayout.Button("Click")){
			Tilemap tilemap = targetAs.GetComponent<Tilemap>();
			Instantiate(
				targetAs.pfG,
				tilemap.pivottedWorldPos(new Vector3Int(1,1,0)),
				Quaternion.identity
			);
		}
	}
}
#endif
