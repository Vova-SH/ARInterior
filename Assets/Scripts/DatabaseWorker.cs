using System;
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
    [SerializeField]
    private ColorPickerAdapter m_ColorPickerAdapter;

    private List<ProductsDatabase.Item> m_CurrentList;

    void Awake()
    {
        m_CurrentList = database.m_Floor;
        m_CurrentList.AddRange(m_CurrentList);
        m_CurrentList.AddRange(m_CurrentList);
        m_CurrentList.AddRange(m_CurrentList);
        m_CurrentList.AddRange(m_CurrentList);
        m_CurrentList.AddRange(m_CurrentList);

        var productsData = m_CurrentList.ConvertAll(
            new System.Converter<ProductsDatabase.Item, ProductModel>(ItemToProductModel)
        );

        m_ProductAdapter.Data = productsData;

        m_ProductAdapter.onClick.AddListener(ChooseProduct);
        m_ColorPickerAdapter.onClick.AddListener(ChooseColor);
    }

    private void ChooseProduct(GameObject obj, ProductModel model, int pos)
    {
        var colorData = m_CurrentList[pos].colors;
        m_ColorPickerAdapter.Data = colorData;
        m_ProductAdapter.Selectable = pos;

    }

    private void ChooseColor(GameObject obj, ColorModel model, int pos)
    {

    }

    private static ProductModel ItemToProductModel(ProductsDatabase.Item item)
    {
        return item.product;
    }
}
