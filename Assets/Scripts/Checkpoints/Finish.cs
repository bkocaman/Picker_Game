using UnityEngine;

public class Finish : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PickerPlatform"))
        {
            PlatformCreator.Instance.CreatePlatform();
        }
    }
}