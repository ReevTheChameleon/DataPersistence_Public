using UnityEngine;
using Chameleon;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class BtnClickChangeScene : MonoBehaviour,IPointerClickHandler{
	[SerializeField] SceneIndex sceneIndex;

	public void OnPointerClick(PointerEventData eventData){
		SceneManager.LoadSceneAsync(sceneIndex.Index);
	}
}
