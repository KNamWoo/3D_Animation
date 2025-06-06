using UnityEngine;

public class Carrot2 : MonoBehaviour
{
    public GameObject carrot02;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            carrot02.SetActive(true);
        }
    }
}
