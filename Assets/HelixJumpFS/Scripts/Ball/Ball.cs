using UnityEngine;

public class Ball : OneColliderTrigger
{
    [SerializeField] private GameObject _ball;
    protected override void OnOneTriggerEnter(Collider other)
    {
        //Debug.Log($"other {other.name}");
    }

    private void Start()
    {
        Renderer ballRenderer = _ball.GetComponent<Renderer>();
        if (ballRenderer != null)
        {
            ballRenderer.material.color = new Color(Random.value, Random.value, Random.value);
        }
    }
}
