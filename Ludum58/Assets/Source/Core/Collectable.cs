using UnityEngine;

public class Collectable : MonoBehaviour
{
    [SerializeField] private Canvas canvas;

    public void ShowCanvas() 
    {
        canvas.gameObject.SetActive(true);
    } 

    public void HideCanvas() 
    {
        canvas.gameObject.SetActive(false);
    }
}
