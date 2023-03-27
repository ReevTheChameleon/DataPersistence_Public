using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
public class BtnMainContinue : MonoBehaviour,IPointerClickHandler{
	public void OnPointerClick(PointerEventData eventData){
		SceneManager.LoadSceneAsync(SceneMainManager.Instance.IndexNextScene);
	}
}
