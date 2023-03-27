using UnityEngine;
using Chameleon;
using System.Collections;

public class SceneHighscoreManager : LoneMonoBehaviour<SceneHighscoreManager>{
	[SerializeField] HighscoreEntry[] aHighscoreEntry;
	[Bakable][ShowWireCube("L")] Bounds boundFireworkSpawnL = new Bounds(new Vector3(-7.6f,1.5f,0f),new Vector3(6f,12f,0f));
	[Bakable][ShowWireCube("R")] Bounds boundFireworkSpawnR = new Bounds(new Vector3(7.6f,1.5f,0f),new Vector3(6f,12f,0f));
	[Bakable] Vector2 fireworkInterval = new Vector2(0.5f,1.5f);
	ObjectPooler poolerFirework;
	private int entryCount;

	protected override void Awake(){
		base.Awake();
		entryCount = Mathf.Min(GameData.HighScoreCount,aHighscoreEntry.Length);
		int i=0;
		while(i<entryCount){
			aHighscoreEntry[i].setHighscore(GameData.getHighscore(i));
			++i;
		}
		while(i<aHighscoreEntry.Length)
			aHighscoreEntry[i++].clear();
		
		poolerFirework = GetComponent<ObjectPooler>();
	}
	void Start(){
		int playerIndex = GameData.playerRankIndex;
		if(playerIndex>=0 && playerIndex<entryCount){
			StartCoroutine(spawnFirework(boundFireworkSpawnL));
			StartCoroutine(spawnFirework(boundFireworkSpawnR));
			aHighscoreEntry[playerIndex].highlight();
		}
	}
	IEnumerator spawnFirework(Bounds bound){
		while(true){
			yield return new WaitForSeconds(
				Random.Range(fireworkInterval.x,fireworkInterval.y)
			);
			poolerFirework.getObject(
				RandomExtension.insideCube(bound),
				Quaternion.identity
			);
		};
	}
}

#if UNITY_EDITOR
[UnityEditor.CustomEditor(typeof(SceneHighscoreManager))]
class SceneHighscoreManagerEditor : MonoBehaviourBakerEditorWithScene{ }
#endif
