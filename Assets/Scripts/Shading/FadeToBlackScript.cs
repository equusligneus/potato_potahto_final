using UnityEngine;

public class FadeToBlackScript : MonoBehaviour
{
    public Material fadeMaterial;
    public RuntimeFader faderRef;

    private float current = 1f;

	private void Update()
	{
		if (faderRef)
		{
			faderRef.Update();
			current = faderRef.Value;
		}
	}

	private void OnRenderImage(RenderTexture source, RenderTexture destination)
	{
		if (fadeMaterial)
		{
			fadeMaterial.SetFloat("_Value", current);
			Graphics.Blit(source, destination, fadeMaterial);
		}
		else
		{
			Graphics.Blit(source, destination);
		}
	}
}
