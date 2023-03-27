using UnityEngine;
using TMPro;
using Chameleon;
using System.Collections;
using UnityEngine.UI;

public enum eBrickColor{NONE=0,RED,GREEN,BLUE,YELLOW}

public class SceneMainManager : LoneMonoBehaviour<SceneMainManager>{
	[Bakable] static readonly Color colorRed = new Color(0.9921569f,0f,0f,1f);
	[Bakable] static readonly Color colorGreen = new Color(0f,0.9921569f,0f,1f);
	[Bakable] static readonly Color colorBlue = new Color(0.2078432f,0.8470589f,0.9921569f,1f);
	[Bakable] static readonly Color colorYellow = new Color(0.9921569f,0.9921569f,0f,1f);

	[Header("Score UI")]
	[Bakable] const int BASE_SCORE = 5;
	[Bakable] public const int MAX_COMBO = 5;
	[SerializeField] TextMeshProUGUI txtPlayerName;
	[SerializeField] TextMeshProUGUI txtScoreNumber;
	private int score = 0;
	private int comparingIndex;
	private float txtScoreFontSize;
	
	private LoneCoroutine routineSineBumpScore = new LoneCoroutine();
	[Bakable] public const float BUMP_SCALE = 1.5f;
	[Bakable] public const float BUMP_DURATION = 0.2f;
	
	[Header("Highscore UI")]
	[SerializeField] GameObject gGroupHighscore;
	[SerializeField] TextMeshProUGUI txtComparingRank;
	[SerializeField] TextMeshProUGUI txtComparingHighscore;
	private LoneCoroutine routineShakeHighscore = new LoneCoroutine();
	private Vector3 vHighscorePos;
	[Bakable] readonly Vector3 vHighscoreShake = new Vector3(0.3f,0f,0f);
	[Bakable] const float SHAKE_DURATION = 0.2f;
	ParticleSystem psHighscore;

	[SerializeField] ComboDisplay comboDisplay;
	private int comboCount = 0;

	[Header("Scene Flow")]
	[SerializeField] SceneIndex sceneIndexMainMenu;
	[SerializeField] SceneIndex sceneIndexHighscore;
	public int IndexNextScene{get; private set;}
	
	[Header("Dialog GameOver")]
	[SerializeField] GameObject gDialogGameOver;
	[SerializeField] TextMeshProUGUI txtGameOverScore;
	[SerializeField] TextMeshProUGUI txtNextScene;

	[Header("Dialog Pause")]
	[SerializeField] GameObject gDialogPause;
	[SerializeField][Preview] AudioData sfxPause;

	[Header("Ball & ColorIndicator")]
	[SerializeField] MyBall ball;
	[SerializeField] ColorIndicator[] aColorIndicator;
	Rigidbody2D rbBall;
	Rigidbody2DMovementData rbBallSavedMovement;

	[Header("End Score")]
	[SerializeField] Transform tTileRoot;
	[SerializeField] TextMeshProUGUI txtEndScore;
	[SerializeField][Preview] AudioData sfxEndScore;
	[Bakable] const float END_DELAY = 0.8f;
	[Bakable] const float ENDSCORE_FLOAT_DISTANCE = 0.8f;
	private int tileCount;

	[Header("Audio")]
	[SerializeField][Preview] AudioData bgm;

	public bool BPaused{get; private set;}
	public bool BGameOver{get; private set;}

