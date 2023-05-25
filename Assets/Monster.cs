using UnityEngine;

public class Monster : MonoBehaviour
{
    [SerializeField] Transform _hero;
    [SerializeField] Transform _monster;
    [SerializeField] float _speed;

    private void Update()
    {
        transform.position += (_hero.position - _monster.position).normalized * _speed * Time.deltaTime;
    }
}
