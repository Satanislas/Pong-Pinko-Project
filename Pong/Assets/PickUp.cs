using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    public enum Category
    {
        Size,
        Speed,
        Slow,
        Invisibility,
    }

    public Category category;
    public AudioClip deathSound;
    
    public void Execute(ball ball)
    {
        switch (category)
        {
            case Category.Size:
                Debug.Log("PICKUP : Increasing Size");
                ball.transform.localScale *= 2;
                break;
            case Category.Speed:
                Debug.Log("PICKUP : Increasing Speed");
                ball.speed += ball.speedIncrease * 4;
                break;
            case Category.Slow:
                Debug.Log("PICKUP : Decreasing Speed");
                ball.speed -= ball.speedIncrease * 4;
                break;
            case Category.Invisibility:
                Debug.Log("PICKUP : Making ball dark");
                ball.Material.color = Color.black;
                break;
            default:
                return;
        }
        PickUpManager.Manager.playSound(deathSound);
        Destroy(gameObject);
    }
}
