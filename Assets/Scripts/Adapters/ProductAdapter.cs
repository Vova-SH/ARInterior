using UnityEngine;
using UnityEngine.Events;
using System.Collections.Generic;

public class ProductAdapter : UI.RecyclerView<ProductAdapter.Holder>.Adapter
{
    [SerializeField]
    private ProductView m_Prefab;

    public UnityEvent<GameObject> onClick;

    private List<ProductModel> m_Data = new List<ProductModel>();

    public List<ProductModel> Data
    {
        get => m_Data;
        set
        {
            m_Data.Clear();
            m_Data.AddRange(value);
            NotifyDatasetChanged();
        }
    }

    public override int GetItemCount()
    {
        return m_Data.Count * 5;
    }

    public override void OnBindViewHolder(Holder holder, int pos)
    {
        holder.Bind(m_Data[pos % m_Data.Count], onClick);
    }

    public override GameObject OnCreateViewHolder()
    {
        return Instantiate(m_Prefab.gameObject);
    }

    public class Holder : ViewHolder
    {
        private readonly ProductView m_Product;

        public Holder(GameObject itemView) : base(itemView)
        {
            m_Product = itemView.GetComponent<ProductView>();
        }

        public void Bind(ProductModel model, UnityEvent<GameObject> onClick)
        {
            m_Product.Bind(model);
            itemView.RemoveAllClickListener();
            itemView.AddClickListener(onClick);
        }
    }
}

