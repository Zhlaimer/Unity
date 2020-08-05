using System.Collections;
using UnityEngine;
using System.Collections.Generic;//引用集合
using System.Xml;//引用XML
using UnityEngine.UI;//引用UI
using UnityEngine.SceneManagement;//引用场景管理
/// <summary>
/// 枚举指令类型
/// </summary>
public enum CommandType
{
    Say,//说话
    Bgm,//背景音乐
    Bg//背景
}
/// <summary>
/// 基类  指令类
/// </summary>
public class Command
{
    public CommandType AllType;//定义成员变量 类型对象
}
/// <summary>
/// 说话指令类：继承 指令基类
/// </summary>
public class Say : Command
{
    public string Name;
    public string Image;
    public string Sound;
    public string Content;
}
/// <summary>
/// 背景音指令类: 继承指令基类
/// </summary>

public class Bgm : Command
{
    public string Name;
}
/// <summary>
/// 背景指令类：继承 指令基类
/// </summary>
public class Bg : Command
{
    public string Name;
}
/// <summary>
/// 对话系统
/// </summary>
public class DialogUI : MonoBehaviour
{
    public List<Command> Commands = new List<Command>();//声明一个List数组 类型为：Command
    private int _index = 0;//默认索引为0
    public GameObject GameImage;//游戏界面
    //public GameObject ReloadBut;//重开按钮
    //public Image BgImage; //背景图
    public Image HeadPortRait;//头像
    public Text NameText;//名字文本
    public Text ConttentText;//内容文本
    private bool _isExcute = true;//是否执行命令；默认不执行

    /// <summary>
    /// 初始化
    /// </summary>
    void Start()
    {
        AnalysisXml();//调用解析XMl方法
        //GameObject.Find("StartGameButton").GetComponent<Button>().onClick.AddListener(StartGame); //给开始游戏按钮，添加监听事件

    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0)&&_isExcute==true||Input.GetKeyDown(KeyCode.KeypadEnter)&&_isExcute==true)//如果按下鼠标左键或者按下Enter
        {
            OneByOneExecuteCommand();//执行对话命令函数
        }
    }
    /// <summary>
    /// 开始游戏
    /// </summary>
    public void StartGame()
    {
        GameImage.SetActive(true);
        _isExcute = true;
        OneByOneExecuteCommand();
    }
    /// <summary>
    /// 执行对话命令函数
    /// </summary>
    public void OneByOneExecuteCommand()
    {
        if (_index >= Commands.Count)//下标越界：读完
        {
            Debug.Log("结束了");
            GameImage.SetActive(false);
            //ReloadBut.SetActive(true);//激活重载按钮
            //ReloadBut.GetComponent<Button>().onClick.AddListener(ReloadScence);
            _isExcute = false;
            _index = 0;
            return;
        }
        Command command = Commands[_index++];//自增：取出一条命令
        switch (command.AllType)
        {
            //如果类型是：Say说话
            case CommandType.Say:
                Say say = (Say)command;//实例化Say对象say   强制类型转换吗？？？ 
                //HeadPortRait.sprite = Resources.Load<Sprite>(say.Image);//更换头像
                NameText.text = say.Name;//人物
                ConttentText.text = say.Content;//说话内容
                if (!string.IsNullOrEmpty(say.Sound))//如果音效名不为空
                {
                    AudioManger.Instance.PlaySe(say.Sound);//播放音效
                }
                break;
            //如果类型是Bgm背景音乐
            case CommandType.Bgm:
                Bgm bgm = (Bgm)command;
                AudioManger.Instance.PlayBgm(bgm.Name);
                OneByOneExecuteCommand();//直接执行下一条
                break;
            //如果类型是:Bg背景
            //case CommandType.Bg:
            //    Bg bg = (Bg)command;
            //    BgImage.sprite = Resources.Load<Sprite>(bg.Name);
            //    OneByOneExecuteCommand();
            //    break;
        }
    }
    /// <summary>
    /// 重载场景
    /// </summary>
    public void ReloadScence()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);//重载当前场景
    }
    /// <summary>
    /// 解析XML
    /// </summary>
    private void AnalysisXml()
    {
        XmlDocument document = new XmlDocument();//实例化一个xml文档    其实这里需要增加一个文件判断，路劲下是否有xml文件
        document.Load(Application.dataPath + "/Data/DialogUI.xml");//加载XML内容
        XmlElement rootEle = document.LastChild as XmlElement;//返回最后一个节点作为根节点
        foreach(XmlElement ele in rootEle.ChildNodes)//遍历根节点的所有子节点
        {
            if (ele.Name == "bgm")
            {
                Bgm bgm = new Bgm();
                bgm.AllType = CommandType.Bgm;
                bgm.Name = ele.InnerText;
                Commands.Add(bgm);//同时添加到命令数组Commands中
            }
            else if (ele.Name == "bg")
            {
                Bg bg = new Bg();
                bg.AllType = CommandType.Bg;
                bg.Name = ele.InnerText;
                Commands.Add(bg);
            }
            else if (ele.Name == "say")
            {
                Say say = new Say();
                say.AllType = CommandType.Say;
                say.Name = ele.ChildNodes[0].InnerText;
                say.Image = ele.ChildNodes[1].InnerText;
                say.Sound = ele.ChildNodes[2].InnerText;
                say.Content = ele.ChildNodes[3].InnerText;
                Commands.Add(say);
            }
        }
    }
}
