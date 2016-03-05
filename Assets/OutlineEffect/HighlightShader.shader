Shader "Custom/NewSurfaceShader" {
	Properties {
		_Color ("Color", Color) = (1,1,1,1)
		_MainTex ("Albedo (RGB)", 2D) = "white" {}
		_Glossiness ("Smoothness", Range(0,1)) = 0.5
		_Metallic ("Metallic", Range(0,1)) = 0.0
	}
	SubShader {
			Pass{
			CGPROGRAM
#pragma vertex vert_img
#pragma fragment frag
#pragma fragmentoption ARB_precision_hint_fastest
#include "UnityCG.cginc"

			sampler2D _MainTex;
		sampler2D _OccludeMap;

		half4 frag(v2f_img IN) : COLOR{
			return tex2D(_MainTex, IN.uv) - tex2D(_OccludeMap, IN.uv);
		}
			ENDCG
		}
			Pass{
			CGPROGRAM
#pragma vertex vert_img
#pragma fragment frag
#pragma fragmentoption ARB_precision_hint_fastest
#include "UnityCG.cginc"

			sampler2D _MainTex;
		sampler2D _OccludeMap;

		half4 frag(v2f_img IN) : COLOR{
			return tex2D(_MainTex, IN.uv) + tex2D(_OccludeMap, IN.uv);
		}
			ENDCG
		}

	}
	FallBack "Diffuse"
}
