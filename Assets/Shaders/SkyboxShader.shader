// Upgrade NOTE: replaced '_Object2World' with 'unity_ObjectToWorld'

// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

Shader "Cg shader for Unity-specific skybox" {
	Properties{
	   _Cube("Environment Map", Cube) = "white" {}
		
		_NoiseTex ("Noise Tex", 2D) = "white" {}
		_NoiseSpeed("Noise Speed", Range(0,10)) = 1
		_NoiseMult("Noise Mult", Range(0,10)) = 1
		_NoiseFreq("Noise Freq", Range(0.00001,0.001)) = 1
		_PixelOffset("Pixel Offset", Range(0,1)) = 1
		_ChromaticRange("Chromatic Slider", Range(0,1)) = 0
		_EmissionVal ("Emission", Vector) = (0,0,0,0)

	}


		SubShader{
		   Tags { "Queue" = "Background"  }

			
		   Pass {
			  ZWrite Off
			  Cull Off

			  CGPROGRAM
			  #pragma vertex vert
			  #pragma fragment frag
			  #include "noiseSimplex.cginc"


		// User-specified uniforms
		samplerCUBE _Cube;
		sampler2D _NoiseTex;
		float4 _EmissionVal;
		float _NoiseFreq, _NoiseMult, _NoiseSpeed, _PixelOffset, _ChromaticRange;
		struct vertexInput {
		   float4 vertex : POSITION;
		   float3 texcoord : TEXCOORD0;
		   float2 uvNoise : TEXCOORD1;
		   
		};

		struct vertexOutput {
		   float4 vertex : SV_POSITION;
		   float3 texcoord : TEXCOORD0;
		   float2 uvNoise : TEXCOORD1;
		   float3 worldPos : TEXCOORD2;
		};

		vertexOutput vert(vertexInput input)
		{
		   vertexOutput output;
		   output.vertex = UnityObjectToClipPos(input.vertex);
		   output.texcoord = input.texcoord;
		   output.uvNoise = input.uvNoise;

		   output.worldPos = mul(unity_ObjectToWorld, input.vertex).xyz;
		   return output;
		}

		fixed4 frag(vertexOutput input) : COLOR
		{ 
				float noiseVal = _NoiseMult * snoise(input.worldPos.xyz * _NoiseFreq + _Time.x * _NoiseSpeed);
				float3 noiseToDirection = float3(cos(noiseVal*3.14 * 2), sin(noiseVal*3.14 * 2), cos(noiseVal*3.14 * 2+ 5));

				float colorR = texCUBE(_Cube, input.texcoord + normalize(noiseToDirection) * _PixelOffset + float3(_ChromaticRange / 2, 0, _ChromaticRange / 2)).r * _EmissionVal.r;
				float colorG = texCUBE(_Cube, input.texcoord + normalize(noiseToDirection) * _PixelOffset + float3( 0, _ChromaticRange / 2 ,_ChromaticRange / 2)).g * _EmissionVal.g;
				float colorB = texCUBE(_Cube, input.texcoord + normalize(noiseToDirection) * _PixelOffset + float3(-_ChromaticRange/2, -_ChromaticRange / 2,0)).b * _EmissionVal.b;

				


				return float4(colorR, colorG,colorB,1);
		}
		ENDCG
	 }
	}
}
