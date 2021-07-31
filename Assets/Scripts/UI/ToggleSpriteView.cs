using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ToggleSpriteView : UIBehaviour
{
    [SerializeField]
    private Image m_Image;

    [SerializeField]
    private Toggle m_Toggle;

    [Header("Sprite States")]
    [SerializeField]
    private Sprite m_OnSprite;
    [SerializeField]
    private Sprite m_OffSprite;


#if UNITY_EDITOR
    protected override void Reset()
    {
        m_Image = GetComponent<Image>();
        m_Toggle = GetComponentInParent<Toggle>();
    }

#endif

    protected override void Awake()
    {
        m_Toggle.onValueChanged.AddListener(ChangeState);
        ChangeState(m_Toggle.isOn);
    }

    public void ChangeState(bool state)
    {
        m_Image.sprite = state ? m_OnSprite : m_OffSprite;
    }
}
