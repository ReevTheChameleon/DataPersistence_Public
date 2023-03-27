using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine.Tilemaps;

public static class TestTileToSprite{
	[MenuItem("CONTEXT/Tilemap/To Sprite")]
	static void func(MenuCommand menuCommand){
		Tilemap tilemap = (Tilemap)menuCommand.context;
		tilemap.CompressBounds();
		BoundsInt tilemapBound = tilemap.cellBounds;
		for(int i=tilemapBound.xMin; i<=tilemapBound.xMax; ++i){
			for(int j=tilemapBound.yMin; j<=tilemapBound.yMax; ++j){
				GameObject g = new GameObject();
				Undo.RegisterCreatedObjectUndo(g,"Tile to Sprite");
				GameObjectUtility.SetParentAndAlign(g,tilemap.transform.parent.gameObject);
			}
		}

	}
}
