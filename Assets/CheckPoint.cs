using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    [SerializeField] int _pointNum;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            Debug.Log(_pointNum+" 번째 체크포인트");
        }
    }
}
