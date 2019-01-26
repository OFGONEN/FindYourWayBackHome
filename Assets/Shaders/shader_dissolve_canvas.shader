Shader "Unlit/shader_dissolve"
{
	Properties
	{
		_MainTex ("Texture", 2D) = "white" {}
		
		_NoiseTex("Noise Texture", 2D) = "white" {}
		_NoiseFreq("Noise Freq", Range(0.0001,1)) = 1
		_NoiseThreshold("Noise Threshold", Range(0 ,1)) = 1

	}
	SubShader
	{
		Tags { "RenderType"="Opaque" }
		LOD 100

		Pass
		{
			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag
			// make fog work
			#pragma multi_compile_fog
			
			#include "UnityCG.cginc"

			struct appdata
			{
				float4 vertex : POSITION;
				float2 uv : TEXCOORD0;
			};

			struct v2f
			{
				float2 uv : TEXCOORD0;
				UNITY_FOG_COORDS(1)
				float4 vertex : SV_POSITION;
			};

			sampler2D _MainTex;
			float4 _MainTex_ST;
			
			sampler2D _NoiseTex;
			float _NoiseFreq, _NoiseThreshold;

			v2f vert (appdata v)
			{
				v2f o;
				o.vertex = UnityObjectToClipPos(v.vertex);
				o.uv = TRANSFORM_TEX(v.uv, _MainTex);
				UNITY_TRANSFER_FOG(o,o.vertex);
				return o;
			}
			
			fixed4 frag (v2f i) : SV_Target
			{
				// sample the texture
				fixed4 col = 0;
				// apply fog
				float noiseVal = tex2D(_NoiseTex, i.uv * _NoiseFreq).r;

				if (noiseVal > _NoiseThreshold)
					discard;


				UNITY_APPLY_FOG(i.fogCoord, col);
				return col;
			}
			ENDCG
		}
	}
}
