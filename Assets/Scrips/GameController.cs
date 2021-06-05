using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public GameObject jugador;

    public GameObject obj;
    public int i = 1;
    public float x;
    public float y;

    float tiempoRestante;
    public Text time_txt;

    //Interfaz, derrota y victoria
    public Text gamedefeat;
    public Text gamevictory;
    public Text Score;
    public bool lose;
    public int scr;

    //Movimiento y camara
    public GameObject player;
    public new Camera camera;

    void Start()
    {
        StartCoroutine(ComenzarCronometro(60));
    }

    void Update()
    {
        if (scr == 20)
        {
            Victory();
        }


        camera.transform.position = new Vector3(player.transform.position.x, player.transform.position.y, camera.transform.position.z);
    }

    public void AumentoScore()
    {
        scr += 1;
        Score.text = "Object remaining: " + scr;
    }

    public void Victory()
    {
        gamevictory.text = "Victory";
        StartCoroutine(Defeatcrono(2f));
    }

    public void Defeat()
    {
        gamedefeat.text = "Game Over";
        StartCoroutine(Defeatcrono(2f));
    }

    public IEnumerator Defeatcrono(float valcrono)
    {
        yield return new WaitForSeconds(valcrono);
        SceneManager.LoadScene("Main Menú");
    }

    public IEnumerator ComenzarCronometro(float valorCronometro = 60)
    {
        tiempoRestante = valorCronometro;
              

        while (tiempoRestante > 0)
        {
            if (tiempoRestante % 5 == 0)
            {
                i++;
                Spawn(i);
            }

            time_txt.text = "Time: " + tiempoRestante.ToString();
            tiempoRestante--;


            if (tiempoRestante <= 0)
            {
                Defeat();
            }

            yield return new WaitForSeconds(1.0f);

        }
    }

    public void Spawn(int i)
    {

        for (int j = 0; j < i; j++)
        {
            x = Random.Range(-60.0f, 60.0f);
            y = Random.Range(-30.0f, 30.0f);
            if ((x > jugador.transform.position.x + 20) || (y > jugador.transform.position.y + 20))
            {
                Instantiate(obj, new Vector3(x, y, 1f), Quaternion.identity);
            }
            else
            {
                Instantiate(obj, new Vector3(x + 20, y + 20, 1f), Quaternion.identity);
            }

        }
    }
}
