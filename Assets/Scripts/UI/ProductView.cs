using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class ProductView : View
{
    [SerializeField]
    private Image m_Image;
    [SerializeField]
    private Text m_Text;
    [SerializeField]
    private Color m_SelectableColor;

    private Image m_Background;
    private Color m_UnselectableColor;

    public bool IsSelectable
    {
        set
        {
            m_Background.color = value ? m_SelectableColor : m_UnselectableColor;
        }
    }

    private void Awake()
    {
        m_Background = GetComponent<Image>();
        m_UnselectableColor = m_Background.color;
    }

    public void Bind(ProductModel model)
    {
        m_Image.sprite = model.m_Image;
        m_Text.text = model.m_Name;
    }
}