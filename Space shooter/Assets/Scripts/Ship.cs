using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ship : MonoBehaviour
{
    public GameOverScreen GetGameOverScreen;
   

    public float forwardSpeed = 25f, strafeSpeed = 7.5f, hoverSpeed = 5f;
    private float activeForwardSpeed, activeStrafeSpeed, activeHoverSpeed;
    private float forwardAcceleraion = 2.5f, strafeAcceleration = 2f, hoverAcceleration = 2f;

    public float lookRateSpeed = 90f;
    private Vector2 lookInput, screencCenter, mouseDistance;

    private float rollInput;
    public float rollSpeed = 90f, rollAcceleration = 3.5f;

    // Start is called before the first frame update
    void Start()
    {
        screencCenter.x = Screen.width * .5f;
        screencCenter.y = Screen.height * .5f;

        Cursor.lockState = CursorLockMode.Confined;
    }

    // Update is called once per frame
    void Update()
    {
        lookInput.x = Input.mousePosition.x;
        lookInput.y = Input.mousePosition.y;

        mouseDistance.x = (lookInput.x - screencCenter.x) / screencCenter.y;
        mouseDistance.y = (lookInput.y - screencCenter.y) / screencCenter.y;

        mouseDistance = Vector2.ClampMagnitude(mouseDistance, 1f);

        rollInput = Mathf.Lerp(rollInput, Input.GetAxisRaw("Roll"), rollAcceleration * Time.deltaTime);

        transform.Rotate(-mouseDistance.y * lookRateSpeed * Time.deltaTime, mouseDistance.x * lookRateSpeed * Time.deltaTime, rollInput * rollSpeed * Time.deltaTime, Space.Self);

        activeForwardSpeed = Mathf.Lerp(activeForwardSpeed, Input.GetAxisRaw("Vertical") * forwardSpeed, forwardAcceleraion * Time.deltaTime);
        activeStrafeSpeed = Mathf.Lerp(activeStrafeSpeed, Input.GetAxisRaw("Horizontal") * strafeSpeed, strafeAcceleration * Time.deltaTime);
        activeHoverSpeed = Mathf.Lerp(activeHoverSpeed, Input.GetAxisRaw("Hover") * hoverSpeed, hoverAcceleration * Time.deltaTime);

        transform.position += transform.forward * activeForwardSpeed * Time.deltaTime;
        transform.position += (transform.right * activeStrafeSpeed * Time.deltaTime) + (transform.up * activeHoverSpeed * Time.deltaTime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        Destroy(this.gameObject);
        
    }
}
