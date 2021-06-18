using UnityEngine;
using System.Collections.Generic;
using UnityEngine.Events;

public class ColorPickerAdapter : UI.RecyclerView<ColorPickerAdapter.Holder>.Adapter
{
    [SerializeField]
    private CircleImageView m_Prefab;

    public UnityEvent<GameObject, ColorModel, int> onClick;

    private List<ColorModel> m_Data = new List<ColorModel>();

    private int m_SelectablePosition = 0;

    public int Selectable
    {
        set
        {
            m_SelectablePosition = value;
            NotifyDataSetChanged();
        }
    }

    public List<ColorModel> Data
    {
        get => m_Data;
        set
        {
            m_Data.Clear();
            m_Data.AddRange(value);
            m_SelectablePosition = 0;
            NotifyDataSetChanged();
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
        private readonly CircleImageView m_View;

        public Holder(GameObject itemView) : base(itemView)
        {
            m_View = itemView.GetComponent<CircleImageView>();
        }

        public void Bind(ColorModel model, int position, bool isSelectable, UnityEvent<GameObject, ColorModel, int> onClick)
        {
            m_View.Sprite = model.m_Image;

            m_View.isOn = isSelectable;
            m_View.onValueChanged.AddListener((isOn) => onClick.Invoke(itemView, model, position));
        }
    }
}


