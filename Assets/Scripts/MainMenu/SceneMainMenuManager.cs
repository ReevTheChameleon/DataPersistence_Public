using UnityEngine;
using TMPro;
using Chameleon;

public class SceneMainMenuManager : LoneMonoBehaviour<SceneMainMenuManager>{
	[SerializeField] TMP_InputField inputField;
	[SerializeField][Preview] AudioData audioBgm;

	protected override void Awake(){
		base.Awake();
		if(!GameData.BLoaded)
			GameData.load();
		inputField.text = GameData.playerName;
		GameData.playerRankIndex = -1;
	}
	void Start(){
		if(AudioPlayer.Instance?.audioClipBgm != audioBgm.audioClip)
			AudioPlayer.Instance.playBgm(audioBgm);
	}
}

#if UNITY_EDITOR
[UnityEditor.CustomEditor(typeof(SceneMainMenuManager))]
class SceneMainMenuManagerEditor : UnityEditor.Editor{
	public override void OnInspectorGUI(){
		DrawDefaultInspector();
		if(GUILayout.Button("Reset GameData"))
			GameData.resetToDefault();
		if(GUILayout.Button("Save GameData"))
			GameData.save();
	}
}
#endif
