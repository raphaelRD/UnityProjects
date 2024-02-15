using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using System.Linq;

public class Enemy : MonoBehaviour
{
    [Header("Stats")]
    public int curHp;
    public int maxHp;
    public int scoreToGive;

    [Header("Movement")]
    public float moveSpeed;
    public float attackRange;
    public float yPathOffset;

    private List<Vector3> path;

    private Weapon weapon;
    private GameObject target;

    void Start()
    {
        weapon = GetComponent<Weapon>();
        target = FindObjectOfType<Player>().gameObject;

        //Invaca a funcao UpdatePath comecando imediatamente e repetindo a cada meio segundo, mais eficiente que utilizar a funcao dentro do Update ja
        //que calcular todo frame pode afetar a performance.
        InvokeRepeating("UpdatePath",0.0f,0.5f);
    }

    void Update()
    {
        float dist = Vector3.Distance(transform.position,target.transform.position);
        if(dist <= attackRange)
        {
            if(weapon.CanShoot())
            {
                weapon.Shoot();
            }
        }
        else{
            ChaseTarget();
        }
        
    }

    void ChaseTarget()
    {
        //Nao faz nada se o caminho nao possui nenhum ponto, ou seja, o inimigo alcancou o jogador
        if(path.Count==0)
           return;

        //O inimigo vai sempre mover para a posicao que existe na primeira posicao do array, ao chegar na posicao ela e removida do array e proxima posicao
        //se torna a posicao no index 0, todo caminho de navegacao e composto por varios pontos que levam em consideracao objetos solidos
        transform.position = Vector3.MoveTowards(transform.position,path[0] + new Vector3(0,yPathOffset,0), moveSpeed * Time.deltaTime);
        transform.LookAt(target.transform.position);
        if (transform.position==path[0]+ new Vector3(0,yPathOffset,0))
            path.RemoveAt(0);
    }

    void UpdatePath()
    {
        //calcula caminho ate o alvo
        NavMeshPath navMeshPath = new NavMeshPath();
        NavMesh.CalculatePath(transform.position,target.transform.position,NavMesh.AllAreas,navMeshPath);

        //Salva como uma lista as coordenadas que formam um percurso
        path = navMeshPath.corners.ToList();
    }

    public void TakeDamage(int damage)
    {
        curHp -= damage;

        if(curHp<=0)
        {
            Die();
        }
    }

    void Die()
    {
        GameManager.instance.AddScore(scoreToGive);
        Destroy(gameObject);
    }
}
