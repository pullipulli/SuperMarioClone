using UnityEngine;

[RequireComponent(typeof(Animator))]
public class Movement : MonoBehaviour
{
    [SerializeField] private bool facingRight = true;
    [SerializeField] private float maxMovementSpeed = 1;

    private int direction = 1;
    private void Flip()
    {
        facingRight = !facingRight;

        if (facingRight)
            direction = 1;
        else direction = -1;

        transform.Rotate(0, 180f, 0);
    }

    public void Move(Vector2 v)
    {
        if (v.x < 0 && facingRight)
            Flip();

        if (v.x > 0 && !facingRight)
            Flip();

        if (System.Math.Abs(v.x) > 0 || System.Math.Abs(v.y) > 0)
        {
            transform.Translate(direction * v.x * maxMovementSpeed * Time.deltaTime, v.y, 0);
        }
    }
}
