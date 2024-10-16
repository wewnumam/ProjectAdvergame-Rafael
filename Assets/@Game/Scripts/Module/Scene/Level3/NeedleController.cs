using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class NeedleController : MonoBehaviour
{
    public RectTransform needleTransform;
    public float rotationSpeed = 100f;
    private bool isMoving = true;
    private float currentAngle = 0f;
    private bool movingRight = true;

    // Set the winning range in degrees
    public float winAngleMin = 60f;
    public float winAngleMax = 120f;

    public UnityEvent onWin;
    public UnityEvent onLose;

    void Update()
    {
        if (isMoving)
        {
            MoveNeedle();
        }
    }

    void MoveNeedle()
    {
        // Move the needle left and right between 0 and 180 degrees
        if (movingRight)
        {
            currentAngle += rotationSpeed * Time.deltaTime;
            if (currentAngle >= 180f)
            {
                currentAngle = 180f;
                movingRight = false;
            }
        }
        else
        {
            currentAngle -= rotationSpeed * Time.deltaTime;
            if (currentAngle <= 0f)
            {
                currentAngle = 0f;
                movingRight = true;
            }
        }

        // Apply the rotation to the needle's RectTransform
        needleTransform.localRotation = Quaternion.Euler(0, 0, -currentAngle);
    }

    public void StopNeedle()
    {
        isMoving = false;

        // Check if the needle stops within the winning angle range
        if (currentAngle >= winAngleMin && currentAngle <= winAngleMax)
        {
            onWin?.Invoke();
        }
        else
        {
            onLose?.Invoke();
        }
    }

    public void Restart()
    {
        isMoving = true;
    }
}
