using UnityEngine;

public class BlobCreator : OneColliderTrigger
{
    [SerializeField] private Transform _blobPrefab;
    [SerializeField] private Transform _ballMesh;
    [SerializeField] private GameObject _level;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    protected override void OnOneTriggerEnter(Collider other)
    {
        SphereCollider sphereCollider = _ballMesh.GetComponent<SphereCollider>();

        MeshCollider segmentCollider = other.GetComponent<MeshCollider>();

        Vector3 blobPosition = new Vector3(_ballMesh.position.x, segmentCollider.bounds.size.y + 0.02f + other.transform.position.y, _ballMesh.position.z);

        float randomYRotation = Random.Range(0f, 360f);
        Quaternion randomRotation = Quaternion.Euler(0f, randomYRotation, 0f);

        
        if (other.GetComponent<Segment>().Type != SegmentType.Empty)
        {
            Transform newBlob = Instantiate(_blobPrefab, blobPosition, randomRotation, _level.transform);

            if (newBlob?.childCount > 0)
            {
                Renderer quadRenderer = newBlob.GetChild(0).GetComponent<Renderer>();
                if (quadRenderer != null)
                {
                    Material ballMaterial = _ballMesh.GetComponent<Renderer>().material;
                    quadRenderer.material.color = ballMaterial.color;
                }
            }
        }
    }
}
