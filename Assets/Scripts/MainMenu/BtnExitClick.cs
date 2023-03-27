using UnityEngine;
using UnityEngine.EventSystems;
#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine.InputSystem;
using TMPro;
using Chameleon;

[RequireComponent(typeof(PlayerInput))]
public class BtnExitClick : MonoBehaviour,IPointerClickHandler
{
	[SerializeField] TextMeshProUGUI txtButton;
	[SerializeField] TextMeshProUGUI txtSavePath;
	[SerializeField] InputActionID actionIDAlter;
	PlayerInput playerInput;
	private bool bAlter = false;
	private const string txtButtonNormal = "Quit";
	private const string txtButtonAlter = "Delete Save & Quit";

	void Awake(){
		playerInput = GetComponent<PlayerInput>();
		txtButton.text = txtButtonNormal;
	}
	public void OnEnable(){
		playerInput.actions[actionIDAlter.Id].performed += onInputQuitAlterPerformed;
		playerInput.actions[actionIDAlter.Id].canceled += onInputQuitAlterCancelled;
	}
	public void OnDisable(){
		playerInput.actions[actionIDAlter.Id].performed -= onInputQuitAlterPerformed;
		playerInput.actions[actionIDAlter.Id].canceled -= onInputQuitAlterCancelled;
	}
	public void OnPointerClick(PointerEventData eventData){
		if(bAlter)
			GameData.deleteSave();

	#if UNITY_EDITOR
		EditorApplication.isPlaying = false;
	#else
		#if UNITY_WEBGL
			this.delayCall(()=>{Application.Quit();},0.3f);
			/* This is not fool-proof. Will find better option later */
		#endif
		Application.Quit();
	#endif
	}
	private void onInputQuitAlterPerformed(InputAction.CallbackContext context){
		txtButton.text = txtButtonAlter;
		txtSavePath.text = Application.persistentDataPath;
		bAlter = true;
	}
	private void onInputQuitAlterCancelled(InputAction.CallbackContext context){
		txtButton.text = txtButtonNormal;
		txtSavePath.text = "";
		bAlter = false;
	}
}