	protected override void Awake(){
		base.Awake();
		txtScoreFontSize = txtScoreNumber.fontSize;
		psHighscore = gGroupHighscore.GetComponent<ParticleSystem>();
		gDialogGameOver.SetActive(false);
		gDialogPause.SetActive(false);

		rbBall = ball.GetComponent<Rigidbody2D>();
		tileCount = countLeafChild(tTileRoot,false);
		txtEndScore.gameObject.SetActive(false);
		
		Cursor.lockState = CursorLockMode.Locked;
		//Cursor is automatically invisible in this mode
		BGameOver = false;
		BPaused = false;
	}
	void Start(){
		vHighscorePos = gGroupHighscore.transform.position;
		comparingIndex = GameData.HighScoreCount-1;
		txtPlayerName.text = GameData.playerName;
		txtScoreNumber.text = score.ToString();
		Highscore comparingHighscore = GameData.getHighscore(comparingIndex);
		txtComparingRank.text = "Highscore #" + (comparingIndex+1);
		txtComparingHighscore.text =
			comparingHighscore.playerName + ": " + comparingHighscore.score
		;
		clearCombo();
		setBallColor(eBrickColor.RED);
		AudioPlayer.Instance?.playBgm(bgm);
	}
	public void updateScore(){
		--tileCount;
		if(tileCount <= 0)
			onDestroyAllBricks();
		score += BASE_SCORE + comboCount;
		comboCount = Mathf.Clamp(comboCount+1,0,MAX_COMBO);
		txtScoreNumber.text = score.ToString();
		txtScoreNumber.fontSize = txtScoreFontSize;
		routineSineBumpScore.start(
			this,
			txtScoreNumber.sinBumpFontSize(BUMP_SCALE,BUMP_DURATION)
		);
		updateComparingRank();
		comboDisplay.updateCombo(comboCount);
	}
	public void clearCombo(){
		comboCount = 0;
		comboDisplay.updateCombo(0);
	}
	private void updateComparingRank(){
		int prevComparingIndex = comparingIndex;
		while(comparingIndex>=0 && score>GameData.getHighscore(comparingIndex).score)
			--comparingIndex;
		if(comparingIndex != prevComparingIndex){
			if(comparingIndex<0 || comparingIndex>=GameData.HighScoreCount){
				txtComparingRank.text = "You're rank #1!";
				txtComparingHighscore.text = "Keep going!";
			}
			else{
				Highscore comparingHighscore = GameData.getHighscore(comparingIndex);
				txtComparingRank.text = "Highscore #" + (comparingIndex+1);
				txtComparingHighscore.text =
					comparingHighscore.playerName + ": " + comparingHighscore.score
				;
			}
			psHighscore.Play();
			gGroupHighscore.transform.position = vHighscorePos;
			routineShakeHighscore.start(
				this,
				gGroupHighscore.transform.sinShakePosition(
					vHighscoreShake,SHAKE_DURATION
				)
			);
		}
	}
	public static Color getColorFromBrick(eBrickColor brickColor){
		switch(brickColor){
			case eBrickColor.RED: return colorRed;
			case eBrickColor.GREEN: return colorGreen;
			case eBrickColor.BLUE: return colorBlue;
			case eBrickColor.YELLOW: return colorYellow;
		}
		return Color.black;
	}
	public void onGameOver(){
		BGameOver = true;
		Cursor.lockState = CursorLockMode.Confined;
		gDialogGameOver.SetActive(true);
		txtGameOverScore.text = "Your score: "+score;
		GameData.playerRankIndex = comparingIndex+1;
		if(comparingIndex<GameData.HighScoreCount-1){
			GameData.playerRankIndex = comparingIndex+1;
			GameData.insertHighscore(comparingIndex+1,GameData.playerName,score);
			GameData.save();
			IndexNextScene = sceneIndexHighscore.Index; //TODO: add player name to highscore rank
			txtNextScene.text = "You Ranked High Score!";
		}
		else{
			IndexNextScene = sceneIndexMainMenu.Index;
			txtNextScene.text = "Back to Main Menu";
		}
	}
	public void setBallColor(eBrickColor color){
		ball.Color = color;
		for(int i=0; i<aColorIndicator.Length; ++i)
			aColorIndicator[i].setActivate(i==(int)(color-1)); //0 is NONE
	}
	public void pause(){
		Cursor.lockState = CursorLockMode.Confined;
		BPaused = true;
		ball.bPaused = true;
		rbBallSavedMovement = rbBall.saveMovement();
		rbBall.Sleep();
		gDialogPause.SetActive(true);
		AudioPlayer.Instance?.playSfx(sfxPause);
	}
	public void resume(){
		Cursor.lockState = CursorLockMode.Locked;
		gDialogPause.SetActive(false);
		rbBall.WakeUp();
		rbBall.loadMovement(rbBallSavedMovement);
		ball.bPaused = false;
		BPaused = false;
		AudioPlayer.Instance?.playSfx(sfxPause);
	}
	private int countLeafChild(Transform tRoot,bool bIncludeInactive=true){
		//Count only the last children
		int count = 0;
		foreach(Transform tChild in tRoot){
			if(tChild.gameObject.activeInHierarchy || bIncludeInactive){
				if(tChild.childCount == 0)
					++count;
				else
					count += countLeafChild(tChild,bIncludeInactive);
			}
		}
		return count;
	}
	private void onDestroyAllBricks(){
		ball.bPaused = true;
		rbBall.Sleep();
		BGameOver = true;
		Vector3 vBallPos = ball.transform.position;
		txtEndScore.gameObject.SetActive(true);
		StartCoroutine(txtEndScore.tweenAlpha(1.0f,0.0f,END_DELAY));
		StartCoroutine(txtEndScore.transform.tweenPosition(
			vBallPos,
			vBallPos+new Vector3(0.0f,ENDSCORE_FLOAT_DISTANCE,0.0f),
			END_DELAY
		));
		score += 50;
		txtScoreNumber.text = score.ToString();
		this.delayCall(onGameOver,END_DELAY);
		AudioPlayer.Instance?.playSfx(sfxEndScore);
	}
}

#if UNITY_EDITOR
[UnityEditor.CustomEditor(typeof(SceneMainManager))]
class SceneMainManagerEditor : MonoBehaviourBakerEditorWithScene{ }
#endif
