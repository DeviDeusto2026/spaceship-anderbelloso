using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class UI : MonoBehaviour
{
    public GameObject heartPrefab;
    public Transform heartContainer;
    public Color activeColor = Color.white;
    public Color inactiveColor = Color.gray;

    private List<Image> hearts = new List<Image>();

    public void InicializarCorazones(int vidaMaxima)
    {
        foreach (Transform child in heartContainer) Destroy(child.gameObject);
        hearts.Clear();

        for (int i = 0; i < vidaMaxima; i++)
        {
            GameObject newHeart = Instantiate(heartPrefab, heartContainer);
            Image img = newHeart.GetComponent<Image>();
            if (img != null)
            {
                hearts.Add(img);
                img.color = activeColor;
            }
        }
    }

    public void ActualizarCorazones(int vidasActuales)
    {
        for (int i = 0; i < hearts.Count; i++)
        {
            if (i < vidasActuales)
            {
                hearts[i].color = activeColor;
                hearts[i].gameObject.SetActive(true);
            }
            else
            {
                hearts[i].color = inactiveColor;
            }
        }
    }
}
