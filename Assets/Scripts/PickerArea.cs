using System.Collections;
using DG.Tweening;
using UnityEngine;

public abstract class PickerArea : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PickerArea")) EventManager.Instance.OnStop += MoveOnZ;
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("PickerArea")) EventManager.Instance.OnStop -= MoveOnZ;
    }

    private void MoveOnZ()
    {
        transform.DOMoveZ(transform.position.z + 5.5f, 1f).OnComplete(() => StartCoroutine(ShowEffect()));
    }

    private IEnumerator ShowEffect()
    {
        yield return new WaitForSeconds(2f);
        gameObject.SetActive(false);
    }
}