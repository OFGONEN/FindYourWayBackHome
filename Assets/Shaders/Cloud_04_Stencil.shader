Shader "Custom/Cloud_04" {
	Properties {
		_Color ("Color", Color) = (1,1,1,1)
		_MainTex ("Albedo (RGB)", 2D) = "white" {}

		_NoiseTex1("Noise Tex", 2D) = "white" {}
		_NoiseFreq1("Noise Freq", Range(0,1)) = 0.0
		_NoiseMult1("Noise Mult", Range(0,10)) = 0.0
		_NoiseColor1("Noise color", Color) = (1,1,1,1)
		_Speed1("Speed", Range(0,10)) = 0.0


		_NoiseTex("Noise Tex", 2D) = "white" {}
		_NoiseFreq("Noise Freq", Range(0,1)) = 0.0
		_NoiseMult("Noise Mult", Range(0,10)) = 0.0
		_NoiseColor("Noise color", Color) = (1,1,1,1)
		_Speed("Speed", Range(0,10)) = 0.0

		_RimColor ("Rim color", Color) = (1,1,1,1)
		_RimMult("Rim Mult", Range(0,10)) = 0.0
	}
	SubShader {
		Tags { "RenderType"="Opaque" }
		LOD 200

			Stencil
		{
		 Ref 1
		 Comp Equal
		 Pass Replace
		}

		CGPROGRAM

		// Physically based Standard lighting model, and enable shadows on all light types
		#pragma surface surf NoLighting fullforwardshadows vertex:vert noambient 

		// Use shader model 3.0 target, to get nicer looking lighting
		#pragma target 4.0

		sampler2D _MainTex,_NoiseTex,_NoiseTex1;
		float4 _RimColor;
		float _NoiseFreq, _NoiseMult, _Speed, _RimMult;
		float _NoiseFreq1, _NoiseMult1, _Speed1, _RimMult1;

		struct Input {
			float2 uv_MainTex;
			float2 uv_NoiseTex;
			float3 viewDir;
			float3 worldNormal;
		};

		fixed4 LightingNoLighting(SurfaceOutput s, fixed3 lightDir, fixed atten)
		{
			fixed4 c;
			c.rgb = s.Albedo;

			c.a = s.Alpha;
			return c;
		}


		void vert(inout appdata_full v) {
			float noise = tex2Dlod(_NoiseTex1, float4(v.vertex.xz * _NoiseFreq1,0,0) + _Time.x * _Speed1) * _NoiseMult1;
			v.vertex.xyz += v.normal * noise * (sin(v.vertex.x * v.vertex.z+_Time.x*15)+1)/2;
			//v.vertex.xy += normalize(float2(sin(noise * 3.14*2 +_Time.x*10), cos(noise * 3.14 * 2 + _Time.x*10)))/10;
			
		}


		fixed4 _Color, _NoiseColor;

		// Add instancing support for this shader. You need to check 'Enable Instancing' on materials that use the shader.
		// See https://docs.unity3d.com/Manual/GPUInstancing.html for more information about instancing.
		// #pragma instancing_options assumeuniformscaling
		UNITY_INSTANCING_BUFFER_START(Props)
			// put more per-instance properties here
		UNITY_INSTANCING_BUFFER_END(Props)

		void surf (Input IN, inout SurfaceOutput o) {
			// Albedo comes from a texture tinted by color

			
			

			float noise = tex2D(_NoiseTex, (IN.uv_NoiseTex * _NoiseFreq + _Time.x * _Speed) % 1).r;
			float dotProduct = saturate(1 - dot(IN.worldNormal, IN.viewDir));
			


			fixed4 c = tex2D (_MainTex, IN.uv_MainTex) * _Color;
	
				
			if (dotProduct < 0.7 && dotProduct > 0.5 )
				c.rgb = (pow(dotProduct, _RimMult) * _RimColor + c.rgb * 6) / 7;
			
		

				c.rgb += (noise - 0.5)  * _NoiseMult * _NoiseColor;
				o.Emission = c.rgb * 5;
			o.Albedo = c;
			o.Alpha = c.a;
		}
		ENDCG
	}
	FallBack "Diffuse"
}
