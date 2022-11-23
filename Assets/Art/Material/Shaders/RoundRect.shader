Shader "UI/RoundRectMat"
{
    Properties
    {
        [PerRendererData] _MainTex ("Sprite Texture", 2D) = "white" {}
        _Color ("Color", Color) = (1,1,1,1)

        _Center("Center",vector) = (0,0,0,0)
        _SliderX("SliderX",Range(0,1500)) = 1500
        _SliderY("SliderY",Range(0,1500)) = 1500

        _Radius ("Radius", Range(0, 1)) = 0.3
    }

    SubShader
    {
        Tags
        {
            "Queue"="Transparent"
            "IgnoreProjector"="True"
            "RenderType"="Transparent"
            "PreviewType"="Plane"
            "CanUseSpriteAtlas"="True"
        }

        Cull Off
        Lighting Off
        ZWrite Off
        Blend SrcAlpha OneMinusSrcAlpha

        Pass
        {
            Name "Default"
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            // #pragma target 2.0

            #include "UnityCG.cginc"

            #pragma multi_compile __ UNITY_UI_CLIP_RECT
            #pragma multi_compile __ UNITY_UI_ALPHACLIP

            struct appdata_t
            {
                float4 vertex : POSITION;
                float4 color : COLOR;
                float2 texcoord : TEXCOORD0;
                UNITY_VERTEX_INPUT_INSTANCE_ID
            };

            struct v2f
            {
                float4 vertex : SV_POSITION;
                fixed4 color : COLOR;
                float2 texcoord : TEXCOORD0;
                float4 worldPosition : TEXCOORD1;
                UNITY_VERTEX_OUTPUT_STEREO
            };

            sampler2D _MainTex;
            fixed4 _Color;
            fixed4 _TextureSampleAdd;
            float4 _MainTex_ST;

            float2 _Center;
            float _SliderX;
            float _SliderY;
            float _Radius;

            v2f vert(appdata_t v)
            {
                v2f OUT;
                UNITY_SETUP_INSTANCE_ID(v);
                UNITY_INITIALIZE_VERTEX_OUTPUT_STEREO(OUT);
                OUT.worldPosition = v.vertex;
                OUT.vertex = UnityObjectToClipPos(OUT.worldPosition);

                OUT.texcoord = TRANSFORM_TEX(v.texcoord, _MainTex);

                OUT.color = v.color * _Color;
                return OUT;
            }

            fixed4 frag(v2f IN) : SV_Target
            {
                half4 color = (tex2D(_MainTex, IN.texcoord) + _TextureSampleAdd) * IN.color;

                #ifdef UNITY_UI_CLIP_RECT
                    color.a *= UnityGet2DClipping(IN.worldPosition.xy, _ClipRect);
                #endif

                #ifdef UNITY_UI_ALPHACLIP
                    clip (color.a - 0.001);
                #endif

                float2 dis = IN.worldPosition.xy - _Center.xy;

                float r = _Radius * _SliderX;
                if (_SliderX > _SliderY)
                {
                    r = _Radius * _SliderY;
                }

                const float nx = abs(dis.x) - _SliderX + r;
                const float ny = abs(dis.y) - _SliderY + r;

                if (nx * nx + ny * ny < r * r)
                {
                    color.a = 0;
                }
                if (abs(dis.x) < _SliderX && abs(dis.y) < _SliderY - r)
                {
                    color.a = 0;
                }
                if (abs(dis.x) < _SliderX - r && abs(dis.y) < _SliderY)
                {
                    color.a = 0;
                }
                color.rgb *= color.a;

                return color;
            }
            ENDCG
        }
    }
}