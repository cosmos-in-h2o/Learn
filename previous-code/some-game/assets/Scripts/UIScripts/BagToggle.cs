/*
*代码作用：实现选项卡切换
*挂载：BG
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BagToggle : MonoBehaviour
{
	Transform equip;
	Transform food;
	Transform dream;
	Transform books;
	Transform materia;
	Transform another;
	Transform blue_print_and_collectibles;
	
	public Sprite equip_false;
	public Sprite equip_true;

	public Sprite food_false;
	public Sprite food_true;
	
	public Sprite dream_false;
	public Sprite dream_true;
	
	public Sprite books_false;
	public Sprite books_true;
	
	public Sprite materia_false;
	public Sprite materia_true;
	
	public Sprite blue_print_and_collectibles_false;
	public Sprite blue_print_and_collectibles_true;
	
	public Sprite another_false;
	public Sprite another_true;
	
	public Image equip_image;
	public Image food_image;
	public Image dream_image;
	public Image books_image;
	public Image materia_image;
	public Image blue_print_and_collectibles_image;
	public Image another_image;
	
	public enum NowToggle{
		equip,
		food,
		dream,
		books,
		materia,
		blue_print_and_collectibles,
		another
	}
	
	public static NowToggle now_toggle;
	
	void Start()
	{
		equip=gameObject.transform.GetChild(0).gameObject.transform;
		food=gameObject.transform.GetChild(1).gameObject.transform;
		dream=gameObject.transform.GetChild(2).gameObject.transform;
		books=gameObject.transform.GetChild(3).gameObject.transform;
		materia=gameObject.transform.GetChild(4).gameObject.transform;
		blue_print_and_collectibles=gameObject.transform.GetChild(5).gameObject.transform;
		another=gameObject.transform.GetChild(6).gameObject.transform;
		openEquip();
		
	}
	
	//当装备界面被打开
	public void openEquip()
	{
		equip.gameObject.SetActive(true);
		food.gameObject.SetActive(false);
		dream.gameObject.SetActive(false);
		books.gameObject.SetActive(false);
		materia.gameObject.SetActive(false);
		blue_print_and_collectibles.gameObject.SetActive(false);
		another.gameObject.SetActive(false);
		
		equip_image.sprite=equip_true;
		food_image.sprite=food_false;
		dream_image.sprite=dream_false;
		books_image.sprite=books_false;
		materia_image.sprite=materia_false;
		blue_print_and_collectibles_image.sprite=blue_print_and_collectibles_false;
		another_image.sprite=another_false;
		now_toggle=NowToggle.equip;
	}
	
	//当食物界面被打开
	public void openFood()
	{
		equip.gameObject.SetActive(false);
		food.gameObject.SetActive(true);
		dream.gameObject.SetActive(false);
		books.gameObject.SetActive(false);
		materia.gameObject.SetActive(false);
		blue_print_and_collectibles.gameObject.SetActive(false);
		another.gameObject.SetActive(false);
		
		equip_image.sprite=equip_false;
		food_image.sprite=food_true;
		dream_image.sprite=dream_false;
		books_image.sprite=books_false;
		materia_image.sprite=materia_false;
		blue_print_and_collectibles_image.sprite=blue_print_and_collectibles_false;
		another_image.sprite=another_false;
		now_toggle=NowToggle.food;
	}
	
	//当梦界面被打开
	public void openDream()
	{
		equip.gameObject.SetActive(false);
		food.gameObject.SetActive(false);
		dream.gameObject.SetActive(true);
		books.gameObject.SetActive(false);
		materia.gameObject.SetActive(false);
		blue_print_and_collectibles.gameObject.SetActive(false);
		another.gameObject.SetActive(false);
		
		equip_image.sprite=equip_false;
		food_image.sprite=food_false;
		dream_image.sprite=dream_true;
		books_image.sprite=books_false;
		materia_image.sprite=materia_false;
		blue_print_and_collectibles_image.sprite=blue_print_and_collectibles_false;
		another_image.sprite=another_false;
		now_toggle=NowToggle.dream;
	}
	
	//当书界面被打开
	public void openBooks()
	{
		equip.gameObject.SetActive(false);
		food.gameObject.SetActive(false);
		dream.gameObject.SetActive(false);
		books.gameObject.SetActive(true);
		materia.gameObject.SetActive(false);
		blue_print_and_collectibles.gameObject.SetActive(false);
		another.gameObject.SetActive(false);
		
		equip_image.sprite=equip_false;
		food_image.sprite=food_false;
		dream_image.sprite=dream_false;
		books_image.sprite=books_true;
		materia_image.sprite=materia_false;
		blue_print_and_collectibles_image.sprite=blue_print_and_collectibles_false;
		another_image.sprite=another_false;
		now_toggle=NowToggle.books;
	}
	
	//当材料界面被打开
	public void openMateria()
	{
		equip.gameObject.SetActive(false);
		food.gameObject.SetActive(false);
		dream.gameObject.SetActive(false);
		books.gameObject.SetActive(false);
		materia.gameObject.SetActive(true);
		blue_print_and_collectibles.gameObject.SetActive(false);
		another.gameObject.SetActive(false);
		
		equip_image.sprite=equip_false;
		food_image.sprite=food_false;
		dream_image.sprite=dream_false;
		books_image.sprite=books_false;
		materia_image.sprite=materia_true;
		blue_print_and_collectibles_image.sprite=blue_print_and_collectibles_false;
		another_image.sprite=another_false;
		now_toggle=NowToggle.materia;
	}
	
	//当藍圖或收藏品界面被打开
	public void openBluePrintAndCollectibles()
	{
		equip.gameObject.SetActive(false);
		food.gameObject.SetActive(false);
		dream.gameObject.SetActive(false);
		books.gameObject.SetActive(false);
		materia.gameObject.SetActive(false);
		blue_print_and_collectibles.gameObject.SetActive(true);
		another.gameObject.SetActive(false);
		
		equip_image.sprite=equip_false;
		food_image.sprite=food_false;
		dream_image.sprite=dream_false;
		books_image.sprite=books_false;
		materia_image.sprite=materia_false;
		blue_print_and_collectibles_image.sprite=blue_print_and_collectibles_true;
		another_image.sprite=another_false;
		now_toggle=NowToggle.blue_print_and_collectibles;
	}
	
	//当其他界面被打开
	public void openAnother()
	{
		equip.gameObject.SetActive(false);
		food.gameObject.SetActive(false);
		dream.gameObject.SetActive(false);
		books.gameObject.SetActive(false);
		materia.gameObject.SetActive(false);
		blue_print_and_collectibles.gameObject.SetActive(false);
		another.gameObject.SetActive(true);
		
		equip_image.sprite=equip_false;
		food_image.sprite=food_false;
		dream_image.sprite=dream_false;
		books_image.sprite=books_false;
		materia_image.sprite=materia_false;
		blue_print_and_collectibles_image.sprite=blue_print_and_collectibles_false;
		another_image.sprite=another_true;
		now_toggle=NowToggle.another;
	}
}
