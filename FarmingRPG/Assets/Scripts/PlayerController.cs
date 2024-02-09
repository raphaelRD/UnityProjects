using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class PlayerController : MonoBehaviour
{
    public float moveSpeed;

    private Vector2 moveInput;
    private bool interactInput;
    private bool buildInput;
    public GameObject fence;
    private Vector2 facingDir;

    public LayerMask interactLayerMask;

    public Rigidbody2D rig;
    public SpriteRenderer sr;
    

    void Update()
    {
        if (moveInput.magnitude != 0.0f)
        {
            //Altera a direção que o sprite está olhando para ser igual a ultima tecla de movimento para a função de Interact sempre chegar um tile a frente da direção que o jogador está olhando
            facingDir = moveInput.normalized;
            //Inverte o sprint no eixo X se o moveInput for maior que zero, ou seja, apertando para a direta (ele é negativo quando se aperta para a esquerda), isso só relevante porquê a posição default do
            //sprite esta olhando para a esquerda.
            sr.flipX = moveInput.x > 0;
        }
        if (interactInput)
        {
            TryInteractTile();
            interactInput = false;
        }

        if(buildInput)
        {
            OnBuild();
        }
    }

    void FixedUpdate()
    {
        rig.velocity = moveInput.normalized * moveSpeed;
    }

    public void OnMoveInput (InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector2>();
    }

    public void OnInteractInput(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Performed){
            interactInput = true;
        }
    }

    public void OnBuild()
    {
        Debug.Log("Funcionou");
        RaycastHit2D hit = Physics2D.Raycast((Vector2)transform.position + facingDir,Vector3.up,0.1f,interactLayerMask);
        if(hit.collider != null)
        {
            FieldTileScript tile = hit.collider.GetComponent<FieldTileScript>();
            tile.Build(fence);
        }
    }
    

    void TryInteractTile()
    {
        RaycastHit2D hit = Physics2D.Raycast((Vector2)transform.position + facingDir,Vector3.up,0.1f,interactLayerMask);
        if(hit.collider != null)
        {

            FieldTileScript tile = hit.collider.GetComponent<FieldTileScript>();
            tile.Interact();
        }
    }
}
