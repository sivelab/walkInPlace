Shader "Ramp/Diff Illum Detail"
{
	Properties 
	{
_Color("_Color", Color) = (1,1,1,1)
_MainTex("_MainTex", 2D) = "black" {}
_Illum("_Illum", 2D) = "black" {}
_Emission("_Emission", Range(0,1) ) = 1
_Ramp("Ramp Cubemap", Cube) = "black" {}
_Detail("_Detail", 2D) = "black" {}
_Offset("_Offset", Float) = 0.05

	}
	
	SubShader 
	{
		Tags
		{
"Queue"="Geometry"
"IgnoreProjector"="False"
"RenderType"="Opaque"

		}

		
Cull Back
ZWrite On
ZTest LEqual
ColorMask RGBA
LOD 100
Blend SrcAlpha OneMinusSrcAlpha
Fog{
}


		CGPROGRAM
#pragma surface surf BlinnPhongEditor  vertex:vert
#pragma target 2.0


float4 _Color;
sampler2D _MainTex;
sampler2D _Illum;
float _Emission;
samplerCUBE _Ramp;
sampler2D _Detail;
float _Offset;

			struct EditorSurfaceOutput {
				half3 Albedo;
				half3 Normal;
				half3 Emission;
				half3 Gloss;
				half Specular;
				half Alpha;
				half4 Custom;
			};
			
			inline half4 LightingBlinnPhongEditor_PrePass (EditorSurfaceOutput s, half4 light)
			{
				half3 spec = light.a * s.Gloss;
				half4 c;
				c.rgb = (s.Albedo * light.rgb + light.rgb * spec);
				c.a = s.Alpha;
				return c;

			}

			inline half4 LightingBlinnPhongEditor (EditorSurfaceOutput s, half3 lightDir, half3 viewDir, half atten)
			{
				half3 h = normalize (lightDir + viewDir);
				
				half diff = max (0, dot ( lightDir, s.Normal ));
				
				float nh = max (0, dot (s.Normal, h));
				float spec = pow (nh, s.Specular*128.0);
				
				half4 res;
				res.rgb = _LightColor0.rgb * diff;
				res.w = spec * Luminance (_LightColor0.rgb);
				res *= atten * 2.0;

				return LightingBlinnPhongEditor_PrePass( s, res );
			}
			
			struct Input {
				float2 uv_MainTex;
				float4 fullMeshUV1;
				float3 worldPos;
				float2 uv_Illum;

			};

			void vert (inout appdata_full v, out Input o) {
				float4 VertexOutputMaster0_0_NoInput = float4(0,0,0,0);
				float4 VertexOutputMaster0_1_NoInput = float4(0,0,0,0);
				float4 VertexOutputMaster0_2_NoInput = float4(0,0,0,0);
				float4 VertexOutputMaster0_3_NoInput = float4(0,0,0,0);
				
				o.fullMeshUV1 = v.texcoord;

			}
			

			void surf (Input IN, inout EditorSurfaceOutput o) {
				o.Normal = float3(0.0,0.0,1.0);
				o.Alpha = 1.0;
				o.Albedo = 0.0;
				o.Emission = 0.0;
				o.Gloss = 0.0;
				o.Specular = 0.0;
				o.Custom = 0.0;
				
float4 TexCUBE0_1_NoInput = float4(0,0,1,1);
float4 TexCUBE0=texCUBE(_Ramp,TexCUBE0_1_NoInput);
float4 Tex2D0=tex2D(_MainTex,(IN.uv_MainTex.xyxy).xy);
float4 Multiply3=TexCUBE0 * Tex2D0;
float4 Mask0=float4(float4( IN.worldPos.x, IN.worldPos.y,IN.worldPos.z,1.0 ).x,float4( IN.worldPos.x, IN.worldPos.y,IN.worldPos.z,1.0 ).y,0.0,0.0);
float4 Multiply4=Mask0 * _Offset.xxxx;
float4 Add0=(IN.fullMeshUV1) + Multiply4;
float4 Tex2D2=tex2D(_Detail,Add0.xy);
float4 Multiply2=Multiply3 * Tex2D2;
float4 Tex2D1=tex2D(_Illum,(IN.uv_Illum.xyxy).xy);
float4 Multiply0=Tex2D1 * _Emission.xxxx;
float4 Multiply1=_Color * Multiply0;
float4 Master0_1_NoInput = float4(0,0,1,1);
float4 Master0_3_NoInput = float4(0,0,0,0);
float4 Master0_4_NoInput = float4(0,0,0,0);
float4 Master0_5_NoInput = float4(1,1,1,1);
float4 Master0_7_NoInput = float4(0,0,0,0);
float4 Master0_6_NoInput = float4(1,1,1,1);
o.Albedo = Multiply2;
o.Emission = Multiply1;

				o.Normal = normalize(o.Normal);
			}
		ENDCG
	}
	Fallback "Ramp/Basic"
}