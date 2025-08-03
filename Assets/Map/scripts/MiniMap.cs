using UnityEngine;
using UnityEngine.UI;

public class MiniMap : MonoBehaviour
{
    public RenderTexture minimapRenderTexture;
    public RawImage minimapDisplay;
    public Transform playerTransform;

    private Texture2D discoveryTexture;
    private int textureWidth, textureHeight;

    public int revealRadius = 10;
    public float revealSpeed = 0.5f;


    void Start()
    {
        textureHeight = minimapRenderTexture.height;
        textureWidth = minimapRenderTexture.width;

        discoveryTexture = new Texture2D(textureWidth, textureHeight, TextureFormat.ARGB32, false);
        Color[] colors = new Color[textureWidth * textureHeight];
        for(int i = 0; i < colors.Length; i++)
        {
            colors[i] = Color.black;
        }
        discoveryTexture.SetPixels(colors);
        discoveryTexture.Apply();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
