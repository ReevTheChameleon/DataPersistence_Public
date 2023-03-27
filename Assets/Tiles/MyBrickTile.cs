using UnityEngine;
using UnityEngine.Tilemaps;
#if UNITY_EDITOR
using UnityEditor;
#endif

[CreateAssetMenu(fileName="MyBrickTile",menuName="MyBrickTile")]
public class MyBrickTile : Tile{
	[SerializeField] eBrickColor brickColor;
	public eBrickColor BrickColor{ get{return brickColor;} }
}
