using UnityEngine;

public class CustomModelReticle : MonoBehaviour
{
    [SerializeField]
    private PlacementReticle reticle;

    [SerializeField]
    private ProductAdapter m_ProductAdapter;
    [SerializeField]
    private ColorPickerAdapter m_ColorPickerAdapter;

    private GameObject m_CustomReticle = null;

    public GameObject CustomReticle
    {
        set
        {
            if (m_CustomReticle)
            {
                Destroy(m_CustomReticle);
            }
            m_CustomReticle = Instantiate(value, reticle.GetReticleTransform());
        }
    }

    private void Reset()
    {
        reticle = GetComponent<PlacementReticle>();
    }

    private void Awake()
    {
        m_ProductAdapter.onClick.AddListener(ChooseProduct);
        m_ColorPickerAdapter.onClick.AddListener(ChooseColor);
    }

    private void Update()
    {
        if(m_CustomReticle)
        {
            m_CustomReticle.transform.localScale = reticle.GetReticleTransform().localScale.Invert();
        }
    }

    private void ChooseProduct(bool isOn, ProductModel model, int pos)
    {
        if (isOn)
        {
            CustomReticle = model.m_Prefab;
        }
        else
        {
            Destroy(m_CustomReticle);
            m_CustomReticle = null;
        }
    }

    private void ChooseColor(GameObject obj, ColorModel model, int pos)
    {
        //TODO: add change color
    }
}
