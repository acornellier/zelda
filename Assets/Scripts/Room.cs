using UnityEngine;

public class Room : MonoBehaviour
{
    public GameObject virtualCamera;
    public string roomName;
    public RoomTitle roomTitle;

    void Start()
    {
        virtualCamera.SetActive(false);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !other.isTrigger)
        {
            virtualCamera.SetActive(true);
            // roomTitle.gameObject.SetActive(true);
            // roomTitle.Display(roomName);
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !other.isTrigger)
        {
            virtualCamera.SetActive(false);
        }
    }
}
