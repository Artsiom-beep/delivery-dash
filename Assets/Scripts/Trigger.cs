using UnityEngine;

public class Trigger : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Trigger detected");
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        Debug.Log("Trigger exited");
    }
}
