using UnityEngine;
using Chameleon;

[RequireComponent(typeof(SpriteRenderer))]
public class MyBall : MonoBehaviour{
	SpriteRenderer spriteRenderer;
	Rigidbody2D rb;
	[Bakable] const float BALL_SPEED = 4.5f;
	[Bakable] const float SPEED_Y_MIN = 0.5f;
	[Bakable] readonly Vector2 rangeAngleStart = new Vector2(45f,135f); //deg
	[SerializeField][Preview][NoRange] AudioData audioDataSfxCollide;
	private eBrickColor color;
	public bool bPaused;

	public eBrickColor Color{
		get{return color;}
		set{
			color = value;
			spriteRenderer.color = SceneMainManager.getColorFromBrick(value);
		}
	}
	void Awake(){
		spriteRenderer = GetComponent<SpriteRenderer>();
		rb = GetComponent<Rigidbody2D>();
	}
	void Start(){
		Vector2 vStart = RandomExtension.onUnitCircle(rangeAngleStart);
		rb.velocity = BALL_SPEED*vStart;
	}
	void OnCollisionEnter2D(Collision2D collision){
		if(bPaused)
			return; //so velocity is not set if zeroed by pausing at the moment of collision
		rb.velocity = new Vector2(
			MathfExtension.inverseClamp(rb.velocity.x,-SPEED_Y_MIN,SPEED_Y_MIN),
			MathfExtension.inverseClamp(rb.velocity.y,-SPEED_Y_MIN,SPEED_Y_MIN)
		);
		rb.velocity = BALL_SPEED*rb.velocity.normalized;
		
		//Play sound
		if(!collision.collider.CompareTag("Brick"))
			/* if Brick, let it handles accordingly (maybe there is more 
			streamlined method?) */
			AudioPlayer.Instance.playSfx(audioDataSfxCollide);
	}
}

#if UNITY_EDITOR
[UnityEditor.CustomEditor(typeof(MyBall))]
class MyBallEditor : MonoBehaviourBakerEditor{ }
#endif
