using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnterArrowTrigger : MonoBehaviour, IPlayerTriggerable
{
    public enum ArrowDirectionType
    {
        Up = 0,
        Down,
        Left,
        Right,
    }
    [SerializeField] ArrowDirectionType arrowDirectionType;
    [SerializeField] Transform arrow;

    public void OnPlayerTriggerable(PlayerController player)
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
       // Debug.Log("Enter" + collision.name);
        StartCoroutine(PlayArrowAnimator());
        arrow.gameObject.SetActive(true);

        switch (arrowDirectionType)
        {
            case ArrowDirectionType.Up:
                arrow.transform.localPosition = Vector3.up * 1.1f;
                arrow.transform.localRotation = Quaternion.Euler(0, 0, 0);
                arrow.GetComponent<SpriteRenderer>().flipY = false;
                break;
            case ArrowDirectionType.Down:
                arrow.transform.localPosition = -Vector3.up;
                arrow.transform.localRotation = Quaternion.Euler(0, 0, 0);
                arrow.GetComponent<SpriteRenderer>().flipY = true;
                break;
            case ArrowDirectionType.Left:
                arrow.transform.localPosition = -Vector3.right;
                arrow.localRotation = Quaternion.Euler(0, 0, 90);
                arrow.GetComponent<SpriteRenderer>().flipY = false;
                break;
            case ArrowDirectionType.Right:
                arrow.transform.localPosition = Vector3.right;
                arrow.transform.localRotation = Quaternion.Euler(0, 0, 90);
                arrow.GetComponent<SpriteRenderer>().flipY = true;
                break;
            default:
                break;
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
       // Debug.Log("Stay" + collision.name);
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
       // Debug.Log("Exit" + collision.name);
        StopAllCoroutines();
        arrow.gameObject.SetActive(false);
    }

    private IEnumerator PlayArrowAnimator()
    {
        var sp = arrow.GetComponent<SpriteRenderer>();
        float a = 255f;
        while (true)
        {
            while (true)
            {
                if (a <= 100f)
                {
                    break;
                }
                a -= 5;
                sp.color = new Color(1, 1, 1, a / 255f);

                yield return null;
            }
            while (true)
            {
                if (a >= 255f)
                {
                    break;
                }
                a += 5;
                sp.color = new Color(1, 1, 1, a / 255f);

                yield return null;
            }
        }
    }
}