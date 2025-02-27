using UnityEngine;

public class scrollingBg : MonoBehaviour
{
    public float speed;

    [SerializeField] 
    private Renderer bgRenderer;

    // Update is called once per frame
    void Update()
    {
        bgRenderer.material.mainTextureOffset += new Vector2(Time.deltaTime * speed, 0);
    }
}
