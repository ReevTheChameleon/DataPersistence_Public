using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif
using Chameleon;

public class TestCopyRect : MonoBehaviour{
	public int i;
	public Gradient g;
	public Gradient[] ag;
	public Vector2 v2;
	public Vector3Int v3int;
	public Color c;
	public Bounds b;

	#if UNITY_EDITOR
	[CustomEditor(typeof(TestCopyRect))]
	class TestCopyRectEditor : Editor{
		private TestCopyRect targetAs;

		void OnEnable(){
			targetAs = target as TestCopyRect;
		}
		public override void OnInspectorGUI(){
			DrawDefaultInspector();
			if(GUILayout.Button("Click"))
				Debug.Log(EditorGUIUtility.systemCopyBuffer);
			if(targetAs.g == null)
				targetAs.g = new Gradient();
			EditorGUILayout.GradientField("Gradient",targetAs.g);
			Rect rect =GUILayoutUtility.GetLastRect();
			EditorHelper.copyPasteContextMenu(rect,targetAs,nameof(targetAs.g));
			if(GUILayout.Button("Click2"))
				testpass(ref targetAs.g);
			if(GUILayout.Button("Click3"))
				Debug.Log(false.ToString());
		}
		private void testpass(ref Gradient g){
			g = new Gradient();
		}
	}
#endif
}
