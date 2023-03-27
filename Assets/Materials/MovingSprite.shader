Shader "chm_Shader/MovingSprite"{
	Properties{
		[MainTexture] matTexture("Texture",2D) = "white"{}
		[MainColor] matTint("Tint",Color) = (1,1,1,1)
		[MatVector2] matSpeed("Speed",Vector) = (0,0,0,0)
		_StencilComp ("Stencil Comparison", Float) = 8
		_Stencil ("Stencil ID", Float) = 0
		_StencilOp ("Stencil Operation", Float) = 0
		_StencilWriteMask ("Stencil Write Mask", Float) = 255
		_StencilReadMask ("Stencil Read Mask", Float) = 255
		_ColorMask ("Color Mask", Float) = 0
	}
	SubShader{
		LOD 100
		Tags{"Queue"="Transparent"}
		ZWrite Off
		Blend SrcAlpha OneMinusSrcAlpha
		
		/* For UI Mask Component */
		Stencil{
			Ref [_Stencil]
			Comp [_StencilComp]
			Pass [_StencilOp] 
			ReadMask [_StencilReadMask]
			WriteMask [_StencilWriteMask]
		}
		ColorMask [_ColorMask]

		Pass{
			Name "Main"
			
			HLSLPROGRAM
			#pragma vertex vertexShader
			#pragma fragment fragmentShader
			#include "UnityCG.cginc"
			//for Universal Render Pipelines
			//#include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/Lighting.hlsl"

			struct VertToFrag{
				float4 clipPos : SV_POSITION;
				float2 uv : TEXCOORD0;
			};

			sampler2D matTexture;
			float4 matTexture_ST;
			half4 matTint;
			float2 matSpeed;


			VertToFrag vertexShader(
				float4 objectPos : POSITION,
				float2 uv : TEXCOORD0
			){
				VertToFrag v2f;
				v2f.clipPos = UnityObjectToClipPos(objectPos);
				//For Universal Render Pipelines
				//float3 worldPos = TransformObjectToWorld(objectPos.xyz);
				//v2f.clipPos = TransformWorldToHClip(worldPos);
				v2f.uv = uv*matTexture_ST.xy + matTexture_ST.zw + _Time.y*matSpeed;
				return v2f;
			}
			half4 fragmentShader(
				VertToFrag v2f
			) : SV_TARGET
			{
				return tex2D(matTexture,v2f.uv) * matTint;
			}
			ENDHLSL
		}
	}
}
