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
    private Stack<Image> vidas = new Stack<Image>();


    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;
        Transform posCorazon = posPrimerCorazon;

        for (int i = 0; i < cantCorazon; i++)
        {
            Image newCorazon = Instantiate(Corazon, posCorazon.position, Quaternion.identity);
            newCorazon.transform.SetParent(myCanvas.transform);
            vidas.Push(newCorazon);
            posCorazon.position = new Vector2(posCorazon.position.x + offset, posCorazon.position.y);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void bajarVida()
    {
        Destroy(vidas.Pop().gameObject);

        if (vidas.Count == 0)
        {
            panelGameOver.SetActive(true);
            Time.timeScale = 0;
        }
    }
}
