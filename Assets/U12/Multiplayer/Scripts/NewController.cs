using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewController : MonoBehaviour
{
    public float movementSpeed = 5f; // Hareket hýzý
    public float rotationSpeed = 10f; // Dönüþ hýzý
    public float jumpForce = 5f; // Zýplama kuvveti
    public float runningSpeedMultiplier = 2f; // Koþma hýzý katlayýcýsý

    private bool isRunning = false; // Koþma durumu
    private bool isJumping = false; // Zýplama durumu
    private Rigidbody rb; // Rigidbody bileþeni referansý

    private void Start()
    {
        rb = GetComponent<Rigidbody>(); // Rigidbody bileþenini al
    }

    private void Update()
    {
        // Hareket giriþi al
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        // Koþma kontrolü
        if (Input.GetKey(KeyCode.LeftShift))
        {
            isRunning = true;
        }
        else
        {
            isRunning = false;
        }

        // Hareket ve dönüþ hesaplamasý
        Vector3 movement = new Vector3(horizontalInput, 0f, verticalInput);
        movement.Normalize(); // Hareket vektörünü normalize et
        movement *= isRunning ? movementSpeed * runningSpeedMultiplier : movementSpeed; // Koþma durumuna göre hareket hýzýný ayarla

        // Yerçekimi ve zýplama kontrolü
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

        // Karakterin yönünü kamera yönünde ayarla
        if (movement != Vector3.zero)
        {
            Quaternion toRotation = Quaternion.LookRotation(movement, Vector3.up);
            transform.rotation = Quaternion.Lerp(transform.rotation, toRotation, rotationSpeed * Time.deltaTime);
        }

        // Zýplama giriþi al
        if (Input.GetKeyDown(KeyCode.Space))
        {
            isJumping = true;
        }
    }
}
