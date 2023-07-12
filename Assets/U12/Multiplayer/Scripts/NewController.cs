using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewController : MonoBehaviour
{
    public float movementSpeed = 5f; // Hareket h�z�
    public float rotationSpeed = 10f; // D�n�� h�z�
    public float jumpForce = 5f; // Z�plama kuvveti
    public float runningSpeedMultiplier = 2f; // Ko�ma h�z� katlay�c�s�

    private bool isRunning = false; // Ko�ma durumu
    private bool isJumping = false; // Z�plama durumu
    private Rigidbody rb; // Rigidbody bile�eni referans�

    private void Start()
    {
        rb = GetComponent<Rigidbody>(); // Rigidbody bile�enini al
    }

    private void Update()
    {
        // Hareket giri�i al
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        // Ko�ma kontrol�
        if (Input.GetKey(KeyCode.LeftShift))
        {
            isRunning = true;
        }
        else
        {
            isRunning = false;
        }

        // Hareket ve d�n�� hesaplamas�
        Vector3 movement = new Vector3(horizontalInput, 0f, verticalInput);
        movement.Normalize(); // Hareket vekt�r�n� normalize et
        movement *= isRunning ? movementSpeed * runningSpeedMultiplier : movementSpeed; // Ko�ma durumuna g�re hareket h�z�n� ayarla

        // Yer�ekimi ve z�plama kontrol�
        if (isJumping)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isJumping = false;
        }
        else
        {
            rb.AddForce(Physics.gravity);
        }

        // Hareketi uygula
        rb.velocity = new Vector3(movement.x, rb.velocity.y, movement.z);

        // Karakterin y�n�n� kamera y�n�nde ayarla
        if (movement != Vector3.zero)
        {
            Quaternion toRotation = Quaternion.LookRotation(movement, Vector3.up);
            transform.rotation = Quaternion.Lerp(transform.rotation, toRotation, rotationSpeed * Time.deltaTime);
        }

        // Z�plama giri�i al
        if (Input.GetKeyDown(KeyCode.Space))
        {
            isJumping = true;
        }
    }
}
