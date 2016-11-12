Shader "Unlit/LineGradientShader" {
	Subshader {
		BindChannels {
			Bind "vertex", vertex
			Bind "color", color 
		}
		Pass {}
	}
}
