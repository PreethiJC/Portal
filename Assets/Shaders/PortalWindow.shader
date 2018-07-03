Shader "Shaders/PortalWindow"
{
	SubShader
	{
		Zwrite off
        Colormask 0
        Cull off
        
        Stencil
        {
            Ref 1
            Pass replace
        }
		Pass
		{
			
		}
	}
}
