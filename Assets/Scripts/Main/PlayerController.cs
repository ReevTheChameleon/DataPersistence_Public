using UnityEngine;
using UnityEngine.InputSystem;
using Chameleon;
using System.Collections;

using DInputActionCallback = System.Action<UnityEngine.InputSystem.InputAction.CallbackContext>;

[RequireComponent(typeof(PlayerInput))]
public class PlayerController : LoneMonoBehaviour<PlayerController>{
	PlayerInput playerInput;
	[SerializeField] InputActionID actionIDHorizontalKeyboard;
	[SerializeField] InputActionID actionIDHorizontalMouse;
	[SerializeField] InputActionID actionIDBallColorRed;
	[SerializeField] InputActionID actionIDBallColorGreen;
	[SerializeField] InputActionID actionIDBallColorBlue;
	[SerializeField] InputActionID actionIDBallColorYellow;
	[SerializeField] InputActionID actionIDPause;

	[SerializeField] Transform tPaddle;
	[Bakable] float keyboardSpeed = 5f;
	[ShowAxis(eAxis.x)][Bakable] float halfRange = 3.300775f;

	private LoneCoroutine routineMove = new LoneCoroutine();
	private DInputActionCallback[] adSetBallColor;
	private DInputActionCallback dMoveHorizontalKeyboard;
	private DInputActionCallback dMoveHorizontalMouse;

	protected override void Awake(){
		base.Awake();
		playerInput = GetComponent<PlayerInput>();
		//To unsubscribe lambda, you need to save it somewhere (Credit: Jon Skeet, SO)
		adSetBallColor = new DInputActionCallback[]{
			(context)=>{onInputSetBallColor(eBrickColor.RED);},
			(context)=>{onInputSetBallColor(eBrickColor.GREEN);},
			(context)=>{onInputSetBallColor(eBrickColor.BLUE);},
			(context)=>{onInputSetBallColor(eBrickColor.YELLOW);}
		};
		dMoveHorizontalKeyboard = new DInputActionCallback(
			(context)=>{onInputMoveHorizontal(context,false);}
		);
		dMoveHorizontalMouse = new DInputActionCallback(
			(context)=>{onInputMoveHorizontal(context,true);}
		);
	}
	void OnEnable(){
		playerInput.actions[actionIDHorizontalKeyboard.Id].performed += dMoveHorizontalKeyboard;
		playerInput.actions[actionIDHorizontalKeyboard.Id].canceled += dMoveHorizontalKeyboard;
		playerInput.actions[actionIDHorizontalMouse.Id].performed += dMoveHorizontalMouse;
		playerInput.actions[actionIDHorizontalMouse.Id].canceled += dMoveHorizontalMouse;
		playerInput.actions[actionIDBallColorRed.Id].performed += adSetBallColor[0];
		playerInput.actions[actionIDBallColorGreen.Id].performed += adSetBallColor[1];
		playerInput.actions[actionIDBallColorBlue.Id].performed += adSetBallColor[2];
		playerInput.actions[actionIDBallColorYellow.Id].performed += adSetBallColor[3];
		playerInput.actions[actionIDPause.Id].performed += onInputPause;
	}
	void OnDisable(){
		playerInput.actions[actionIDHorizontalKeyboard.Id].performed -= dMoveHorizontalKeyboard;
		playerInput.actions[actionIDHorizontalKeyboard.Id].canceled -= dMoveHorizontalKeyboard;
		playerInput.actions[actionIDHorizontalMouse.Id].performed -= dMoveHorizontalMouse;
		playerInput.actions[actionIDHorizontalMouse.Id].canceled -= dMoveHorizontalMouse;
		playerInput.actions[actionIDBallColorRed.Id].performed -= adSetBallColor[0];
		playerInput.actions[actionIDBallColorGreen.Id].performed -= adSetBallColor[1];
		playerInput.actions[actionIDBallColorBlue.Id].performed -= adSetBallColor[2];
		playerInput.actions[actionIDBallColorYellow.Id].performed -= adSetBallColor[3];
		playerInput.actions[actionIDPause.Id].performed -= onInputPause;
	}
	private void onInputMoveHorizontal(InputAction.CallbackContext context,bool bMouse){
		SceneMainManager sceneMainManager = SceneMainManager.Instance;
		if(sceneMainManager && !sceneMainManager.BGameOver && !sceneMainManager.BPaused){
			float inputHorizontal = context.ReadValue<float>();
			if(inputHorizontal == 0.0f) //Hopefully deadzone will help filter this
				routineMove.stop();
			else
				routineMove.start(this,moveHorizontal(inputHorizontal,bMouse));
		}
	}
	IEnumerator moveHorizontal(float inputHorizontal,bool bMouse){
		SceneMainManager sceneMainManager = SceneMainManager.Instance;
		while(!sceneMainManager.BGameOver && !sceneMainManager.BPaused){ //if paused, end the routine
			float x = Mathf.Clamp(
				tPaddle.position.x + inputHorizontal*(
					bMouse ? 
					lengthPerPixel() : 
					keyboardSpeed*Time.deltaTime
				),
				-halfRange,
				halfRange
			);
			tPaddle.setX(x);
			yield return null;
		}
		/* Delta mouse is delta position since last frame, and so has already
		taken Time.deltaTime indirectly into account (Credit: Eric5h5, UA),
		but I also want to scale it according to screen size, which feels
		more natural to me. */
	}
	private float lengthPerPixel(){
		Camera camera = Camera.main;
		return camera.orthographicSize*2 / camera.pixelHeight;
	}
	private void onInputSetBallColor(eBrickColor color){
		/* May check for pause and game over, but just always
		allowing user to change ball color is more fun. */
		SceneMainManager.Instance?.setBallColor(color);
	}
	private void onInputPause(InputAction.CallbackContext context){
		SceneMainManager sceneMainManager = SceneMainManager.Instance;
		if(sceneMainManager && !sceneMainManager.BGameOver){
			if(sceneMainManager.BPaused)
				sceneMainManager.resume();
			else
				sceneMainManager.pause();
		}
	}
}

#if UNITY_EDITOR
[UnityEditor.CustomEditor(typeof(PlayerController))]
class PlayerControllerEditor : MonoBehaviourBakerEditorWithScene{ }
#endif
