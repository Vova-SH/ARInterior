using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using System.Collections.Generic;

public class ProductAdapter : UI.RecyclerView<ProductAdapter.Holder>.Adapter
{
    [SerializeField]
    private ProductView m_Prefab;

    public UnityEvent<bool, ProductModel, int> onClick;

    private List<ProductModel> m_Data = new List<ProductModel>();

    private ToggleGroup group;

    public List<ProductModel> Data
    {
        get => m_Data;
        set
        {
            m_Data.Clear();
            m_Data.AddRange(value);
            NotifyDataSetChanged();
        }
    }

    protected override void Awake()
    {
        base.Awake();
        group = gameObject.AddComponent<ToggleGroup>();
        group.allowSwitchOff = true;
    }

    public override GameObject OnCreateViewHolder()
    {
        ProductView view = Instantiate(m_Prefab);
        view.group = group;
        return view.gameObject;
    }

    public override void OnBindViewHolder(Holder holder, int pos)
    {
        holder.Bind(m_Data[pos], pos, onClick);
    }

    public override int GetItemCount()
    {
        return m_Data.Count;
    }

    public class Holder : ViewHolder
    {
        private readonly ProductView m_View;
        private UnityAction<bool> listener;

        public Holder(GameObject itemView) : base(itemView)
        {
            m_View = itemView.GetComponent<ProductView>();
        }

        public void Bind(ProductModel model, int position, UnityEvent<bool, ProductModel, int> onClick)
        {
            m_View.Bind(model);
            if(listener != null)
            {
                m_View.onValueChanged.RemoveListener(listener);
            }
            listener = (isOn) =>
            {
                Debug.Log(isOn);
                onClick.Invoke(isOn, model, position);
                //if (!isOn) adapter.Selectable = -1;
            };
            m_View.onValueChanged.AddListener(listener);

            //m_View.isOn = adapter.Selectable == position;
        }
    }
}