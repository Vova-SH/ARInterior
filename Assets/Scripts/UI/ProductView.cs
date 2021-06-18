using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class ProductView : Toggle
{
    [SerializeField]
    private Image m_Image;
    [SerializeField]
    private Text m_Text;

    public void Bind(ProductModel model)
    {
        m_Image.sprite = model.m_Image;
        m_Text.text = model.m_Name;
    }
}