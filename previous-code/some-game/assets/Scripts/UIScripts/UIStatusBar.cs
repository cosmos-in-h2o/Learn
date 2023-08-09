/*
* 实现血条随血量变化而变化
* 挂载在血条上
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class UIStatusBar : MonoBehaviour
{
	public Image bar;//血条图像

	public Image fade;//虚血图像

	public float lerp_speed;//虚血速度

	//血条类型
	public enum BarType
    {
	    HP,
        DP,
        EXP,
        weapons_skills,
        dream_skills
    }

    public BarType bar_type;
	////具体实现
 //   void HPBarFiller()
 //   {
 //       bar.fillAmount = PlayerAttribute.Instance.now_HP / PlayerAttribute.Instance.max_HP;
 //       fade.fillAmount = Mathf.Lerp(fade.fillAmount, PlayerAttribute.Instance.now_HP / PlayerAttribute.Instance.max_HP, lerp_speed*Time.deltaTime);//��ֵ����Ѫ
 //   }
	////具体实现
 //   void DPBarFiller()
 //   {
 //       bar.fillAmount = PlayerAttribute.Instance.now_DP / PlayerAttribute.Instance.max_DP;
 //       fade.fillAmount = Mathf.Lerp(fade.fillAmount, PlayerAttribute.Instance.now_DP / PlayerAttribute.Instance.max_DP, lerp_speed * Time.deltaTime);//��ֵ����Ѫ
 //   }
	////具体实现
 //   void EXPBarFiller()
 //   {
 //       bar.fillAmount = PlayerAttribute.Instance.exp / PlayerAttribute.Instance.next_levels_need_EXP;
 //   }

 //   private void Update()
	//{
	//	//判断类型然后调用对应函数
 //       if(bar_type==BarType.HP)
 //       {
 //           HPBarFiller();
 //       }
 //       if(bar_type==BarType.DP)
 //       {
 //           DPBarFiller();
 //       }
 //       if (bar_type == BarType.EXP)
 //       {
 //           EXPBarFiller();
 //       }
 //   }
}