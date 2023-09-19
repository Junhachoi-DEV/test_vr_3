using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class new_paint_wall : MonoBehaviour
{
    public Texture2D texture;
    public Vector2 texture_size = new Vector2(2048, 2048);



    void Start()
    {
        var r = GetComponent<Renderer>();
        texture = new Texture2D((int)texture_size.x, (int)texture_size.y);
        r.material.mainTexture = texture;
    }

}
