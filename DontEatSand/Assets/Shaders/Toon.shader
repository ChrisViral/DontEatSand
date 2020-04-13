//Toon Shader
//Adapted from https://roystan.net/articles/toon-shader.html

Shader "Toon/Standard"
{
	Properties
	{
		_Colour("Colour", Color) = (0.7, 0.7, 0.7, 1)
		_MainTex("Main Texture", 2D) = "white" { }
		[HDR] _AmbientColour("Ambient Colour", Color) = (0.15, 0.15, 0.15, 0.1)
		[HDR] _SpecularColour("Specular Colour", Color) = (0.9, 0.9, 0.9, 1)
		_Glossiness("Glossiness", Float) = 32
		[HDR] _RimColour("Rim Colour", Color) = (1, 1, 1, 1)
		_RimAmount("Rim Amount", Range(0, 1)) = 0.716
		_RimThreshold("Rim Threshold", Range(0, 1)) = 0.1
		_Steps("Steps", Int) = 1
		_StepSize("Step size", Range(0.1, 0.3)) = 0.2
	}

	SubShader
	{
		Pass
		{
			Tags
			{
				"lightMode" = "ForwardBase"
				"PassFlags" = "OnlyDirectional"
			}

			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag
			#pragma multi_compile_fwdbase

			#include "UnityCG.cginc"
			#include "Lighting.cginc"
			#include "AutoLight.cginc"

			sampler2D _MainTex;
			float4 _MainTex_ST;
			float4 _Colour;
			float4 _AmbientColour;
			float4 _SpecularColour;
			float  _Glossiness;
			float4 _RimColour;
			float  _RimAmount;
			float  _RimThreshold;
			int    _Steps;
			float  _StepSize;

			struct Vertex
			{
				float4 vertex : POSITION;
				float4 uv     : TEXCOORD0;
				float3 normal : NORMAL;
			};

			struct Fragment
			{
		        float4 pos    : SV_POSITION;
				float2 uv     : TEXCOORD0;
				float3 normal : NORMAL;
				float3 view   : TEXCOORD1;

				SHADOW_COORDS(2)
			};

			//Vertex Shader
			Fragment vert (Vertex IN)
			{
				//Passing info to fragment
				Fragment OUT;
				OUT.pos    = UnityObjectToClipPos(IN.vertex);
				OUT.uv     = TRANSFORM_TEX(IN.uv, _MainTex);
				OUT.normal = UnityObjectToWorldNormal(IN.normal);
				OUT.view   = WorldSpaceViewDir(IN.vertex);
				TRANSFER_SHADOW(OUT)
				return OUT;
			}

			//Fragment Shader
			float4 frag (Fragment IN) : SV_Target
			{
				//Setup
				float4 sample = tex2D(_MainTex, IN.uv);
				float3 normal = normalize(IN.normal);
				float3 view   = normalize(IN.view);

				//Shadows
				float shadow = SHADOW_ATTENUATION(IN);

				//Diffuse
				float  dotLight = dot(_WorldSpaceLightPos0, normal);
				//Calculate intensity in steps
				float  diffuseIntensity;
				bool set = false;
				for (int i = 0; i < _Steps - 1; i++)
				{
					float step = i * _StepSize;
					if (dotLight < step)
					{
						diffuseIntensity = (smoothstep(step, step + 0.02, dotLight) * _StepSize) + step;
						set = true;
						break;
					}
				}
				//If not set, it's within the final, larger step
				if (!set)
				{
					float step = (_Steps - 1) * _StepSize;
					diffuseIntensity = (smoothstep(step, step + 0.02, dotLight) * (1 - step)) + step;
				}
				float4 diffuse = diffuseIntensity * _LightColor0 * shadow;

				//Specular
				float3 halfV = normalize(_WorldSpaceLightPos0 + view);
				float  dotHalf = dot(normal, halfV);
				float  specularIntensity = smoothstep(0.005, 0.015, pow(dotHalf * diffuseIntensity, _Glossiness * _Glossiness));
				float4 specular = specularIntensity * _SpecularColour;

				//Rim
				float  dotRim = 1 - dot(view, normal);
				float  rimIntensity = smoothstep(_RimAmount - 0.01, _RimAmount + 0.01, dotRim * pow(dotLight, _RimThreshold));
				float4 rim = rimIntensity * _RimColour;

				return _Colour * sample * (_AmbientColour + diffuse + specular + rim);
			}
			ENDCG
		}

		//Shadow casting
		UsePass "Standard/ShadowCaster"
	}
}