Shader "Hidden/PixelArtFilter" {
    Properties {
        _MainTex ("Texture", 2D) = "white" {}
    }

    SubShader {
        Pass {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag

            #include "UnityCG.cginc"

            struct VertexData {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
            };

            struct v2f {
                float4 vertex : SV_POSITION;
                float2 uv : TEXCOORD0;
            };

            v2f vert(VertexData v) {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = v.uv;
                return o;
            }
            
            Texture2D _MainTex;
            SamplerState point_clamp_sampler;

            fixed4 frag(v2f i) : SV_Target {
                fixed4 col = _MainTex.Sample(point_clamp_sampler, i.uv);
                return col;
            }
            ENDCG
        }
    }
}
