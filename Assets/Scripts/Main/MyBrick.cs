using UnityEngine;
using Chameleon;

[RequireComponent(typeof(Flipbook))]
public class MyBrick : MonoBehaviour{
	[SerializeField] eBrickColor color;
	[SerializeField][Preview][NoRange] AudioData sfxOneShotBreak;
	[SerializeField][Preview][NoRange] AudioData sfxOneShotNotBreak;
	private SceneMainManager sceneMainManager;
	private bool bDestroyed = false; //Prevent multiple collision on single brick
	Flipbook flipbook;
	new Collider2D collider;

	void Awake(){
		sceneMainManager = SceneMainManager.Instance;
		flipbook = GetComponent<Flipbook>();
		collider = GetComponent<Collider2D>();
	}
	void OnCollisionEnter2D(Collision2D collision){
		MyBall ball = collision.gameObject.GetComponent<MyBall>();
		if(!ball)
			return;
		if(ball.Color==color){
			if(bDestroyed) //the brick is being destroyed, don't clear combo nor update score
				return;
			this.delayCall(()=>{collider.enabled = false;},0.1f);
			flipbook.flipOnce(()=>{Destroy(gameObject);});
			sceneMainManager.updateScore();
			AudioPlayer.Instance.playSfx(sfxOneShotBreak);
			bDestroyed = true;
		}
		else{
			sceneMainManager.clearCombo();
			AudioPlayer.Instance.playSfx(sfxOneShotNotBreak);
		}
	}
}
