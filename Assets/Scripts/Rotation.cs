using UnityEngine;

public class Rotation : MonoBehaviour
{
    public float rotationSpeed = 10f;
    public float speedIncrease = 0.5f;

    private Camera cam;

    private void Start()
    {
        cam = GetComponent<Camera>(); 
    }

    void Update()
    {
        rotationSpeed += speedIncrease * Time.deltaTime;
        transform.Rotate(0,0,rotationSpeed * Time.deltaTime);

    }

}
