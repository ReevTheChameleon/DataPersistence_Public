using UnityEngine;
using Chameleon;

public class LookAtPaddle : MonoBehaviour{
	[Bakable] const float EYE_DISTANCE_RATIO = 0.03f;
	[SerializeField] Transform tPaddle;

	void Update(){
		//This assume center is 0.0f. If not the case will need to revise code
		transform.position = transform.position.newX(
			tPaddle.position.x*EYE_DISTANCE_RATIO
		);
	}
}

#if UNITY_EDITOR
[UnityEditor.CanEditMultipleObjects]
[UnityEditor.CustomEditor(typeof(LookAtPaddle))]
class LookAtBallEditor : MonoBehaviourBakerEditor{ }
#endif
