using UnityEngine;
using UnityEngine.Tilemaps;
#if UNITY_EDITOR
using UnityEditor;
#endif
using Chameleon;

public class TestGetUsedTileCount : MonoBehaviour{
	public Tilemap tilemap;
	public Rect rect;
	public GridLayout grid;
	public GameObject g;
}

#if UNITY_EDITOR
[CustomEditor(typeof(TestGetUsedTileCount))]
class TestGetUsedTileCountEditor : Editor{
	private TestGetUsedTileCount targetAs;

	void OnEnable(){
		targetAs = target as TestGetUsedTileCount;
	}
	public override void OnInspectorGUI(){
		DrawDefaultInspector();
		if(GUILayout.Button("Used Tile Count"))
			Debug.Log(targetAs.tilemap.GetUsedTilesCount());
		if(GUILayout.Button("Tile Count"))
			Debug.Log(targetAs.tilemap.getTotalTileCount());
		if(GUILayout.Button("IntersectRect")){
			BoundsInt cellBound =
				targetAs.grid.getOverlappingCellBound(targetAs.GetComponent<Collider2D>().bounds);
			Debug.Log(cellBound);
			cellBound.size = cellBound.size.newZ(1);
			string s = "";
			foreach(Vector3Int v3Cell in cellBound.allPositionsWithin)
				s += v3Cell.ToString();	
			Debug.Log(s);
		}
		if(GUILayout.Button("Spawn")){
			GameObject g = Instantiate(
				targetAs.g,
				targetAs.tilemap.pivottedLocalPos(new Vector3Int(1,1,0)),
				Quaternion.identity
			);
			g.transform.SetParent(targetAs.tilemap.transform,false);
		}

	}
}
#endif
