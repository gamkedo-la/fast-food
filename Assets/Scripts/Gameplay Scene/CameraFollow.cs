using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] Transform targetToFollow;
    [SerializeField] float lerpRatio = 5.0f;
    private Vector3 vector3VelocityReference = new Vector3(5.0f, 0.0f, 0.0f);
    

    private void LateUpdate()
    {
        if (GameManagerScript.cameraShouldFollowChef)
        {
            Vector3 newPosition = new Vector3(targetToFollow.position.x, gameObject.transform.position.y, gameObject.transform.position.z);
            //Vector3 smoothedPosition = Vector3.Lerp(gameObject.transform.position, newPosition, lerpRatio*Time.deltaTime);
            Vector3 smoothedPosition = Vector3.SmoothDamp(gameObject.transform.position, newPosition, ref vector3VelocityReference, 1.0f);

            gameObject.transform.position = newPosition;
        }
    }
}
