using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Transform Camera;
   [SerializeField] private float camRotationSpeed = 5f;
   [SerializeField] private float cameraMinY = -60f;
   [SerializeField] private float cameraMaxY = 75f;
   [SerializeField] private float rotationSmoothSpeed = 10f;


   [SerializeField] private float walkSpeed = 9f;
   [SerializeField] private float runSpeed = 14f;
   [SerializeField] private float maxSpeed = 20f;
   [SerializeField] private float jumpPower = 25f;

   [SerializeField] private float extraGravity = 45f;
   [SerializeField] private bool grounded;

   [SerializeField] private GameObject Ground;

    private Rigidbody rb;
    private float bodyRotationX;
    private float camRotationY;
    private Vector3 directionIntextX;
    private Vector3 directionIntentY;
    private float speed;
    private float distToGround = 1.25f;
    private bool changableGrounded;


    Color blue,green,red,pink,brown;

   [SerializeField] private Material[] colorMaterials;

    private int colorIndex;


    
  
    
    
  
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        
    }

    void Update()
    {
        LookRotation();
        GroundCheck();
        CheckChangableGround();

        if(grounded && Input.GetButtonDown("Jump"))
        {
            Jump();

        }

        if(changableGrounded && Input.GetButtonDown("Jump") )
        {
            ChangeGroundColor();

        }

        
    }

    void FixedUpdate()
    {
         Movement();
         ExtraGravity();

    }

   

    public void LookRotation()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;

        //Camera and body rotation Input değerleri.
        bodyRotationX += Input.GetAxis("Mouse X") * camRotationSpeed;
        camRotationY += Input.GetAxis("Mouse Y") * camRotationSpeed;

        //Camera Clamp , Belirtilen max ve min değerler içerisinde rotasyon işlemi gerçekleşsin.
        camRotationY = Mathf.Clamp(camRotationY,cameraMinY,cameraMaxY);

        //Body ve Camera rotasyonu.
        Quaternion camTargetRotation = Quaternion.Euler(-camRotationY,0,0);
        Quaternion bodyTargetRotation = Quaternion.Euler(0,bodyRotationX,0);

        //lerp fonksiyonu ile Smooth rotation.
        transform.rotation   = Quaternion.Lerp(transform.rotation,bodyTargetRotation,Time.deltaTime * rotationSmoothSpeed);
        Camera.localRotation = Quaternion.Lerp(Camera.localRotation,camTargetRotation,Time.deltaTime * rotationSmoothSpeed);
    }

    public void Movement()
    {
        // Kamera'nın baktığı yöne doğru hareket.
        directionIntextX = Camera.right;
        directionIntextX.y = 0;
        directionIntextX.Normalize();

        directionIntentY = Camera.forward;
        directionIntentY.y = 0;
        directionIntentY.Normalize();

        //Karakter movement
        rb.velocity = directionIntentY * Input.GetAxis("Vertical") * speed + directionIntextX * Input.GetAxis("Horizontal") * speed + Vector3.up * rb.velocity.y;
        rb.velocity = Vector3.ClampMagnitude(rb.velocity , maxSpeed);

        //Koşma ve yürüme duruma göre speed değerinin ayarlanması

        if(Input.GetKey(KeyCode.LeftShift))
        {
            speed = runSpeed;
        }
        if(!Input.GetKey(KeyCode.LeftShift))
        {
            speed = walkSpeed;
        }
    }

    public void ExtraGravity()
    {
        rb.AddForce(Vector3.down * extraGravity);
    }

    public void GroundCheck()
    {
        RaycastHit groundHit;
        grounded = Physics.Raycast(transform.position , -transform.up , out groundHit ,distToGround);
    }

    public void CheckChangableGround()
    {  
        LayerMask mask = LayerMask.GetMask("ChangableGround");
        RaycastHit groundHit;
        changableGrounded = Physics.Raycast(transform.position , -transform.up , out groundHit ,distToGround,mask);


    }
    

    public void ChangeGroundColor()
    {
        if(colorIndex < colorMaterials.Length)
        {
            Ground.GetComponent<Renderer>().material = colorMaterials[colorIndex];
            colorIndex++;

        }
        
        else colorIndex = 0;

    }
    

    public void Jump()
    {
        rb.AddForce(Vector3.up * jumpPower , ForceMode.Impulse);
    }


 
  
}

