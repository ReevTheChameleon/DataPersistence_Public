using UnityEngine;
using UnityEngine.EventSystems;
using Chameleon;
using UnityEngine.SceneManagement;

public class BtnGlow : BtnGlisten{
	[SerializeField] GameObject gGlow;

	void Start(){
		gGlow.SetActive(false);
	}
	public override void OnPointerEnter(PointerEventData eventData){
		base.OnPointerEnter(eventData);
		gGlow.SetActive(true);
	}
	public override void OnPointerExit(PointerEventData eventData){
		base.OnPointerExit(eventData);
		gGlow.SetActive(false);
	}
}
