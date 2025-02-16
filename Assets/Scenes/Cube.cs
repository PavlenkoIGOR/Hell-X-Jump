using UnityEngine;

public class Cube : MonoBehaviour
{
    public void OnTriggerEnter(Collider other)
    {
        Debug.Log($"obj {other.name}");
    }
}
