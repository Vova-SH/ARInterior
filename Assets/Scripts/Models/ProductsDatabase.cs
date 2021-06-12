using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ReferenceProductsLibrary", menuName = "Products/Reference Product Library", order = 1001)]
public class ProductsDatabase : ScriptableObject
{
    [System.Serializable]
    public struct Item
    {
        [SerializeField]
        internal ProductItem m_Product;
        [SerializeField]
        internal List<ColorItem> m_Colors;
    }

    [SerializeField]
    internal int m_Version;

    [SerializeField]
    internal List<Item> m_Floor;
    [SerializeField]
    internal List<Item> m_Wall;
    [SerializeField]
    internal List<Item> m_Ceiling;
}
