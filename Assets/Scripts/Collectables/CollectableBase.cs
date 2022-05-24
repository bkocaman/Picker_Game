using System.Collections;
using DG.Tweening;
using UnityEngine;

public abstract class CollectableBase : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) EventManager.Instance.OnStop += MoveOnZ;
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player")) EventManager.Instance.OnStop -= MoveOnZ;
    }

    private void MoveOnZ()
    {
        transform.DOMoveZ(transform.position.z + 5.5f, 1f).OnComplete(() => StartCoroutine(ShowBlowEffect()));
    }

    private IEnumerator ShowBlowEffect()
    {
        yield return new WaitForSeconds(0.5f);
        gameObject.SetActive(false);
    }
}