﻿Shader "Hidden/NewImageEffectShader"
{
	Properties
	{
		_MainTex ("Texture", 2D) = "white" {}
		_NoiseTex("Noise Texture", 2D) = "white" {}
		_NoiseFreq ("Noise Freq", Range(0.0001,1)) = 1
		_NoiseThreshold("Noise Threshold", Range(0 ,1)) = 1

	}
	SubShader
	{
		// No culling or depth
		Cull Off ZWrite Off ZTest Always

		Pass
		{
			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag
			
			#include "UnityCG.cginc"

			struct appdata
			{
				float4 vertex : POSITION;
				float2 uv : TEXCOORD0;
			};

			struct v2f
			{
				float2 uv : TEXCOORD0;
				float4 vertex : SV_POSITION;
			};

			v2f vert (appdata v)
			{
				v2f o;
				o.vertex = UnityObjectToClipPos(v.vertex);
				o.uv = v.uv;
				return o;
			}
			
			sampler2D _MainTex, _NoiseTex;
			float _NoiseFreq, _NoiseThreshold;

			fixed4 frag (v2f i) : SV_Target
			{
				fixed4 col = tex2D(_MainTex, i.uv);
				float noiseVal = tex2D(_NoiseTex, i.uv * _NoiseFreq).r;

				if (noiseVal < _NoiseThreshold)
					col = (0, 0, 0, 0);


				return col;
			}
			ENDCG
		}
	}
}
