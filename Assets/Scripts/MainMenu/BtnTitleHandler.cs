using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Chameleon;

public class BtnTitleHandler : BtnGlisten{
	RectTransform rectTransform;
	private RectTransformData rtDataNormal;

	protected override void Awake(){
		base.Awake();
		rectTransform = transform as RectTransform;
	}
	void Start(){
		rtDataNormal = rectTransform.save();
	}
	public override void OnPointerEnter(PointerEventData eventData){
		base.OnPointerEnter(eventData);
		rectTransform.expand(0.0f,0.0f,50.0f,0.0f);
	}
	public override void OnPointerExit(PointerEventData eventData){
		base.OnPointerExit(eventData);
		rectTransform.load(rtDataNormal);
	}
}
