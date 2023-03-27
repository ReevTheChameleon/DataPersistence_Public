using UnityEngine;
using System;
#if UNITY_EDITOR
using UnityEditor;
#endif
using System.Collections.Generic;

public static class GradientExtension{
	public static Gradient create(GradientColorKey[] aColorkey,
		GradientAlphaKey[] aAlphakey,GradientMode mode)
	{
		Gradient temp = new Gradient();
		temp.SetKeys(aColorkey,aAlphakey);
		temp.mode = mode;
		return temp;
	}
}

public class TestJSON : MonoBehaviour{
	public Gradient g;
	public int i;
	public Gradient g2;
	public string sG;
	public string sG2;
	public int i2;
}

[CustomEditor(typeof(TestJSON))]
class TestJSONEditor : Editor{
	TestJSON targetAs;
	void OnEnable(){
		targetAs = (TestJSON)target;
	}
	public override void OnInspectorGUI(){
		DrawDefaultInspector();
		if(GUILayout.Button("Click")){
			targetAs.sG = JsonUtility.ToJson(new GradientWrapper{obj=targetAs.g});
			targetAs.sG2 = JsonUtility.ToJson(new IntWrapper{obj=targetAs.i});
			Debug.Log(targetAs.sG);
		}
		if(GUILayout.Button("Click2")){
			targetAs.g2 = JsonUtility.FromJson<GradientWrapper>(targetAs.sG).obj;
			targetAs.i2 = JsonUtility.FromJson<IntWrapper>(targetAs.sG2).obj;
			//EditorUtility.SetDirty(targetAs);
			//Repaint();
		}
	}
}

class Wrapper<T>{
	public T obj;
}

class GradientWrapper : Wrapper<Gradient>{}
class IntWrapper : Wrapper<int>{}
