Shader "Custom/SolidColor" {
	Properties {
		_Color ("Color", Color) = (1,1,1,1)
		_MainTex ("Albedo (RGB)", 2D) = "white" {}
		_Glossiness ("Smoothness", Range(0,1)) = 0.5
		_Metallic ("Metallic", Range(0,1)) = 0.0
	}
	SubShader {
			Pass{
			Tags{ "Queue" = "Transparent" }
			ZWrite On ZTest Always Blend OneMinusDstColor One

			CGPROGRAM
#pragma vertex vert
#pragma fragment frag
#include "UnityCG.cginc"

			fixed4 _Color;
		sampler2D _CameraDepthTexture;

		struct v2f {
			float4 vertex : POSITION;
			float4 projPos : TEXCOORD0;
		};

		v2f vert(float4 v : POSITION) {
			v2f o;
			o.vertex = mul(UNITY_MATRIX_MVP, v);
			o.projPos = ComputeScreenPos(o.vertex);
			return o;
		}

		fixed4 frag(v2f i) : SV_Target{
			float depthVal = LinearEyeDepth(tex2Dproj(_CameraDepthTexture, UNITY_PROJ_COORD(i.projPos)).r);
		float zPos = i.projPos.z;

		float occlude = step(zPos, depthVal);
		return fixed4(occlude * _Color.rgb * _Color.a, occlude);
		}
			ENDCG
		}
	}
	FallBack "Diffuse"
}


