using UnityEngine;
using System.Collections.Generic;
using UnityEngine.Events;

public class ColorPickerAdapter : UI.RecyclerView<ColorPickerAdapter.Holder>.Adapter
{
    [SerializeField]
    private CircleImageView m_Prefab;

    public UnityEvent<GameObject, ColorModel, int> onClick;

    private List<ColorModel> m_Data = new List<ColorModel>();

    public List<ColorModel> Data
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
        holder.Bind(m_Data[pos % m_Data.Count], pos, onClick);
    }

    public override GameObject OnCreateViewHolder()
    {
        return Instantiate(m_Prefab.gameObject);
    }

    public class Holder : ViewHolder
    {
        private readonly CircleImageView m_View;

        public Holder(GameObject itemView) : base(itemView)
        {
            m_View = itemView.GetComponent<CircleImageView>();
        }

        public void Bind(ColorModel model, int position, UnityEvent<GameObject, ColorModel, int> onClick)
        {
            m_View.Sprite = model.m_Image;

            var callback = new UnityEvent<GameObject>();
            callback.AddListener((obj) => onClick.Invoke(obj, model, position));
            m_View.OnClick = callback;
        }
    }
}


