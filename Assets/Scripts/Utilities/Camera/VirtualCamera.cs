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
            var target = GameObject.FindGameObjectWithTag("Player").transform;
            vcam.transform.position = target.position;
            vcam.Follow = target;
        }
    }
}
