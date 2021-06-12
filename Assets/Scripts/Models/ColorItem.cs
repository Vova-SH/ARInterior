using UnityEngine;

[CreateAssetMenu(fileName = "ColorProduct", menuName = "Products/Product color", order = 1001)]
public class ColorItem : ScriptableObject
{
    [SerializeField]
    internal Sprite m_Image;
    [SerializeField]
    internal Material m_Material;
}
