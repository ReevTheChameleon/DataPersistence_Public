using UnityEngine;
using UnityEngine.EventSystems;

public class BtnResume : MonoBehaviour,
	IPointerClickHandler,IPointerDownHandler
{
	public void OnPointerClick(PointerEventData eventData){
		#if !UNITY_WEBGL
		performClickAction();
		#endif
	}
	public void OnPointerDown(PointerEventData eventData){
		#if UNITY_WEBGL
		performClickAction();
		#endif
	}
	public void performClickAction(){
		SceneMainManager.Instance.resume();
	}
}
