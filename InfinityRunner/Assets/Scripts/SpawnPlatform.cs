using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPlatform : MonoBehaviour
{
    public List<GameObject> platforms = new List<GameObject>(); // lista dos prefabs das plataformas

    private List<Transform> currentPlatforms = new List<Transform>(); // lista das plataformas geradas na cena

    private Transform player; // transform do player
    private Transform currentPlatformPoint; // tranform do final point da plataforma atual que o player está acima
    private int platformIndex; // índice da plataforma atual

    public float offset; // distancia que a próxima plaforma é gerada

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform; // atribuindo o transform do GameObject Player à variável

        for(int i = 0; i < platforms.Count; i++)
        {
            Transform p = Instantiate(platforms[i], new Vector2(i * 30, -4.5f), transform.rotation).transform;
            currentPlatforms.Add(p); // adiciona as plaformas prefabs à lista de plataformas geradas durante o jogo
            offset += 30f;
        }

        currentPlatformPoint = currentPlatforms[platformIndex].GetComponent<Platform>().finalPoint; // atribui à currentPlatformPoint a variável finalPoint do script Platform
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    void Move() // método que verifica se o player passou pelo finalPoint de uma plataforma
    {
        float distance =  player.position.x - currentPlatformPoint.position.x;

        if(distance >= 6)
        {
            Recycle(currentPlatforms[platformIndex].gameObject);
            platformIndex++;

            if(platformIndex > currentPlatforms.Count - 1) // esse if evita o index virar 3, já que não existe plataforma na posição 3 da lista
            {
                platformIndex = 0;
            }

            currentPlatformPoint = currentPlatforms[platformIndex].GetComponent<Platform>().finalPoint; 
        }
    }

    public void Recycle(GameObject platform)
    {
        platform.transform.position = new Vector2(offset, -4.5f);
        offset += 30f;
    }
}
