using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class PlacementReticle : MonoBehaviour
{
    [SerializeField]
    private bool m_SnapToMesh;

    public bool SnapToMesh
    {
        get => m_SnapToMesh;
        set => m_SnapToMesh = value;
    }

    [SerializeField]
    private ARRaycastManager m_RaycastManager;
    
    public ARRaycastManager RaycastManager
    {
        get => m_RaycastManager;
        set => m_RaycastManager = value;
    }

    public GameObject ReticlePrefab
    {
        get => m_RaycastManager.raycastPrefab;
    }

    [SerializeField]
    private bool m_DistanceScale;

    public bool DistanceScale
    {
        get => m_DistanceScale;
        set => m_DistanceScale = value;
    }

    private Transform m_CameraTransform;

    private GameObject m_SpawnedReticle;
    private CenterScreenHelper m_CenterScreen;
    private TrackableType m_RaycastMask;
    private float m_CurrentDistance;
    private float m_CurrentNormalizedDistance;

    static List<ARRaycastHit> s_Hits = new List<ARRaycastHit>();
    const float k_MinScaleDistance = 0.0f;
    const float k_MaxScaleDistance = 1.0f;
    const float k_ScaleMod = 1.0f;

    void Start()
    {
        m_CameraTransform = RaycastManager.GetComponent<ARSessionOrigin>().camera.transform;
        m_CenterScreen = CenterScreenHelper.Instance;
        if (m_SnapToMesh)
        {
            m_RaycastMask = TrackableType.PlaneEstimated;
        }
        else
        {
            m_RaycastMask = TrackableType.PlaneWithinPolygon;
        }

        m_SpawnedReticle = Instantiate(ReticlePrefab);
        m_SpawnedReticle.SetActive(false);
    }

    void Update()
    {
        if (m_RaycastManager.Raycast(m_CenterScreen.GetCenterScreen(), s_Hits, m_RaycastMask))
        {
            Pose hitPose = s_Hits[0].pose;
            m_SpawnedReticle.transform.SetPositionAndRotation(hitPose.position, hitPose.rotation);
            m_SpawnedReticle.SetActive(true);
        }

        if (m_DistanceScale)
        {
            m_CurrentDistance = Vector3.Distance(m_SpawnedReticle.transform.position, m_CameraTransform.position);
            m_CurrentNormalizedDistance = ((Mathf.Abs(m_CurrentDistance - k_MinScaleDistance)) / (k_MaxScaleDistance - k_MinScaleDistance))+k_ScaleMod;
            m_SpawnedReticle.transform.localScale = new Vector3(m_CurrentNormalizedDistance, m_CurrentNormalizedDistance, m_CurrentNormalizedDistance);
        }
    }

    public Transform GetReticleTransform()
    {
        return m_SpawnedReticle.transform;
    }
}
