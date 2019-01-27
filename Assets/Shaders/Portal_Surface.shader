Shader "Custom/Portal_Surface" {
	Properties {
		_Color ("Color", Color) = (1,1,1,1)
		_MainTex ("Albedo (RGB)", 2D) = "white" {}
		_Glossiness ("Smoothness", Range(0,1)) = 0.5
		_Metallic ("Metallic", Range(0,1)) = 0.0

		_NoiseTex("Noise Tex", 2D) = "white" {}
		_NoiseFreq("Noise Freq", Range(0,100)) = 0.5
		_NoiseMult("Noise Mult", Range(0,1)) = 0.5
		_NoiseTime("Noise Time", Range(0,100)) = 1
		_NoiseSlider ("Noise Slider", Range(0,1)) = 1
	}
	SubShader {
		Tags { "RenderType" = "Opaque"
				"Queue" = "Geometry-10"
			}
		LOD 200

		Colormask 0
		ZWrite off
		Cull off
			Stencil
		{
		 Ref 1
		 Comp always
		 Pass replace
		}


		CGPROGRAM
		// Physically based Standard lighting model, and enable shadows on all light types
		#pragma surface surf Standard fullforwardshadows

		// Use shader model 3.0 target, to get nicer looking lighting
		#pragma target 3.0

		sampler2D _MainTex, _NoiseTex;
		float _NoiseFreq, _NoiseMult, _NoiseTime, _NoiseSlider;

		struct Input {
			float2 uv_MainTex;
			float2 uv_NoiseTex;
			float3 viewDir;
			float3 worldNormal;
		};

		half _Glossiness;
		half _Metallic;
		fixed4 _Color;

		// Add instancing support for this shader. You need to check 'Enable Instancing' on materials that use the shader.
		// See https://docs.unity3d.com/Manual/GPUInstancing.html for more information about instancing.
		// #pragma instancing_options assumeuniformscaling
		UNITY_INSTANCING_BUFFER_START(Props)
			// put more per-instance properties here
		UNITY_INSTANCING_BUFFER_END(Props)

		void surf (Input IN, inout SurfaceOutputStandard o) {
			// Albedo comes from a texture tinted by color
			fixed4 c = tex2D (_MainTex, IN.uv_MainTex) * _Color;
			o.Albedo = c.rgb;

			float i = dot(IN.viewDir, IN.worldNormal);
			float noiseVal = tex2D(_NoiseTex, float2(IN.uv_NoiseTex.x + _Time.x * _NoiseTime, IN.uv_NoiseTex.y + _Time.x * _NoiseTime) * _NoiseFreq).r * _NoiseMult;

			if (i + noiseVal < _NoiseSlider && i + noiseVal > 0)
			 discard;


			// Metallic and smoothness come from slider variables
			o.Metallic = _Metallic;
			o.Smoothness = _Glossiness;
			o.Alpha = c.a;
		}
		ENDCG
	}
	FallBack "Diffuse"
}
