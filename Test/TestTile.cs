using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine.Tilemaps;

public class TestTile : MonoBehaviour{
	public Sprite testSprite;

}

#if UNITY_EDITOR
[CustomEditor(typeof(TestTile))]
class TestSpriteEditor : Editor{
	private TestTile targetAs;

	void OnEnable(){
		targetAs = target as TestTile;
	}
	public override void OnInspectorGUI(){
		DrawDefaultInspector();
		if(GUILayout.Button("Tile")){
			Tile tile = targetAs.GetComponent<Tilemap>().GetTile(new Vector3Int(1,1,0)) as Tile;
			tile.sprite = targetAs.testSprite;
			targetAs.GetComponent<Tilemap>().RefreshAllTiles();
			Debug.Log(targetAs.GetComponent<Tilemap>().cellBounds);
		}
	}
}
#endif
