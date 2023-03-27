using UnityEngine;
using Chameleon;
using System.Collections;

[RequireComponent(typeof(ParticleSystem))]
public class Firework : MonoBehaviour{
	[JsonBakable] Gradient[] aColor = JsonUtility.FromJson<Chameleon.JustWrapper<UnityEngine.Gradient[]> >("{\"obj\":[{\"serializedVersion\":\"2\",\"key0\":{\"r\":1.0,\"g\":0.9258981943130493,\"b\":0.0,\"a\":1.0},\"key1\":{\"r\":1.0,\"g\":0.029678378254175187,\"b\":0.0,\"a\":1.0},\"key2\":{\"r\":0.4811320900917053,\"g\":0.0,\"b\":0.0,\"a\":0.0},\"key3\":{\"r\":1.0,\"g\":1.0,\"b\":1.0,\"a\":0.0},\"key4\":{\"r\":0.0,\"g\":0.0,\"b\":0.0,\"a\":0.0},\"key5\":{\"r\":0.0,\"g\":0.0,\"b\":0.0,\"a\":0.0},\"key6\":{\"r\":0.0,\"g\":0.0,\"b\":0.0,\"a\":0.0},\"key7\":{\"r\":0.0,\"g\":0.0,\"b\":0.0,\"a\":0.0},\"ctime0\":0,\"ctime1\":38165,\"ctime2\":65535,\"ctime3\":65535,\"ctime4\":0,\"ctime5\":0,\"ctime6\":0,\"ctime7\":0,\"atime0\":0,\"atime1\":38165,\"atime2\":65535,\"atime3\":0,\"atime4\":0,\"atime5\":0,\"atime6\":0,\"atime7\":0,\"m_Mode\":0,\"m_NumColorKeys\":3,\"m_NumAlphaKeys\":3},{\"serializedVersion\":\"2\",\"key0\":{\"r\":0.0,\"g\":0.3255159854888916,\"b\":1.0,\"a\":1.0},\"key1\":{\"r\":1.0,\"g\":0.7612816095352173,\"b\":0.003921568393707275,\"a\":1.0},\"key2\":{\"r\":0.5849056243896484,\"g\":0.030504988506436349,\"b\":0.019312933087348939,\"a\":0.0},\"key3\":{\"r\":0.0,\"g\":0.0,\"b\":0.0,\"a\":0.0},\"key4\":{\"r\":0.0,\"g\":0.0,\"b\":0.0,\"a\":0.0},\"key5\":{\"r\":0.0,\"g\":0.0,\"b\":0.0,\"a\":0.0},\"key6\":{\"r\":0.0,\"g\":0.0,\"b\":0.0,\"a\":0.0},\"key7\":{\"r\":0.0,\"g\":0.0,\"b\":0.0,\"a\":0.0},\"ctime0\":0,\"ctime1\":37779,\"ctime2\":65535,\"ctime3\":0,\"ctime4\":0,\"ctime5\":0,\"ctime6\":0,\"ctime7\":0,\"atime0\":0,\"atime1\":34502,\"atime2\":65535,\"atime3\":0,\"atime4\":0,\"atime5\":0,\"atime6\":0,\"atime7\":0,\"m_Mode\":0,\"m_NumColorKeys\":3,\"m_NumAlphaKeys\":3},{\"serializedVersion\":\"2\",\"key0\":{\"r\":0.0,\"g\":1.0,\"b\":0.5674073696136475,\"a\":1.0},\"key1\":{\"r\":1.0,\"g\":0.7728071808815002,\"b\":0.003921568393707275,\"a\":1.0},\"key2\":{\"r\":0.5849056243896484,\"g\":0.030504988506436349,\"b\":0.019312933087348939,\"a\":0.0},\"key3\":{\"r\":0.5849056243896484,\"g\":0.030504988506436349,\"b\":0.019312933087348939,\"a\":0.0},\"key4\":{\"r\":0.0,\"g\":0.0,\"b\":0.0,\"a\":0.0},\"key5\":{\"r\":0.0,\"g\":0.0,\"b\":0.0,\"a\":0.0},\"key6\":{\"r\":0.0,\"g\":0.0,\"b\":0.0,\"a\":0.0},\"key7\":{\"r\":0.0,\"g\":0.0,\"b\":0.0,\"a\":0.0},\"ctime0\":0,\"ctime1\":37779,\"ctime2\":65535,\"ctime3\":65535,\"ctime4\":0,\"ctime5\":0,\"ctime6\":0,\"ctime7\":0,\"atime0\":0,\"atime1\":38936,\"atime2\":65535,\"atime3\":0,\"atime4\":0,\"atime5\":0,\"atime6\":0,\"atime7\":0,\"m_Mode\":0,\"m_NumColorKeys\":3,\"m_NumAlphaKeys\":3}]}").obj;
	ParticleSystem ps;

	void Awake(){
		ps = GetComponent<ParticleSystem>();
	}
	void OnEnable(){
		ParticleSystem.ColorOverLifetimeModule colorOverLifetime =
			ps.colorOverLifetime;
		colorOverLifetime.color = aColor[Random.Range(0,aColor.Length)];
		ps.Play();
		this.delayCall(
			()=>{gameObject.SetActive(false);},
			ps.main.startLifetime.constantMax
		);
	}
	void OnDisable(){
		ps.Stop();
	}
}

#if UNITY_EDITOR
[UnityEditor.CustomEditor(typeof(Firework))]
class FireworkEditor : MonoBehaviourBakerEditor{ }
#endif
