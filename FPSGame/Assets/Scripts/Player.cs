using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("Movement")]
    public float moveSpeed;
    public float jumpForce;

    [Header("Camera")]
    public float lookSensitivity;
    public float maxLookX; //rotação máxima que a camera olha para cima
    public float minLookX; //rotação máxima que a camera olha para baixo
    private float rotX;
    public int jumpCount;

    private Camera cam;
    private Rigidbody rig;
    private Weapon weapon;

    void Awake()
    {
      cam = Camera.main; //Camera.main e um metodo que busca a camera principal e e muito custoso para a performance, achando o elemento apenas uma vez e cacheando em uma variavel e recomendado
      rig = GetComponent<Rigidbody>();
      weapon = GetComponent<Weapon>();

      Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
      Move();
      if(Input.GetButtonDown("Jump"))
      {
        TryJump();
        Debug.LogError(jumpCount);
      }
      CamLook();
      touchedGround();

      if(Input.GetButton("Fire1"))
      {
        if(weapon.CanShoot())
        {
          weapon.Shoot();
        }
      }
    }

    void Move()
    {
        //Captura os inputs no teclado 
        float x = Input.GetAxis("Horizontal") * moveSpeed;
        float z = Input.GetAxis("Vertical") * moveSpeed;

        //Altera a direção para ser relativa em vez de global, ou seja, X e Z são relativos ao modelo do jogador em vez de relativos ao mundo (quando relativo ao mundo o personagem move como um tank)
        Vector3 dir = transform.right * x + transform.forward * z;

        //Como não é possivel mover o personagem através do Y a linha abaixo vai apenas manter a direção Y como 0
        dir.y = rig.velocity.y;
        //Aplica os inputs multiplcados pelo moveSpeed ao Rigidbody do jogador
        rig.velocity = dir;

    }

    void touchedGround()
    {
        Ray ray = new Ray(transform.position,Vector3.down);
        if(Physics.Raycast(ray,1.1f))
         jumpCount = 0;
    }

    void CamLook()
    {
      //Rotação horizontal é alterada no angulo Y, assim como rotação vertical altera o angulo X, por isso o movimento horizontal
      //utiliza um Y e o movimento vertical utiliza X.  
      float y = Input.GetAxis("Mouse X") * lookSensitivity;
      rotX -= Input.GetAxis("Mouse Y") * lookSensitivity; 

      rotX  = Mathf.Clamp(rotX,minLookX,maxLookX);

      //Rotaciona a camera no angulo Y  
      cam.transform.localRotation = Quaternion.Euler(rotX,0,0);

      //Rotacion o JOGADOR no angulo X
      transform.eulerAngles += Vector3.up * y;
    }

    void TryJump()
    {  
      Ray ray = new Ray(transform.position,Vector3.down);
      if(Physics.Raycast(ray,10f) && jumpCount<2)
      {
        rig.AddForce(Vector3.up * jumpForce,ForceMode.Impulse);
        jumpCount++;
      }
    }
}
