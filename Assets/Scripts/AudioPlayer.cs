using UnityEngine;
using Chameleon;

public class AudioPlayer : LoneMonoBehaviour<AudioPlayer>{
	[SerializeField] AudioSource audioSourceSfx;
	[SerializeField] AudioSource audioSourceBgm;

	public AudioClip audioClipBgm{get{return audioSourceBgm.clip;} }

	public void playSfx(AudioClip audioClip,float volume){
		audioSourceSfx.PlayOneShot(audioClip,volume);
	}
	public void playSfx(AudioData audioClipData){
		audioSourceSfx.playOneShot(audioClipData);
	}
	public void playBgm(AudioData audioClipData){
		//audioSourceBgm.loop = true; //set at inspector
		audioSourceBgm.setClip(audioClipData);
		audioSourceBgm.Play();
	}
	public void pauseBgm(){
		audioSourceBgm.Pause();
	}
	public void stopBgm(){
		audioSourceBgm.Stop();
	}
}
