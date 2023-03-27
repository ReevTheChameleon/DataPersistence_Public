using UnityEngine;
using Chameleon;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class TestBake : MonoBehaviour{
	//[Bakable] int i = 9;
	[Bakable] Color c = new Color(0f,0.204f,1f,0f);
	[Bakable] Vector3 v = new Vector3(0.72f,0.99f,0.57f);
	[Bakable] Vector2 v2 = new Vector2(5.07f,-0.63f);
	[Bakable] Vector3Int v3Int = new Vector3Int(0,0,0);
	[Bakable] Vector2Int v2Int = new Vector2Int(0,0);
	[Bakable] const float cf = 8f;
	[Bakable] const int ci = 2;
	public Vector3 v3;
	public Vector2 v22;
}

#if UNITY_EDITOR
[CustomEditor(typeof(TestBake))]
class TestBakeEditor : MonoBehaviourBakerEditor{
	public override void OnInspectorGUI() {
		base.OnInspectorGUI();
		DrawDefaultInspector();
	}
}
#endif
