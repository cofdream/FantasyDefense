using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crossbow : MonoBehaviour
{
    [SerializeField] Transform createPoint;
    [SerializeField] Arrow arrowPrefab;
    [SerializeField] float arrowSpeed;
    [SerializeField] float arrowDamage;

    [SerializeField] Vector2 selfPosition;
    void Start()
    {
        selfPosition = transform.position;
    }

    void Update()
    {
        RotationByMousPosition();
        Shoot();
    }

    void RotationByMousPosition()
    {
        var mousePosition = Input.mousePosition;

        //旋转 发射点 到 鼠标世界坐标 基于x轴的夹角

        Vector2 direction = (Vector2)Camera.main.ScreenToWorldPoint(mousePosition) - selfPosition;

        transform.eulerAngles = new Vector3(0, 0, Mathf.Clamp(Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg, -90f, 90f));
    }
    void Shoot()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            var arrow = Instantiate(arrowPrefab, createPoint.transform.position, Quaternion.identity);
            arrow.LaunchDirection = createPoint.eulerAngles;
            arrow.LaunchSpeed = arrowSpeed;
            arrow.Damage = arrowDamage;
        }
    }
}
