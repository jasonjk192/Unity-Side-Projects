Shader "Custom/NewSurfaceShader"
{
    Properties
    {
        _Color ("Back Color", Color) = (1,1,1,1)
        _MainTex ("Background", 2D) = "white" {}
		_DesignTex("Design", 2D) = "white" {}
		_BumpTex ("Bump Map", 2D) = "bump" {}
    }
    SubShader
    {
        Tags { "RenderType"="Opaque" }
        LOD 200
        CGPROGRAM
        #pragma surface surf Standard fullforwardshadows

        #pragma target 3.0

        sampler2D _MainTex;
		sampler2D _DesignTex;
		sampler2D _BumpTex;

        struct Input
        {
            float2 uv_MainTex;
			float2 uv_BumpTex;
			float3 viewDir;
        };

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


        void surf (Input IN, inout SurfaceOutputStandard o)
        {
			fixed4 c = tex2D(_MainTex, IN.uv_MainTex) * _Color;
			if (c.a != 0)
			{
				float as = pow(saturate(dot(normalize(IN.viewDir), o.Normal)), 2);
				o.Normal = UnpackNormal(tex2D(_BumpTex, IN.uv_BumpTex));
				float rim = pow(saturate(dot(normalize(IN.viewDir), o.Normal)), 2);
				float3 hs = rgb2hsv(c.rgb);
				hs.x = hs.x + as;
				hs = hsv2rgb(hs);
				//o.Albedo = d.a!=0?d.rgb:hs;
				o.Emission = hs * rim / 2;
				o.Albedo = sin(IN.uv_MainTex.xxx * 25 * IN.viewDir.xyz)*hs / 5 + c.rgb;
				o.Alpha = c.a;
			}
			else
			{
				fixed4 d = tex2D(_DesignTex, 1-(IN.viewDir/10)+IN.uv_MainTex - sin(pow(IN.uv_MainTex.y, IN.viewDir.y+1) * 1000 ) /100);
				fixed4 d2 = tex2D(_DesignTex, (IN.viewDir / 20) + IN.uv_MainTex);
				//o.Albedo = d;
				fixed3 stripe = d + sin(pow(IN.uv_MainTex.y,(IN.viewDir.y+1)/4) * 1000 )/40;
				fixed3 inner = sin(IN.uv_MainTex.xxy * 10 * IN.viewDir.xyz) / 2 + stripe.rgb;
				//o.Albedo = inner;
				o.Albedo =inner / 2*(1-d2.rgb)+d2.rgb;
			}
        }
        ENDCG
    }
    FallBack "Diffuse"
}
