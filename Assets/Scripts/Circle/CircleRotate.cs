
using UnityEngine;

public class CircleRotate : Circle
{
    private void FixedUpdate()
    {
        RotateCircle();
    }

    public override void RotateCircle()
    {
        if (_isRotate)
        {
            SetSpeedRotation();
            SetRotation(rotationSpeed);
        }
    }

    private void SetSpeedRotation()
    {
        meanValueSpeed = (minRotationSpeed + maxRotationSpeed) / 2f;

        halfMeanValueSpeed = (minRotationSpeed + meanValueSpeed) / 2f;

        rotationSpeed += Time.deltaTime;

        if (rotationSpeed == halfMeanValueSpeed)
        {
            speedModifier = 0f;
            rotationSpeed = 0f;
        }

        if (rotationSpeed >= halfMeanValueSpeed)
        {
            speedModifier -= Time.deltaTime;
        }
        else
        {
            speedModifier += Time.deltaTime;
        }

        rotationSpeed += speedModifier;
    }

    private void SetRotation(float speed)
    {
        _circleTransform.rotation = Quaternion.Euler(
            transform.position.x,
            transform.position.y,
            transform.rotation.z - speed);
    }
}
