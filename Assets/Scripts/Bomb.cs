using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Bomb : MonoBehaviour
{
    public float BombRange;
    public float BombForce;
    private GameObject[] InRange;
    public float bombDelay;
    void Start()
    {
        //ABSRACTION
        Explode();
    }

    private void Explode () 
    {
        //ABSRACTION
        StartCoroutine(BombDelay());
    } 

    IEnumerator BombDelay()
    {
        yield return new WaitForSeconds(bombDelay);
        gameObject.transform.localScale = new Vector2 (BombRange*1.5f, BombRange*1.5f);
        Collider2D[] colliderArray = Physics2D.OverlapCircleAll(gameObject.transform.position, BombRange);
        foreach (Collider2D collider in colliderArray)
        {
            if (collider.TryGetComponent<MovingObject>(out MovingObject CanGoBoom))
            {
                CanGoBoom.OnExplode(gameObject.transform.position, BombRange, BombForce);
            }
        }
        SoundManager.Instance.PlayBombExplode();
        yield return new WaitForSeconds(.1f);
        Destroy(gameObject);
    }

}
