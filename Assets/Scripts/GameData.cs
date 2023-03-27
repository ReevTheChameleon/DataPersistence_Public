using UnityEngine;
using System.IO;
using TMPro;
using Chameleon;

[System.Serializable]
public struct Highscore{
	public string playerName;
	public int score;
}

public static class GameData{
//---------------------------------------------------------------------
	#region DATA
	public static string playerName = "Grasshopper" ;
	private static Highscore[] aHighscore;
	public static int HighScoreCount{ get{return aHighscore?.Length ?? 0;} }
	public static Highscore getHighscore(int index){
		#if UNITY_EDITOR
		if(aHighscore==null)
			return new Highscore();
		#endif
		return aHighscore[index];
	}
	public static void insertHighscore(int index,string in_name,int in_score){
		if(index>=0 && index<aHighscore.Length){
			/* It is OK even when arrays overlap because documentation says it behaves
			as if there is temporary array. (Credit: MartinStettner, SO) */
			System.Array.Copy(aHighscore,index,aHighscore,index+1,aHighscore.Length-index-1);
			aHighscore[index] = new Highscore{playerName=in_name,score=in_score};
		}
	}
	public static int playerRankIndex;
	#endregion
//---------------------------------------------------------------------
	#region SAVE/LOAD
	[System.Serializable]
	private class SaveData{
		public string playerName;
		public Highscore[] aHighscore;
	}
	private const string SAVEFILE = "saveData.json";
	public static bool BLoaded{get; private set;}

	public static void save(){
		SaveData saveData = new SaveData();
		saveData.playerName = playerName;
		saveData.aHighscore = aHighscore;
		File.WriteAllText(
			Application.persistentDataPath+"/"+SAVEFILE,
			JsonUtility.ToJson(saveData)
		);
	}
	public static bool load(){
		string saveDataPath = Application.persistentDataPath+"/"+SAVEFILE;
		if(!File.Exists(saveDataPath)){
			resetToDefault();
			BLoaded = true;
			return false;
		}
		SaveData saveData = JsonUtility.FromJson<SaveData>(File.ReadAllText(saveDataPath));
		playerName = saveData.playerName;
		aHighscore = saveData.aHighscore;
		BLoaded = true;
		return true;
	}
	public static void resetToDefault(){
		playerName = "Grasshopper";
		aHighscore = new Highscore[5];
		aHighscore[0] = new Highscore{playerName="Yoda",score=399};
		aHighscore[1] = new Highscore{playerName="Mantis",score=294};
		aHighscore[2] = new Highscore{playerName="Anonymo",score=215};
		aHighscore[3] = new Highscore{playerName="B.B.",score=143};
		aHighscore[4] = new Highscore{playerName="Joe",score=70};
		BLoaded = false;
	}
	public static void deleteSave(){
		string saveDataPath = Application.persistentDataPath+"/"+SAVEFILE;
		if(File.Exists(saveDataPath))
			File.Delete(saveDataPath);
		/* Although File.Delete does not throw exception if file is not found,
		File.Exists check is necessary if you don't want DirectoryNotFoundException
		(Credit: Timothy Strimple, SO) */
	}
	#endregion
//---------------------------------------------------------------------
}
