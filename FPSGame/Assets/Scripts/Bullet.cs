using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public int damage;
    public float lifetime;
    private float shootTime;
    public GameObject hitParticle;
    public GameObject hitParticleGround;

    //Como as balas estao sendo gerenciadas pelo ObjectPool as configuracoes iniciais da bala devem ser feitas
    //sempre que elas mudarem o status para Ativas em vez de na funcao de Start()
    void OnEnable()
    {
        shootTime = Time.time;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.time - shootTime >= lifetime){
            gameObject.SetActive(false);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        //A performance e melhor ao utilizar tags em vez de verificar pelo componente
        //a bala vai verificar apenas tags ate acertar o jogador, ao acertar o componente e invocado pra executar os metodos de dano
        if(other.CompareTag("Player"))
        {
            other.GetComponent<Player>().TakeDamage(damage);
        }
        else if(other.CompareTag("Enemy"))
        {
            other.GetComponent<Enemy>().TakeDamage(damage);

            //Cria o efeito de particulas
            GameObject obj = Instantiate(hitParticle, transform.position, Quaternion.identity);
            Destroy(obj,0.5f);
        }
        else
        {
            GameObject obj = Instantiate(hitParticleGround, transform.position, Quaternion.identity);
        }
        gameObject.SetActive(false);
    }
}
