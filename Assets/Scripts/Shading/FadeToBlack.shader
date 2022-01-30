Shader "Hidden/FadeToBlack"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
        _Value ("Value", Range(0, 1)) = 1
    }
    SubShader
    {
        // No culling or depth
        Cull Off ZWrite Off ZTest Always

        Pass
        {
            CGPROGRAM
            #pragma vertex vert_img
            #pragma fragment frag

            #include "UnityCG.cginc"

            sampler2D _MainTex;
            float _Value;

            fixed4 frag (v2f_img i) : SV_TARGET
            {
                fixed4 col = tex2D(_MainTex, i.uv);
                col.rgb *= _Value;
                return col;
            }
            ENDCG
        }
    }
}
