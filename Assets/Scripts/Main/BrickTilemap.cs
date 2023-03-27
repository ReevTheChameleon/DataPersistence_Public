using UnityEngine;
using UnityEngine.Tilemaps;
using Chameleon;

[RequireComponent(typeof(Tilemap))]
public class BrickTilemap : MonoBehaviour{
	[SerializeField] ObjectPooler poolerBreakingTile;
	[SerializeField] MyBall ball;
	Tilemap tilemap;
	SceneMainManager sceneMainManager;
	private ContactPoint2D[] aContact = new ContactPoint2D[10];

	void Awake(){
		tilemap = GetComponent<Tilemap>();
		sceneMainManager = SceneMainManager.Instance;
	}
	//void OnCollisionEnter2D(Collision2D collision){
	//	onBrickCollision(collision);
	//}
	//void OnCollisionStay2D(Collision2D collision){
	//	onBrickCollision(collision); 
	//}

	/* This also doesn't work because OnCollisionEnter is called AFTER the collision
	happens and objects have already parted way, so the position used to calculate
	intersection is wrong */
	//private void onBrickCollision(Collision2D collision){
	//	if(!collision.gameObject.CompareTag("Ball"))
	//		return;
	//	CircleCollider2D circleCollider = collision.collider as CircleCollider2D;
	//	if(!circleCollider)
	//		return;
	//	BoundsInt boundOverlap = tilemap.getOverlappingCellBound(collision.collider.bounds);
	//	Debug.Log(boundOverlap);
	//	foreach(Vector3Int cell in boundOverlap.allPositionsWithin){
	//		Debug.Log("Here");
	//		if(tilemap.HasTile(cell))
	//			Debug.Log("Yeah");
	//		MyBrickTile brickTile = tilemap.GetTile<MyBrickTile>(cell);
	//		if(!brickTile)
	//			continue;
	//		Debug.Log("Here");
	//		Bounds bound = tilemap.GetBoundsLocal(cell);
	//		Rect tileRect = new Rect(bound.min,bound.max); //ignore bound.z
	//		if(!tileRect.isOverlappingCircle(circleCollider.transform.position,circleCollider.radius))
	//			continue;
			
	//		eBrickColor brickColor = brickTile.BrickColor;
	//		if(brickColor == ball.Color){
	//			tilemap.SetTile(cell,null);
	//			GameObject gBreakingBrick = poolerBreakingTile.getObject(
	//				tilemap.pivottedWorldPos(cell),
	//				Quaternion.identity 
	//			);
	//			gBreakingBrick.GetComponent<SpriteRenderer>().color =
	//				SceneMainManager.getColorFromBrick(brickColor);
	//			sceneMainManager.updateScore();
	//		}
	//		else
	//			sceneMainManager.clearCombo();
	//	}
	//}

	/* Below is old method which doesn't work because contact points are point in which
	force is applied, and NOT the intersecting point (Credit: Paul Masri-Stone, SO) */
	//void OnCollisionEnter2D(Collision2D c){
	//	if(!c.gameObject.CompareTag("Ball"))
	//		return;
	//	if(c.contactCount > aContact.Length)
	//		aContact = new ContactPoint2D[c.contactCount];
	//	int contactCount = c.GetContacts(aContact);
	//	for(int i=0; i<contactCount; ++i){
	//		Vector2 v2Point = aContact[i].point + aContact[i].normal*0.1f;
	//		Vector3Int vCell = tilemap.WorldToCell(v2Point);
	//		if(tilemap.HasTile(vCell)){
	//			//Let throw if cannot cast
	//			eBrickColor brickColor = ((MyBrickTile)tilemap.GetTile(vCell)).BrickColor;
	//			if(brickColor == ball.Color){
	//				tilemap.SetTile(vCell,null);
	//				GameObject gBreakingBrick = poolerBreakingTile.getObject(
	//					tilemap.pivottedWorldPos(vCell),
	//					Quaternion.identity 
	//				);
	//				gBreakingBrick.GetComponent<SpriteRenderer>().color =
	//					SceneMainManager.getColorFromBrick(brickColor);
	//				sceneMainManager.updateScore();
	//			}
	//			else
	//				sceneMainManager.clearCombo();
	//		}
	//	}
	//}
}
