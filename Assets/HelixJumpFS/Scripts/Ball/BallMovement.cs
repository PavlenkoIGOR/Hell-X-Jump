using UnityEngine;

public class BallMovement : MonoBehaviour
{
    [Header("Animation")]
    [SerializeField] private Animation _animation;
    private string _animClipName = "BallJump";

    [Header("Fall")]
    [SerializeField] private float _fallHeight;
    [SerializeField] private float _fallSpeed;

    private float _floorY;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y > _floorY)
        {
            transform.Translate(0, -_fallSpeed * Time.deltaTime, 0); //локальное пермещение 
            //transform.position += Vector3.down * _fallSpeed * Time.deltaTime; //глобальное перемещение
        }
        else
        {
            transform.position = new Vector3(transform.position.x, _floorY, transform.position.z);
            enabled = false;
        }
    }

    public void Jump()
    {
        _animation[_animClipName].speed = 1;
    }

    public void Fall(float startFloorY)
    {
        _animation[_animClipName].speed = 0;
        enabled = true; // enabled также включает и отключает Update()
        _floorY = startFloorY - _fallHeight;
    }

    public void Stop()
    {
        _animation[_animClipName].speed = 0;
    }
}
