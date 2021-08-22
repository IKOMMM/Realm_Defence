using UnityEngine;

public class CameraHandler : MonoBehaviour
{
    public float speedRotation = 25;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("d")){
            transform.Rotate(0, +speedRotation * Time.deltaTime, 0);
        }
        else if (Input.GetKey("a")){
            transform.Rotate(0, -speedRotation * Time.deltaTime, 0);
        }
        
    }
}
