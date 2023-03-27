using UnityEngine;
using TMPro;
using UnityEngine.UI;
using Chameleon;

public class ComboDisplay : MonoBehaviour{
	[SerializeField] TextMeshProUGUI txtComboCount;
	[SerializeField] RectMask2D maskComboBar;
	private float normalFontSize;
	private LoneCoroutine routineSinBumpCombo;

	void Awake(){
		normalFontSize = txtComboCount.fontSize;
		routineSinBumpCombo = new LoneCoroutine();
	}
	public void updateCombo(int comboCount){
		txtComboCount.text = "+"+comboCount.ToString();
		if(comboCount > 0){
			txtComboCount.fontSize = normalFontSize;
			routineSinBumpCombo.start(
				this,
				txtComboCount.sinBumpFontSize(
					SceneMainManager.BUMP_SCALE,SceneMainManager.BUMP_DURATION)
			);
		}
		maskComboBar.padding = maskComboBar.padding.newZ(
			maskComboBar.canvasRect.width * 
			(SceneMainManager.MAX_COMBO-comboCount)/SceneMainManager.MAX_COMBO
		);
	}
}
