using UnityEngine;
using TMPro;

[RequireComponent(typeof(TMP_InputField))]
public class InputNameSubmit : MonoBehaviour{
	TMP_InputField inputField;

	void Awake(){
		inputField = GetComponent<TMP_InputField>();
	}
	void Start(){
		inputField.text = GameData.playerName;
	}
	public void onEndEdit(){
		GameData.playerName = inputField.text;
		GameData.save();
		/* Because SaveData is small for this apps, this is acceptable.
		If the app is larger, may need to write more specific code.
		Alternative options are:
		1) To save when quit button is clicked, but this doesn't help
		if user close window or crash, and user may lose all progress easily.
		2) To save at Application.quitting, but this is platform dependent,
		where it doesn't work in Windows Store App, Windows Phone 8.1,
		some iOS variants, and is also likely not working for WebGL */
	}
}
