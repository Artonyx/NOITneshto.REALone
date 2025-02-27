using UnityEngine;

public class scrollingBg : MonoBehaviour
{
    public float speed = 0.1f;

    [SerializeField] 
    private Renderer bgRenderer;

    // Update is called once per frame
    void Update()
    {
        bgRenderer.material.mainTextureOffset += new Vector2(Time.deltaTime * speed, 0);
    }
}
