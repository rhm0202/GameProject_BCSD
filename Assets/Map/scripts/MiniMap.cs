using UnityEditor;
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

        minimapDisplay.texture = discoveryTexture;
        minimapDisplay.material = new Material(Shader.Find("UI/Default"));
        minimapDisplay.material.SetTexture("_MainTex", discoveryTexture);
    }

    
    void Update()
    {
        Vector2 playerPos = GetPlayerTexturePostion();

        RevealArea(playerPos);

        discoveryTexture.Apply();
    }

    Vector2 GetPlayerTexturePostion()
    {
        Vector3 worldPlayerPos = playerTransform.position;
        Vector3 viewPoint = Camera.main.WorldToViewportPoint(worldPlayerPos);

        int x = (int)(viewPoint.x * textureWidth);
        int y = (int)(viewPoint.y * textureHeight);

        return new Vector2(x, y);

    }

    void RevealArea(Vector2 center)
    {
        int cx = (int)center.x;
        int cy = (int)center.y;

        for(int y = -revealRadius; y <= revealRadius; y++)
        {
            for(int x = -revealRadius; x <= revealRadius; x++)
            {
                int currentX = cx + x;
                int currentY = cy + y;

                if(currentX >= 0 && currentX < textureWidth && currentY >= 0 && currentY < textureHeight)
                {
                    float distance = Mathf.Sqrt(x * x + y * y);
                    if(distance <= revealRadius)
                    {
                        Color pixelColor = discoveryTexture.GetPixel(currentX, currentY);
                        Color newColor = Color.Lerp(pixelColor, Color.white, revealSpeed * Time.deltaTime);
                        discoveryTexture.SetPixel(currentX, currentY, newColor);
                    }
                }
            }
        }
    }
}
