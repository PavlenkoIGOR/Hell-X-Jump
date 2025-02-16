using UnityEngine;

public enum SegmentType
{
    Default,
    Trap,
    Empty,
    Finish
}

public class Segment : MonoBehaviour
{
    [SerializeField] private Material _trapMtl;
    [SerializeField] private Material _finishMtl;

    [SerializeField] private SegmentType segmentType;

    private MeshRenderer _meshRenderer;

    public SegmentType Type => segmentType;

    private void Awake()
    {
        _meshRenderer = GetComponent<MeshRenderer>();
        
    }

    public void SetTrap()
    {
        _meshRenderer.enabled = true;
        _meshRenderer.material = _trapMtl;

        segmentType = SegmentType.Trap;
    }

    public void SetEmpty()
    {
        _meshRenderer.enabled = false;

        segmentType = SegmentType.Empty;        
    }

    public void SetFinish()
    {
        _meshRenderer.enabled = true;
        _meshRenderer.material = _finishMtl;

        segmentType = SegmentType.Finish;
    }
}
