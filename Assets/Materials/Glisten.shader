Shader "chm_Shader/GlistenShader"{
	Properties{
		[HideInInspector] _MainTex("Texture",2D) = "white"{}
		[Toggle] matBGlisten("bGlisten",float) = 0 //Unity does not support bool property
		matGlistenSpeed("Glisten Speed",float) = 0.5
		matGlistenSlope("Glisten Slope",float) = 1
		matGlistenWidth("Glisten Width",float) = 0.05
	}
	SubShader{
		LOD 100
		Tags{"Queue" = "Transparent"}
		Blend SrcAlpha OneMinusSrcAlpha
		ZWrite Off
		Pass{
			Name "Main"

			HLSLPROGRAM
			#pragma vertex vertexShader
			#pragma fragment fragmentShader
			#include "UnityCG.cginc"

			struct VertToFrag{
				float4 clipPos : SV_POSITION;
				float2 uv : TEXCOORD0;
				half4 color : COLOR;
			};

		//CBUFFER_START(UnityPerMaterial)
			sampler2D _MainTex;
			bool matBGlisten; //Unity will convert float to bool itself
			float matGlistenSpeed;
			float matGlistenSlope;
			float matGlistenWidth;
		//CBUFFER_END

			VertToFrag vertexShader(
				float4 objectPos : POSITION,
				float2 uv : TEXCOORD0,
				half4 color : COLOR
			){
				VertToFrag v2f;
				v2f.clipPos = UnityObjectToClipPos(objectPos);
				v2f.uv = uv;
				v2f.color = color;
				return v2f;
			}
			half4 fragmentShader(
				VertToFrag v2f
			) : SV_TARGET
			{
				half4 resultColor = tex2D(_MainTex,v2f.uv) * v2f.color;
				float timeFrac = frac(-_Time.y*matGlistenSpeed);
				if(matBGlisten && 
					v2f.uv.y>matGlistenSlope*v2f.uv.x+timeFrac && 
					v2f.uv.y<matGlistenSlope*v2f.uv.x+timeFrac+matGlistenWidth)
					resultColor *= 3.f;
				return resultColor;
			}
			ENDHLSL
		}
	}
}
