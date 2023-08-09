/*
*用于更新ui文字
*挂载UIManager
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextUpdate : MonoBehaviour
{
	/// <summary>
	/// 经验文字
	/// </summary>
	public Text EXP_text;

	/// <summary>
	/// 货币数量
	/// </summary>
	public Text money_text;

	/// <summary>
	/// 时间文字
	/// </summary>
	public Text time_text;

	/// <summary>
	/// 中间闪烁的冒号
	/// </summary>
	public Text mid_text;

    private void Start()
    {
		StartCoroutine( Mid());
    }

    void Update()
	{
		//EXP_text.text = "EXP:" + PlayerAttribute.Instance.exp + "/" + PlayerAttribute.Instance.next_levels_need_EXP;
		money_text.text= BagSystem.m_coin.ToString();
		/*
		 * 如果小时数为个位
		 */
		if ((GameTime.Instance.time_in_game / 120) < 10)
		{
			//如果分钟数为个位
			if ((GameTime.Instance.time_in_game % 120)<10)
			{
				time_text.text = "0"+(GameTime.Instance.time_in_game / 120).ToString() + " 0" + (GameTime.Instance.time_in_game % 120).ToString();
			}
			else
            {
				time_text.text = "0" + (GameTime.Instance.time_in_game / 120).ToString() + " " + (GameTime.Instance.time_in_game % 120).ToString();
			}
		}
        else
        {
			//如果分钟数为个位
			if ((GameTime.Instance.time_in_game % 120)/2 < 10)
			{
				time_text.text = (GameTime.Instance.time_in_game / 120).ToString() + " 0" + ((GameTime.Instance.time_in_game % 120)/2).ToString();
			}
			else
			{
				time_text.text = (GameTime.Instance.time_in_game / 120).ToString() + " " + ((GameTime.Instance.time_in_game % 120)/2).ToString();
			}

		}
	}

	/// <summary>
	/// 中间的冒号闪烁
	/// </summary>
	/// <returns></returns>
	IEnumerator Mid()
    {
		while (true)
		{
			yield return new WaitForSeconds(0.5f);
			mid_text.gameObject.SetActive(!mid_text.gameObject.activeInHierarchy);
		}
    }
}
