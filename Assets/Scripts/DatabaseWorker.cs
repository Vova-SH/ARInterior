using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DatabaseWorker : MonoBehaviour
{
    [SerializeField]
    private ProductsDatabase database;

    [Header("Adapters")]
    [SerializeField]
    private ProductAdapter m_ProductAdapter;

    void Start()
    {
        var productsData = database.m_Floor.ConvertAll(
            new System.Converter<ProductsDatabase.Item, ProductModel>(ItemToProductModel)
        );
        m_ProductAdapter.Data = productsData;
    }

    public static ProductModel ItemToProductModel(ProductsDatabase.Item item)
    {
        return item.product;
    }
}
