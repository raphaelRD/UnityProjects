using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class PlayerController : MonoBehaviour
{
   public Rigidbody rig;
   public float moveSpeed;
   public float jumpForce;
   public int score; 
   private bool isGrounded;
   private int jumpCount;
   public TextMeshProUGUI scoreText;
    void Update()
    {
        float x = Input.GetAxisRaw("Horizontal") * moveSpeed;
        float z = Input.GetAxisRaw("Vertical") * moveSpeed;

        
        rig.velocity = new Vector3(x,rig.velocity.y,z);

        //Cria-se uma nova variavel para guardar a velocidade do RigidBody, mas definido o angulo Y como zero, pra evitar o comando de transform tambem se aplique ao Y e faca olhar pra cima quando pulando
        Vector3 vel = rig.velocity;
        vel.y = 0;
       

        //Se a forca aplicada ao rigidbody for diferente de zero no angulo X ou Z move o personagem para a frente, evita que ele olhe para a frente quando pulando, ou seja, velocidade aplicada ao Y
        //Tambem evita que o personagem retorne para a posição original quando a velocidade for igual a zero, ou seja, quando nenhuma tecla for apertada.
        if(vel.x !=0 || vel.z !=0)
        {
            transform.forward = vel;
        }
        

        if(Input.GetKeyDown(KeyCode.Space) && jumpCount < 2)
        {
            
            if(jumpCount ==1)
            {
                rig.AddForce(Vector3.up * jumpForce/1.7f,ForceMode.Impulse);
            }
            else
            rig.AddForce(Vector3.up * jumpForce,ForceMode.Impulse);
            jumpCount+=1;
        }

        //if(transform.position.y < -5) - Tambem funciona
        if(rig.position.y < -5)
        {
            GameOver();
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if(collision.GetContact(0).normal == Vector3.up)
        {
            isGrounded = true;
            jumpCount=0;
        }
    }

    public void GameOver()
    {
        SceneManager.LoadScene(3);
    }

    
    public void addScore(int amount)
    {
        score += amount;
        scoreText.text = score.ToString();

    }
}
