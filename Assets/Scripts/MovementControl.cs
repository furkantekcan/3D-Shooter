using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementControl : MonoBehaviour
{
    [SerializeField]
    private float speed = 5f;
    private Rigidbody rb;

    [SerializeField]
    private float sensivity = 3f;

    [SerializeField]
    GameObject fpsCamera;


    private Vector3 velocity = Vector3.zero;
    private Vector3 rotation = Vector3.zero;

    private float cameraUPDownRotation = 0f;
    private float currentCameraLocation = 0f;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float _xMovement = Input.GetAxis("Horizontal");
        float _zMovement = Input.GetAxis("Vertical");

        Vector3 _movementHorizontal = transform.right * _xMovement;
        Vector3 _movementVertical = transform.forward * _zMovement;

        //final movement velocity

        Vector3 _movementVelocity = (_movementHorizontal + _movementVertical).normalized * speed;

        Move(_movementVelocity);


        //Calculate rotation with 3D vector

        float _yRotation = Input.GetAxis("Mouse X");
        Vector3 _rotationVector = new Vector3(0, _yRotation,0) * sensivity;

        //Apply rotation 
        Rotate(_rotationVector);

        //calculate updown lok
        float _cameraUpDownRotation = Input.GetAxis("Mouse Y") * sensivity;

        //apply rotation
        RotateCamera(_cameraUpDownRotation);
    }

    private void FixedUpdate()
    {
        if (velocity != Vector3.zero)
        {
            rb.MovePosition(rb.position + velocity * Time.deltaTime);
        }

        rb.MoveRotation(rb.rotation * Quaternion.Euler(rotation));

        if (fpsCamera != null)
        {
            currentCameraLocation -= cameraUPDownRotation;
            currentCameraLocation = Mathf.Clamp(currentCameraLocation, -85, 85);

            fpsCamera.transform.localEulerAngles = new Vector3(currentCameraLocation, 0, 0);
        }

    }

    #region Methods

    void Move(Vector3 movementVelocity)
    {
        velocity = movementVelocity;
    }
    void Rotate(Vector3 rotationVector)
    {
        rotation = rotationVector;
    }
    void RotateCamera(float cameraDownRotation)
    {
        cameraUPDownRotation = cameraDownRotation;
    }

    #endregion


}
