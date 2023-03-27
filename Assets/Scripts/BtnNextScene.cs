using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using Chameleon;

public class BtnNextScene : MonoBehaviour,
	IPointerClickHandler,IPointerDownHandler,IPointerUpHandler
{
	[SerializeField] SceneIndex sceneIndex;
	public void OnPointerClick(PointerEventData eventData){
		#if !UNITY_WEBGL
		performClickAction();
		#endif
	}
	public void OnPointerDown(PointerEventData eventData){
		#if UNITY_WEBGL
		if(sceneIndex.Index == 3){
		/* This is a really hotfix for WebGL to handle its weird cursor lock tool */
			Cursor.lockState = CursorLockMode.Locked;}
		#endif
	}
	public void OnPointerUp(PointerEventData eventData){
		#if UNITY_WEBGL
		performClickAction();
		#endif
	}
	public void performClickAction(){
		SceneManager.LoadSceneAsync(sceneIndex.Index);
	}
}
