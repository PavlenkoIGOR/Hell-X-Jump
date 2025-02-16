using System.Collections;
using UnityEngine;

public class FloorExplosion : BallEvents
{
    public float explosionForce = 10f; // Сила взрыва
    public float randomRotationSpeed = 100f; // Скорость случайного вращения

    protected override void OnBallCollisionSegment(Segment other)
    {
        if (other.transform != null)
        {
            ExplodeChildren(other);
        }
    }
    public void ExplodeChildren(Segment segment)
    {
        Transform segmentParent = segment.transform.parent;
        segmentParent.SetParent(null);  

        if (segment != null)
        {
            foreach (Transform child in segmentParent)
            {
                Rigidbody rb = child.GetComponent<Rigidbody>();
                if (rb != null)
                {
                    rb.useGravity = true;
   
                    rb.angularVelocity = Random.insideUnitSphere * randomRotationSpeed;
                    
                    rb.AddForce(child.up * explosionForce, ForceMode.Impulse);
                }
            }
        }
        StartCoroutine(DestroySegmentParent(segmentParent.gameObject));
    }

    private IEnumerator DestroySegmentParent(GameObject segmentParent)
    {
        yield return new WaitForSeconds(0.6f);
        Destroy(segmentParent);
    }
}
