using UnityEngine;
using UnityEngine.Events;
using System.Collections.Generic;

public class ProductAdapter : UI.RecyclerView<ProductAdapter.Holder>.Adapter
{
    [SerializeField]
    private ProductView m_Prefab;

    public UnityEvent<GameObject, ProductModel, int> onClick;

    private List<ProductModel> m_Data = new List<ProductModel>();

    private int m_SelectablePosition = -1;

    public int Selectable
    {
        set
        {
            m_SelectablePosition = value;
            NotifyDatasetChanged();
        }
    }

    public List<ProductModel> Data
    {
        get => m_Data;
        set
        {
            m_Data.Clear();
            m_Data.AddRange(value);
            m_SelectablePosition = -1;
            NotifyDatasetChanged();
        }
    }

    public override int GetItemCount()
    {
        return m_Data.Count;
    }

    public override void OnBindViewHolder(Holder holder, int pos)
    {
        holder.Bind(m_Data[pos], pos, pos == m_SelectablePosition, onClick);
    }

    public override GameObject OnCreateViewHolder()
    {
        return Instantiate(m_Prefab.gameObject);
    }

    public class Holder : ViewHolder
    {
        private readonly ProductView m_View;

        public Holder(GameObject itemView) : base(itemView)
        {
            m_View = itemView.GetComponent<ProductView>();
        }

        public void Bind(ProductModel model, int position, bool isSelecteble, UnityEvent<GameObject, ProductModel, int> onClick)
        {
            m_View.Bind(model);
            m_View.IsSelectable = isSelecteble;
            var callback = new UnityEvent<GameObject>();
            callback.AddListener((obj) => onClick.Invoke(obj, model, position));
            m_View.OnClick = callback;
        }
    }
}


