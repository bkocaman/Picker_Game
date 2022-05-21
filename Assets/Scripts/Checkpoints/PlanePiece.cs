using System;
using DG.Tweening;
using UnityEngine;

public class PlanePiece : MonoBehaviour
{
    [SerializeField] private int sectionId;

    public Transform destinationCheckpoint;

    public static event Action<int> OnSectionCompleted;

    private void OnEnable()
    {
        CheckPointDrawer.OnCheckPointArrived += MovePlaneUp;
    }

    private void OnDisable()
    {
        CheckPointDrawer.OnCheckPointArrived -= MovePlaneUp;
    }

    private void MovePlaneUp(Transform transform, int id)
    {
        if (transform.name == destinationCheckpoint.name)
        {
            transform.GetChild(0).GetChild(5).DOLocalMoveY(3f, 1f).OnComplete(() =>
            {
                OnSectionCompleted?.Invoke(id);
            });
        }
    }
}