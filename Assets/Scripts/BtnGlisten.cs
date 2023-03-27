using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using Chameleon;

[RequireComponent(typeof(Image))]
public class BtnGlisten : MonoBehaviour,
	IPointerEnterHandler,IPointerExitHandler
{
	[SerializeField] Material matGlisten;
	[SerializeField] Material matNonGlisten;
	[SerializeField][Preview][NoRange] AudioData audioDataSfxHover;
	protected Image image;

	protected virtual void Awake(){
		image = GetComponent<Image>();
	}
	protected virtual void OnEnable(){
		/* Do it OnEnable otherwise when button shows up the second time (Pause Menu)
		this will not be called. */
		image.material = matNonGlisten;
	}
	public virtual void OnPointerEnter(PointerEventData eventData){
		image.material = matGlisten;
		AudioPlayer.Instance.playSfx(audioDataSfxHover);
	}
	public virtual void OnPointerExit(PointerEventData eventData){
		image.material = matNonGlisten;
	}
}
