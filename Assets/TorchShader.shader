Shader "Custom/TorchShader"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
        _CircleCenter ("Circle Center", Vector) = (0.5, 0.5, 0, 0)
        _Radius ("Radius", Float) = 0.2
    }
    SubShader
    {
        Tags { "RenderType"="Opaque" }
        LOD 100

        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag

            #include "UnityCG.cginc"

            struct appdata_t
            {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
            };

            struct v2f
            {
                float2 uv : TEXCOORD0;
                float4 vertex : SV_POSITION;
            };

            sampler2D _MainTex;
            float4 _CircleCenter;
            float _Radius;

            v2f vert (appdata_t v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = v.uv;
                return o;
            }

            half4 frag (v2f i) : SV_Target
            {
                half4 color = tex2D(_MainTex, i.uv);

                float2 uv = i.uv;
                float dist = distance(uv, _CircleCenter.xy);

                if (dist > _Radius)
                {
                    discard;
                }

                return color;
            }
            ENDCG
        }
    }
}