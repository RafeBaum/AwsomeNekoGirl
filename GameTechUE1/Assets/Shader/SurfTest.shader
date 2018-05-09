  Shader "Custom /Dissolving" {
  // source: 
    Properties {
      _MainTex ("Texture (RGB)", 2D) = "white" {}
      _NoiseTex ("Dissolve Guide (RGB)", 2D) = "white" {}
      _DissolveAmount ("Disolve Amount", Range(0.0, 1.0)) = 0.5
    }
    SubShader {
      Tags { "RenderType" = "Opaque" }
      Cull Off
      CGPROGRAM
     
      #pragma surface surf Lambert 
      struct Input {
          float2 uv_MainTex;
          float2 uv_NoiseTex;
          float _DissolveAmount;
      };
      sampler2D _MainTex;
      sampler2D _NoiseTex;
      float _DissolveAmount;
      void surf (Input IN, inout SurfaceOutput o) {
          clip(tex2D (_NoiseTex, IN.uv_NoiseTex).rgb - _DissolveAmount);
          o.Albedo = tex2D (_MainTex, IN.uv_MainTex).rgb;
      }
      ENDCG
    } 
    Fallback "Diffuse"
  }