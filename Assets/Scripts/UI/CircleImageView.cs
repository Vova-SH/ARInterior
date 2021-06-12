using UnityEngine;
using UnityEngine.UI;

public class CircleImageView : MonoBehaviour
{
    [SerializeField]
    private Image m_Image;

    public Sprite Sprite
    {
        set
        {
            m_Image.sprite = value;
        }
    }
}
