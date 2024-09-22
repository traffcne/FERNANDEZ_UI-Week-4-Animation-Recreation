using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CardFlip : MonoBehaviour
{
    private SpriteRenderer render;
    [SerializeField] private Sprite faceDown, faceUp;

    private bool coRoutAllowed, facedUp;

    void Start()
    {
      render = GetComponent<SpriteRenderer>();
      render.sprite = faceDown;
      coRoutAllowed = true;
      facedUp = false;
    }

    private void OnMouseDown()
    {
        if (coRoutAllowed)
        {
            StartCoroutine(RotateCard());
        }
    }

    private IEnumerator RotateCard()
    {
        coRoutAllowed = false;

        if (!facedUp)
        {
            for (float i = 0f; i <= 180f; i += 10f)
            {
                transform.rotation = Quaternion.Euler(0f, i, 0f);
                transform.DOShakePosition(1.5f, 1, 5, 5);
                if (i == 90f)
                {
                    render.sprite = faceUp;
                }
                yield return new WaitForSeconds(0.01f);
            }
        }

        else if (facedUp) 
        {
            for (float i = 180f; i >= 0; i -= 10f)
            {
                transform.rotation = Quaternion.Euler(0f, i, 0f);
                if (i == 90f)
                {
                    render.sprite = faceDown;
                }
                yield return new WaitForSeconds(0.01f);
            }
        }

        coRoutAllowed = true;
        facedUp = !facedUp;
    }

}
