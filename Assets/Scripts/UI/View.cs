using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class View : MonoBehaviour, IPointerClickHandler
{
    [SerializeField]
    private UnityEvent<GameObject> m_OnClick;

    public UnityEvent<GameObject> OnClick
    {
        set
        {
            m_OnClick = value;
        }
    }


    public void OnPointerClick(PointerEventData eventData)
    {
        m_OnClick.Invoke(gameObject);
    }
}