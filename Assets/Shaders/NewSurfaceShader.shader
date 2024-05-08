Shader "Custom/NewSurfaceShader" {
    Properties {
        _Color ("Main Color", Color) = (1,1,1,1)
    }
    SubShader {
        Tags { "RenderType"="Opaque" }
        LOD 100

        Pass {
            Cull Off
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag

            struct appdata {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
            };

            struct v2f {
                float4 pos : SV_POSITION;
                float3 normal : NORMAL;
            };

            fixed4 _Color;

            v2f vert (appdata v) {
                v2f o;
                o.pos = UnityObjectToClipPos(v.vertex);
                o.normal = v.normal;
                return o;
            }

            fixed4 frag (v2f i) : SV_Target {
                float3 normal = normalize(i.normal);
                float diff = max(dot(normal, normalize(_WorldSpaceLightPos0.xyz)), 0.);
                return _Color * diff;
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
}