using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class new_paint_brush : MonoBehaviour
{
    public Transform _tip;
    public int _brush_size = 5;

    new_paint_wall _new_paint_wall;
    Renderer _renderer;
    Color[] _colors;
    float _tip_height;

    RaycastHit _touch;
    Vector2 _touch_pos, _last_touch_pos;
    bool _is_touch_last_frame;

    void Start()
    {
        _renderer = _tip.GetComponent<Renderer>();
        _colors = Enumerable.Repeat(_renderer.material.color, _brush_size *_brush_size).ToArray();
        _tip_height = _tip.localScale.y;
    }

    void Update()
    {
        Drow();
    }

    void Drow()
    {
       
        if(Physics.Raycast(_tip.position, transform.up, out _touch, _tip_height))
        {
            if (_touch.transform.CompareTag("new_paint_wall"))
            {
                if(_new_paint_wall == null)
                {
                    _new_paint_wall = _touch.transform.GetComponent<new_paint_wall>();
                }

                _touch_pos = new Vector2(_touch.textureCoord.x, _touch.textureCoord.y);

                var x = (int)(_touch_pos.x * _new_paint_wall.texture_size.x - (_brush_size / 2));
                var y = (int)(_touch_pos.y * _new_paint_wall.texture_size.y - (_brush_size / 2));

                if(y < 0 || y > _new_paint_wall.texture_size.y || x < 0 || x > _new_paint_wall.texture_size.x)
                {
                    return;
                }

                if (_is_touch_last_frame)
                {
                    _new_paint_wall.texture.SetPixels(x, y, _brush_size, _brush_size, _colors);

                    //보간(자연스럽게 그려지게) 
                    for (float f = 0.01f; f < 1.00f; f += 0.01f)
                    {
                        var lerp_x = (int)Mathf.Lerp(_last_touch_pos.x, x, f);
                        var lerp_y = (int)Mathf.Lerp(_last_touch_pos.y, y, f);
                        _new_paint_wall.texture.SetPixels(lerp_x, lerp_y, _brush_size, _brush_size, _colors);
                    }

                    _new_paint_wall.texture.Apply(); // 업데이트
                }

                _is_touch_last_frame = true;
                return;
            }
        }

        //해제
        _new_paint_wall = null;
        _is_touch_last_frame = false;
    }
}
