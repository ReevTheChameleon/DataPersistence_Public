using UnityEngine;
using Chameleon;
#if UNITY_EDITOR
using UnityEditor;
#endif
using System.Collections.Generic;

public class TestJsonBake : MonoBehaviour{
	#pragma warning disable 0414
	public int ii;
	public float ff;
	public Gradient gg;
	public AnimationCurve cc;
	public Vector3 v;
	public Color c;
	[JsonBakable] static Gradient g = JsonUtility.FromJson<Chameleon.JustWrapper<UnityEngine.Gradient> >("{\"obj\":{\"serializedVersion\":\"2\",\"key0\":{\"r\":1.0,\"g\":0.0,\"b\":0.0,\"a\":1.0},\"key1\":{\"r\":1.0,\"g\":1.0,\"b\":1.0,\"a\":1.0},\"key2\":{\"r\":0.0,\"g\":0.0,\"b\":0.0,\"a\":0.0},\"key3\":{\"r\":0.0,\"g\":0.0,\"b\":0.0,\"a\":0.0},\"key4\":{\"r\":0.0,\"g\":0.0,\"b\":0.0,\"a\":0.0},\"key5\":{\"r\":0.0,\"g\":0.0,\"b\":0.0,\"a\":0.0},\"key6\":{\"r\":0.0,\"g\":0.0,\"b\":0.0,\"a\":0.0},\"key7\":{\"r\":0.0,\"g\":0.0,\"b\":0.0,\"a\":0.0},\"ctime0\":0,\"ctime1\":65535,\"ctime2\":0,\"ctime3\":0,\"ctime4\":0,\"ctime5\":0,\"ctime6\":0,\"ctime7\":0,\"atime0\":0,\"atime1\":65535,\"atime2\":0,\"atime3\":0,\"atime4\":0,\"atime5\":0,\"atime6\":0,\"atime7\":0,\"m_Mode\":0,\"m_NumColorKeys\":2,\"m_NumAlphaKeys\":2}}").obj;
	[JsonBakable] static Gradient[] ag = JsonUtility.FromJson<Chameleon.JustWrapper<UnityEngine.Gradient[]> >("{\"obj\":[{\"serializedVersion\":\"2\",\"key0\":{\"r\":0.12454414367675781,\"g\":0.0,\"b\":1.0,\"a\":1.0},\"key1\":{\"r\":1.0,\"g\":1.0,\"b\":1.0,\"a\":1.0},\"key2\":{\"r\":0.0,\"g\":0.0,\"b\":0.0,\"a\":0.0},\"key3\":{\"r\":0.0,\"g\":0.0,\"b\":0.0,\"a\":0.0},\"key4\":{\"r\":0.0,\"g\":0.0,\"b\":0.0,\"a\":0.0},\"key5\":{\"r\":0.0,\"g\":0.0,\"b\":0.0,\"a\":0.0},\"key6\":{\"r\":0.0,\"g\":0.0,\"b\":0.0,\"a\":0.0},\"key7\":{\"r\":0.0,\"g\":0.0,\"b\":0.0,\"a\":0.0},\"ctime0\":0,\"ctime1\":65535,\"ctime2\":0,\"ctime3\":0,\"ctime4\":0,\"ctime5\":0,\"ctime6\":0,\"ctime7\":0,\"atime0\":0,\"atime1\":65535,\"atime2\":0,\"atime3\":0,\"atime4\":0,\"atime5\":0,\"atime6\":0,\"atime7\":0,\"m_Mode\":0,\"m_NumColorKeys\":2,\"m_NumAlphaKeys\":2},{\"serializedVersion\":\"2\",\"key0\":{\"r\":1.0,\"g\":0.0,\"b\":0.0,\"a\":1.0},\"key1\":{\"r\":1.0,\"g\":1.0,\"b\":1.0,\"a\":1.0},\"key2\":{\"r\":0.0,\"g\":0.0,\"b\":0.0,\"a\":0.0},\"key3\":{\"r\":0.0,\"g\":0.0,\"b\":0.0,\"a\":0.0},\"key4\":{\"r\":0.0,\"g\":0.0,\"b\":0.0,\"a\":0.0},\"key5\":{\"r\":0.0,\"g\":0.0,\"b\":0.0,\"a\":0.0},\"key6\":{\"r\":0.0,\"g\":0.0,\"b\":0.0,\"a\":0.0},\"key7\":{\"r\":0.0,\"g\":0.0,\"b\":0.0,\"a\":0.0},\"ctime0\":0,\"ctime1\":65535,\"ctime2\":0,\"ctime3\":0,\"ctime4\":0,\"ctime5\":0,\"ctime6\":0,\"ctime7\":0,\"atime0\":0,\"atime1\":65535,\"atime2\":0,\"atime3\":0,\"atime4\":0,\"atime5\":0,\"atime6\":0,\"atime7\":0,\"m_Mode\":0,\"m_NumColorKeys\":2,\"m_NumAlphaKeys\":2}]}").obj;
	[JsonBakable] public Gradient gp{get;set;} = JsonUtility.FromJson<Chameleon.JustWrapper<UnityEngine.Gradient> >("{\"obj\":{\"serializedVersion\":\"2\",\"key0\":{\"r\":1.0,\"g\":0.0,\"b\":0.7741265296936035,\"a\":1.0},\"key1\":{\"r\":1.0,\"g\":1.0,\"b\":1.0,\"a\":1.0},\"key2\":{\"r\":0.0,\"g\":0.0,\"b\":0.0,\"a\":0.0},\"key3\":{\"r\":0.0,\"g\":0.0,\"b\":0.0,\"a\":0.0},\"key4\":{\"r\":0.0,\"g\":0.0,\"b\":0.0,\"a\":0.0},\"key5\":{\"r\":0.0,\"g\":0.0,\"b\":0.0,\"a\":0.0},\"key6\":{\"r\":0.0,\"g\":0.0,\"b\":0.0,\"a\":0.0},\"key7\":{\"r\":0.0,\"g\":0.0,\"b\":0.0,\"a\":0.0},\"ctime0\":0,\"ctime1\":65535,\"ctime2\":0,\"ctime3\":0,\"ctime4\":0,\"ctime5\":0,\"ctime6\":0,\"ctime7\":0,\"atime0\":0,\"atime1\":65535,\"atime2\":0,\"atime3\":0,\"atime4\":0,\"atime5\":0,\"atime6\":0,\"atime7\":0,\"m_Mode\":0,\"m_NumColorKeys\":2,\"m_NumAlphaKeys\":2}}").obj;
	[HideInInspector] public List<int> ai;
	[Bakable] public int pi{get; private set; } = 72;
	[Bakable] public float pj{get;set; } = 3.3f;
	[Bakable] float f = 1.91f;
	[Bakable] int[] ai2 = {-39,54,-24,};
	[JsonBakable] float[] Jaf;
	[Bakable] public float Af{get; private set;} = 2.23f;
	[JsonBakable] static GameObject go;
	[Bakable] Vector3 v2;
	[Bakable] public Vector3 pv{get; private set; } = new Vector3(0.6f,-0.77f,0f);
	[Bakable] Color c2 = new Color(0.7735849f,0.4269313f,0.4269313f,1f);
	#pragma warning restore 0414
}

[CustomEditor(typeof(TestJsonBake))]
class TestJsonBakeEditor : MonoBehaviourBakerEditor{
	private TestJsonBake targetAs;
	UnityEditorInternal.ReorderableList r;
	protected override void OnEnable(){
		base.OnEnable();
		targetAs = (TestJsonBake)target;
		r = new UnityEditorInternal.ReorderableList(
			targetAs.ai,typeof(int),true,true,true,true);
		//r.drawElementCallback = drawElement;
	}
	public override void OnInspectorGUI() {
		base.OnInspectorGUI();
		if(GUILayout.Button("Click"))
			Debug.Log(JsonUtility.ToJson((TestJsonBake)target,true));
		r.DoLayoutList();
		targetAs.ai = (List<int>)r.list;
		EditorGUILayout.GradientField("Grad",new Gradient());
	}
}
