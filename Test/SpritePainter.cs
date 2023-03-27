#if UNITY_EDITOR

using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEditor;
using Chameleon;

public class SpritePainter : EditorWindow{
	static Grid activeGrid;
	static Sprite sprite;

	private const int CONTROLID_HINT = 667;

	[MenuItem("SpritePainter/SpritePainter")]
	static void getWindow(){
		EditorWindow.GetWindow<SpritePainter>();
	}
	void OnGUI(){
		EditorGUILayout.Space(10.0f);
		EditorGUI.BeginChangeCheck();
		Grid userGrid = (Grid)EditorGUILayout.ObjectField(
			"Active Grid",
			activeGrid,
			typeof(Grid),
			true
		);
		if(EditorGUI.EndChangeCheck())
			activeGrid = userGrid;
		
		Sprite userSprite = (Sprite)EditorGUILayout.ObjectField(
			"Sprite",
			sprite,
			typeof(Sprite),
			true
		);
		if(GUI.changed)
			sprite = userSprite;
	}
	void OnEnable(){
		SceneView.duringSceneGui += onSceneGUI;
	}
	void OnDisable(){
		SceneView.duringSceneGui -= onSceneGUI;
	}
	void onSceneGUI(SceneView sceneView){
		int thisControlID = GUIUtility.GetControlID(CONTROLID_HINT,FocusType.Passive);
		Event currentEvent = Event.current;
		if(currentEvent.type==EventType.MouseDown &&
			currentEvent.button==0 && //LMB
			!currentEvent.alt && ! currentEvent.control && ! currentEvent.shift &&
			//don't see any better solution, and other Unity classes also do something like this
			activeGrid)
		{
			GUIUtility.hotControl = thisControlID;
			HandleUtility.AddDefaultControl(GUIUtility.GetControlID(FocusType.Passive));
			Vector2 mousePos = currentEvent.mousePosition;
			Plane plane = new Plane(Vector3.back,activeGrid.transform.position);
			float distance;
			Ray mouseRay = sceneView.camera.ScreenPointToRay(mousePos);
			plane.Raycast(
				mouseRay,
				out distance
			);
			Vector3 vHit = mouseRay.GetPoint(distance); //Credit: aldonaletto, UA
			Debug.Log(vHit);
			Vector3 vPos = activeGrid.CellToWorld(activeGrid.WorldToCell(vHit));
			GameObject g = new GameObject();
			Undo.RegisterCreatedObjectUndo(g,"Paint Sprite");
			GameObjectUtility.SetParentAndAlign(g,activeGrid.gameObject);
			g.AddComponent<SpriteRenderer>().sprite = sprite;
			g.transform.position = vPos;

		}
	}
}

#endif
