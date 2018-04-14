Shader "ShaderSketch/Sketch"
{
	Properties
	{
		_MainTex ("Texture", 2D) = "white" {}
	}

	CGINCLUDE
	#include "UnityCG.cginc"

	float4 frag(v2f_img i) : SV_Target
	{
		//return float4(i.uv.x,i.uv.y,0,1);
		
		float d = distance(float2(0.5,0.5),i.uv);
		return d;


	}
	ENDCG

	SubShader
	{
		
		Pass
		{
			CGPROGRAM
			#pragma vertex vert_img
			#pragma fragment frag
			ENDCG
		}
	}
}
