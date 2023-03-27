using UnityEngine;
using UnityEngine.EventSystems;
using Chameleon;

public class BallClick : MonoBehaviour,IPointerClickHandler{
	[SerializeField] AnimationCurve animCurveBoing;
	[SerializeField] float boingAmount;
	[SerializeField] float boingTime;
	RectTransform rectTransform;
	private Coroutine routineBoing;
	private bool bIsBoing = false;

	void Awake(){
		rectTransform = transform as RectTransform;
	}
	public void OnPointerClick(PointerEventData eventData){
		RectTransformData rtDataNormal = rectTransform.save();
		rectTransform.expand(boingAmount,boingAmount,boingAmount,boingAmount);
		RectTransformData rtDataExpand = rectTransform.save();
		rectTransform.load(rtDataNormal);
		if(bIsBoing)
			StopCoroutine(routineBoing);
		routineBoing = StartCoroutine(
			rectTransform.tweenRectTransform(
				rtDataNormal,
				rtDataExpand,
				boingTime,
				eTweenLoopMode.Once,
				0.0f,
				animCurveBoing.Evaluate,
				(float t) => {bIsBoing=false;}
			)
		);
		bIsBoing = true;
	}
}
