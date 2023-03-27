using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class ColorIndicator : MonoBehaviour{
	[SerializeField] Image imgTarget;
	[SerializeField] GameObject gGlow;
	[SerializeField] Color colorNormal;
	[SerializeField] Color colorActive;

	void Awake(){
		imgTarget.color = colorNormal;
		gGlow.SetActive(false);
	}
	public void setActivate(bool bActivate){
		imgTarget.color = bActivate ? colorActive : colorNormal;
		gGlow.SetActive(bActivate);
	}
}
