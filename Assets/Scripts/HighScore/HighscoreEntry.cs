using UnityEngine;
using TMPro;
using Chameleon;

public class HighscoreEntry : MonoBehaviour{
	[SerializeField] TextMeshProUGUI txtName;
	[SerializeField] TextMeshProUGUI txtScore;
	
	[Bakable] static Color highlightColor = new Color(1f,0.8970646f,0f,1f);
	[Bakable] static float highlightFontSize = 32f;

	public void setHighscore(Highscore highscore){
		txtName.text = highscore.playerName;
		txtScore.text = highscore.score.ToString();
	}
	public void clear(){
		txtName.text = "";
		txtScore.text = "";
	}
	public void highlight(){
		txtName.color = highlightColor;
		txtName.fontSize = highlightFontSize;
		txtScore.color = highlightColor;
		txtScore.fontSize = highlightFontSize;
	}
}

#if UNITY_EDITOR
[UnityEditor.CustomEditor(typeof(HighscoreEntry))]
class HighscoreEntryEditor : MonoBehaviourBakerEditor{ }
#endif
