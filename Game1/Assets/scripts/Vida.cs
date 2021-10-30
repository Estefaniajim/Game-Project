using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Vida : MonoBehaviour
{
    //HUD vida
    public Image Corazon;
    public int cantCorazon;
    public RectTransform posPrimerCorazon;
    public Canvas myCanvas;
    public int offset;
    public GameObject panelGameOver;


    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;
        Transform posCorazon = posPrimerCorazon;

        for (int i = 0; i < cantCorazon; i++)
        {
            Image newCorazon = Instantiate(Corazon, posCorazon.position, Quaternion.identity);
            newCorazon.transform.SetParent(myCanvas.transform);
            posCorazon.position = new Vector2(posCorazon.position.x + offset, posCorazon.position.y);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void bajarVida()
    {
        Destroy(myCanvas.transform.GetChild(cantCorazon + 2).gameObject);
        cantCorazon -= 1;

        if (cantCorazon == 0)
        {
            panelGameOver.SetActive(true);
            Time.timeScale = 0;
        }
    }
}
