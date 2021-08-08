using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Text_blinking : MonoBehaviour
{
    private Text text;

    [SerializeField]
    float blinking = 0.1f;

    float text_transparent;
    void Start()
    {
        text = this.gameObject.GetComponent<Text>();
    }
    void Update()
    {
        text.color = GetAlphaColor(text.color);
    }
   
    Color GetAlphaColor(Color color)
    {
        text_transparent += Time.deltaTime * 5.0f * blinking;
        color.a = Mathf.Sin(text_transparent) * 0.5f + 0.5f;

        return color;
    }
}
