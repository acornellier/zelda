using Cinemachine;
using UnityEngine;

public class VirtualCamera : MonoBehaviour
{
    CinemachineVirtualCamera vcam;

    void Awake()
    {
        vcam = GetComponent<CinemachineVirtualCamera>();
    }

    void Update()
    {
        if (!vcam.Follow)
        {
            vcam.Follow = GameObject.FindGameObjectWithTag("Player").transform;
        }
    }
}
