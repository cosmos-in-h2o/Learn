/*
 * 代码作用：管理输入
 * 挂载：__Main__
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InputManager : MonoBehaviour
{
    //单例模式
    private static InputManager instance;
    public static InputManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType(typeof(InputManager)) as InputManager;
            }
            return instance;
        }
    }
    public Transform VR_phone;
    public Transform bag;
    public static bool is_paused = false;

    public static bool is_phone = false;
    public static bool is_bag = false;
    
    [Header("input key")]
    public KeyCode Front_key = KeyCode.W;//向前走
    public KeyCode Down_key = KeyCode.S;//向后走
    public KeyCode Right_key = KeyCode.D;//向右走
    public KeyCode Left_key = KeyCode.A;//向左走

    public KeyCode Bag_key = KeyCode.B;//打开背包
    public KeyCode VRPhone_key = KeyCode.V;//打开VRPhone
    public KeyCode Quit_key = KeyCode.Escape;//退出

    [Header("info控件")]
    public Text info_text;
    public Image info_image;
	public Text info_name;
	public Button info_button;
	public Text button_text;
	public Transform now_box;

    //回复默认设置
    public void updateIps()
    {
        Instance.Front_key = KeyCode.W;//向前走
        Instance.Down_key = KeyCode.S;//向后走
        Instance.Right_key = KeyCode.D;//向右走
        Instance.Left_key = KeyCode.A;//向左走

        Instance.Bag_key = KeyCode.B;//打开背包
        Instance.VRPhone_key = KeyCode.V;//打开VRPhone
        Instance.Quit_key = KeyCode.Escape;//退出
    }
    void Start()
    {
        //开始时关闭两个界面
        VR_phone.gameObject.SetActive(false);
        bag.gameObject.SetActive(false);

        now_box.gameObject.SetActive(false);
    }

    void Update()
    {
        //当输入V,就打开VR
        if (Input.GetKeyDown(Instance.VRPhone_key))
        {
            if (is_phone)
            {
                Instance.VRPhoneClose();
            }
            else
            {
                if (is_bag)
                {
                    Instance.bagClose();
                }
                Instance.VRPhoneOpen();
            }
        }
        //当输入B没有打开背包与VR就开启背包
        if (Input.GetKeyDown(Instance.Bag_key))
        {
            if(is_bag)
            {
                Instance.bagClose();
            }
            else
            {
                if (is_phone)
                {
                    Instance.VRPhoneClose();
                }
                Instance.bagOpen();
            }
        }
        //当输入ese时
        if(Input.GetKeyDown(Instance.Quit_key))
        {
            if (UIManager.Instance.tap_list.Count > 0 && UIManager.Instance.tap_list[UIManager.Instance.tap_list.Count - 1] == bag)
            {
                is_bag = false;
            }
            else if (UIManager.Instance.tap_list.Count > 0 && UIManager.Instance.tap_list[UIManager.Instance.tap_list.Count - 1] == VR_phone)
            {
                is_phone = false;
            }
            UIManager.Instance.removeTapInList(() =>
            {
                Instance.openQuitMenu();
            });
        }
    }

    private void openQuitMenu()
    {

    }

    //打开VR方法
    private void VRPhoneOpen()
    {
        is_phone = true;
        VR_phone.gameObject.SetActive(true);
        UIManager.Instance.addTapInList(Instance.VR_phone);
    }
    //关闭VR方法
    private void VRPhoneClose()
    {
        is_phone = false;
        VR_phone.gameObject.SetActive(false);
        for (int i = UIManager.Instance.tap_list.IndexOf(VR_phone); i<UIManager.Instance.tap_list.Count ; i++)
        {
            UIManager.Instance.tap_list.RemoveAt(i);
        }
    }

    //打开背包方法
    private void bagOpen()
    {
        is_paused = true;
        is_bag = true;
        Instance.info_image.gameObject.SetActive(false);
        Instance.info_text.gameObject.SetActive(false);
        Instance.info_name.gameObject.SetActive(false);
        Instance.info_button.gameObject.SetActive(false);
        Instance.button_text.gameObject.SetActive(false);
        Instance.now_box.gameObject.SetActive(false);
        Instance.bag.gameObject.SetActive(true);
        UIManager.Instance.addTapInList(Instance.bag);
        Time.timeScale = 0f;
    }
    //关闭背包方法
    private void bagClose()
    {
        is_paused = false;
        is_bag=false;
        Instance.bag.gameObject.SetActive(false);
        for (int i = UIManager.Instance.tap_list.IndexOf(bag); i < UIManager.Instance.tap_list.Count; i++)
        {
            UIManager.Instance.tap_list.RemoveAt(i);
        }
        Time.timeScale = 1f;
    }
	//关闭info组件
	public void closeInfo()
	{
        Instance.info_image.gameObject.SetActive(false);
        Instance.info_text.gameObject.SetActive(false);
        Instance.info_name.gameObject.SetActive(false);
        Instance.info_button.gameObject.SetActive(false);
        Instance.button_text.gameObject.SetActive(false);
        Instance.now_box.gameObject.SetActive(false);
	}
}