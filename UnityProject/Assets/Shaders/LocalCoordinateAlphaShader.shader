Shader "Unlit/LocalCoordinateAlpha"
{
	Properties
	{
		_MainTex("Texture", 2D) = "white" {}
		_Alpha("Alpha", Range(0.0, 1.0)) = 1.0
	}
		SubShader
		{
			Tags { "Queue" = "Transparent" "RenderType" = "Transparent" }

			ZWrite Off
			Lighting Off
			Cull Off
			Blend SrcAlpha OneMinusSrcAlpha

			Pass
			{
				CGPROGRAM
				#pragma vertex vert
				#pragma fragment frag
				#include "UnityCG.cginc"

			struct appdata
			{
				float4 vertex : POSITION;
				float2 texcoord : TEXCOORD0;
			};

			struct v2f
			{
				float4 pos : SV_POSITION;
				float2 uv_MainTex : TEXCOORD0;
			};

			float4 _MainTex_ST;
			
			v2f vert(appdata_base v)
			{
				v2f o;
				o.pos = mul(UNITY_MATRIX_MVP, v.vertex);
				o.uv_MainTex = TRANSFORM_TEX(v.texcoord, _MainTex);
				return o;
			}

			sampler2D _MainTex;
			fixed _Alpha;
			
			half4 frag(v2f i) : COLOR
			{

				half4 c = tex2D(_MainTex, i.uv_MainTex);
				c.a += 0.5h * clamp(_Alpha, 0.h, 1.h) - 0.5h;
				c.a -= sqrt((0.5h - i.uv_MainTex.x) * (0.5h - i.uv_MainTex.x) +
							(0.5h - i.uv_MainTex.y) * (0.5h - i.uv_MainTex.y)) * 0.6h;	
				return c;
			}
			ENDCG
		}
	}
}
