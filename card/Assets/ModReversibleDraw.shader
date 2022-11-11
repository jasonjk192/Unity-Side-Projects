Shader "Custom/Modified Cutout Double-sided"
{
	Properties
	{
		_Cutoff("Cutoff", Range(0,1)) = 0.5
		_Color("Color", Color) = (1,1,1,1)
		_MainTex("Backface", 2D) = "white" {}
		_MainTex2("Border Face", 2D) = "white"{}
		_BumpTex("Border Bump", 2D) = "bump" {}
		_DesignTex("Design Face", 2D) = "white" {}
		_Glossiness("Smoothness", Range(0,1)) = 0.5
		_Metallic("Metallic", Range(0,1)) = 0.0
	}
	SubShader
	{
		Tags { "Queue" = "AlphaTest" "RenderType" = "TransparentCutout" }
		LOD 200

		Cull Off

		CGPROGRAM

		#pragma surface surf Standard alphatest:_Cutoff addshadow fullforwardshadows
		#pragma target 3.0

		sampler2D _MainTex;
		sampler2D _MainTex2;
		sampler2D _BumpTex;
		sampler2D _DesignTex;

		struct Input
		{
			float2 uv_MainTex;
			float2 uv_BumpTex;
			float3 viewDir;
		};

		half _Glossiness;
		half _Metallic;
		fixed4 _Color;

		float3 rgb2hsv(float3 c)
		{
			float4 K = float4(0.0, -1.0 / 3.0, 2.0 / 3.0, -1.0);
			float4 p = lerp(float4(c.bg, K.wz), float4(c.gb, K.xy), step(c.b, c.g));
			float4 q = lerp(float4(p.xyw, c.r), float4(c.r, p.yzx), step(p.x, c.r));

			float d = q.x - min(q.w, q.y);
			float e = 1.0e-10;
			return float3(abs(q.z + (q.w - q.y) / (6.0 * d + e)), d / (q.x + e), q.x);
		}

		float3 hsv2rgb(float3 c)
		{
			float4 K = float4(1.0, 2.0 / 3.0, 1.0 / 3.0, 3.0);
			float3 p = abs(frac(c.xxx + K.xyz) * 6.0 - K.www);
			return c.z * lerp(K.xxx, clamp(p - K.xxx, 0.0, 1.0), c.y);
		}

		void surf(Input IN, inout SurfaceOutputStandard o)
		{
			fixed4 c = tex2D(_MainTex2, IN.uv_MainTex) * _Color;
			if (c.a != 0)
			{
				float as = pow(saturate(dot(normalize(IN.viewDir), o.Normal)), 2);
				o.Normal = UnpackNormal(tex2D(_BumpTex, IN.uv_BumpTex));
				float rim = pow(saturate(dot(normalize(IN.viewDir), o.Normal)), 2);
				float3 hs = rgb2hsv(c.rgb);
				hs.x = hs.x + as;
				hs = hsv2rgb(hs);
				o.Emission = hs * rim / 2;
				o.Albedo = sin(IN.uv_MainTex.xxx * 25 * IN.viewDir.xyz)*hs / 5 + c.rgb;	
			}
			else
			{
				fixed4 d = tex2D(_DesignTex, 1-(IN.viewDir/10)+IN.uv_MainTex - sin(pow(IN.uv_MainTex.y, IN.viewDir.y+2) * 1000 ) /100);
				fixed4 d2 = tex2D(_DesignTex, (IN.viewDir / 20) + IN.uv_MainTex);
				//o.Albedo = d.rgb;
				//o.Alpha=d.a;
				fixed3 stripe = d + sin(pow(IN.uv_MainTex.y,(IN.viewDir.y+1)/4) * 1000 )/40;
				fixed3 inner = sin(IN.uv_MainTex.xxy * 10 * IN.viewDir.xyz) / 2 + stripe.rgb;
				o.Albedo = inner;
				o.Albedo =inner / 2*(1-d2.rgb)+d2.rgb;
			}
			o.Metallic = _Metallic;
			o.Smoothness = _Glossiness;
			o.Alpha = 1;
		}

		ENDCG

		Cull Front

		CGPROGRAM

		#pragma surface surf Standard alphatest:_Cutoff fullforwardshadows vertex:vert
		#pragma target 3.0

		sampler2D _MainTex;


		struct Input
		{
			float2 uv_MainTex;
		};

		void vert(inout appdata_full v)
		{
			v.normal.xyz = v.normal * -1;
		}

		half _Glossiness;
		half _Metallic;
		fixed4 _Color;


		void surf(Input IN, inout SurfaceOutputStandard o)
		{
			fixed4 c = tex2D(_MainTex, IN.uv_MainTex) * _Color;
			o.Albedo = c.rgb;
			o.Metallic = _Metallic;
			o.Smoothness = _Glossiness;
			o.Alpha = c.a;
		}

		ENDCG
	}
	FallBack "Diffuse"
}