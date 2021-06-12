using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ReferenceProductsLibrary", menuName = "Products/Reference Product Library", order = 1001)]
public class ProductsDatabase : ScriptableObject
{
    [System.Serializable]
    public struct Item
    {
        [SerializeField]
        public ProductModel product;
        [SerializeField]
        public List<ColorModel> colors;
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
