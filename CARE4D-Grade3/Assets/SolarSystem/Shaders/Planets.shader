Shader "SolarSystem/Planet" {
	Properties {
		_MainTex("Texture (RGB)", 2D) = "black" {}
		_Color("Color", Color) = (0, 0, 0, 1)
		_AtmoColor("Atmosphere Color", Color) = (0.5, 0.5, 1.0, 1)
		_Falloff("Falloff", Float) = 5
		_Transparency("Atmosphere Transparency", Float) = 1
	}
	
	SubShader{
		Tags { "RenderType" = "Opaque" }
		CGPROGRAM
		#pragma surface surf Planet
		
		sampler2D _MainTex;
		float4 _Color;
		float4 _AtmoColor;
        float _Falloff;
        float _Transparency;
		
		struct Input{
			float2 uv_MainTex;
			float3 viewDir;
		};
		
		void surf (Input IN, inout SurfaceOutput o){
			o.Albedo = tex2D (_MainTex, IN.uv_MainTex).rgb;
		}
		
		inline float4 LightingPlanet (SurfaceOutput s, float3 lightDir, float3 viewDir, fixed atten){
			float difLight = dot (s.Normal, lightDir);
			float hLambert = max (0, difLight * 0.85 + 0.15);
			
			float atmo;
            atmo = pow (1.0 - saturate (dot (viewDir, s.Normal)), _Falloff);
            atmo *= _Transparency;
            
			float4 col;
			col.rgb = s.Albedo;
			col.rgb = lerp (col.rgb, _AtmoColor.rgb, atmo) * _Color;
			col.rgb *= _LightColor0.rgb * (hLambert * atten * 2);
			
			col.a = s.Alpha;
			return col;
		}
		
		ENDCG
		
	}
	
	FallBack "Diffuse"
}