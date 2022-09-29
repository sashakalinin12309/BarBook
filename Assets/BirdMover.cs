using System.Collections;
using UnityEngine;
public class BirdMover : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _rigidbody2D;
    [SerializeField] private float _hightJump = 2;
    private IEnumerator _RotatationEnumerator;
    public void Jump()
    {
        Vector2 currentSpeed = _rigidbody2D.velocity;
        float startSpeed = Mathf.Sqrt(_hightJump * 2 * Mathf.Abs(Physics.gravity.y));
        _rigidbody2D.velocity = new Vector2(currentSpeed.x, 0);
        _rigidbody2D.AddForce(new Vector2(0, startSpeed * _rigidbody2D.mass), ForceMode2D.Impulse);
        Rotate();
    }
    private void Rotate()
    {
        int minAngle = -45;
        int maxAngle = 45;
        if (_RotatationEnumerator != null) 
        {
            StopCoroutine(_RotatationEnumerator);
        }
        _RotatationEnumerator = RotateBird(minAngle, maxAngle);
        StartCoroutine(_RotatationEnumerator);
    }
    private IEnumerator RotateBird(int minAngle, int maxAngle)
    {
        float timeAnimation = 1f;
        float timeOnFrame = timeAnimation / (maxAngle - minAngle);
        WaitForSeconds wait = new WaitForSeconds(timeOnFrame);
        for (int i = minAngle; i < maxAngle; i++)
        {
            _rigidbody2D.rotation = (float)i;
            yield return wait;
        }
    }
}    































