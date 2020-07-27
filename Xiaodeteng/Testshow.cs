using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Testshow : MonoBehaviour
{
    bool show;
    Transform Player;

    private Camera camera;

    //NPC名称

    private string name = "奥莉";

    //NPC模型高度

    private float npcHeight;

    void Start()
    {
        Player = GameObject.Find("3rdPersonController").transform; ;
        show = false;
        camera = Camera.main;

        //得到模型原始高度

       // float size_y = collider.bounds.size.y;

        float size_y = transform.localScale.y;
        //得到模型缩放比例

        float scal_y = transform.localScale.y;

        //NPC模型高度

        npcHeight = (size_y * scal_y);

    }

    void OnGUI()

    {
        if (show)
        {
            //得到NPC头顶在3D世界中的坐标

            //默认NPC坐标点在脚底下，所以这里加上npcHeight它模型的高度即可

            Vector3 worldPosition = new Vector3(transform.position.x, transform.position.y + npcHeight, transform.position.z);

            //根据NPC头顶的3D坐标换算成它在2D屏幕中的坐标

            Vector2 position = camera.WorldToScreenPoint(worldPosition);

            //得到真实NPC头顶的2D坐标

            position = new Vector2(position.x, Screen.height - position.y);

            //计算NPC名称的宽高

            Vector2 nameSize = GUI.skin.label.CalcSize(new GUIContent(name));

            //设置显示颜色为黄色

            GUI.color = Color.yellow;

            //绘制NPC名称

            GUI.Label(new Rect(position.x - (nameSize.x / 2), position.y - nameSize.y, nameSize.x, nameSize.y), name);

        }
    }

    private void Update()
    {
        if (Vector3.Distance(transform.position,Player.position)<5)
        {
            show = true;
        }
        else
        {
            show = false;
        }
    }
}