using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using DG.Tweening;
using UnityEngine.UI;

public class SensesChanged : MonoBehaviour
{
    public static Transform _transform;

    /// <summary>
    /// 透明过渡到不透明在过渡到透明
    /// </summary>
    /// <param name="time">所需时间</param>
    /// <param name="role">渐变规则,传入的是停留时间权重，变为透明的时间和变为不透明的时间为time*((1f - role) / 2)</param>
    public static void unLookToLookToUnLook(float time = 1.0f,float role= 0.6f )
    {
        Sequence sequence = DOTween.Sequence();//初始化一个Sequence
        sequence.AppendCallback(() => { _transform.gameObject.SetActive(true); });
        sequence.Append(_transform.GetComponent<Image>().DOFade(1, time * ((1f - role) / 2)));//在尾部添加一个操作
        sequence.AppendInterval(time * role);//等待一定时间
        sequence.Append(_transform.GetComponent<Image>().DOFade(0, time * ((1f - role) / 2)));//在尾部添加一个操作
        sequence.AppendCallback(() => { _transform.gameObject.SetActive(false); });
    }

    /// <summary>
    /// 透明过渡到不透明在过渡到透明
    /// </summary>
    /// <param name="time">所需时间</param>
    /// <param name="action">在开始前的回调函数</param>
    /// <param name="role">渐变规则,传入的是停留时间权重，变为透明的时间和变为不透明的时间为time*((1f - role) / 2)</param>
    public static void unLookToLookToUnLook(Action action, float time = 1.0f, float role = 0.6f)
    {
        Sequence sequence = DOTween.Sequence();//初始化一个Sequence
        sequence.AppendCallback(() => 
        { 
            action();
            _transform.gameObject.SetActive(true);
        });
        sequence.Append(_transform.GetComponent<Image>().DOFade(1, time * ((1f - role) / 2)));//在尾部添加一个操作
        sequence.AppendInterval(time * role);//等待一定时间
        sequence.Append(_transform.GetComponent<Image>().DOFade(0, time * ((1f - role) / 2)));//在尾部添加一个操作
        sequence.AppendCallback(() => { _transform.gameObject.SetActive(false); });
    }

    /// <summary>
    /// 透明过渡到不透明在过渡到透明
    /// </summary>
    /// <param name="time">所需时间</param>
    /// <param name="action">在结束后的回调函数</param>
    /// <param name="role">渐变规则,传入的是停留时间权重，变为透明的时间和变为不透明的时间为time*((1f - role) / 2)</param>
    public static void unLookToLookToUnLook(float time,Action action, float role = 0.6f)
    {
        Sequence sequence = DOTween.Sequence();//初始化一个Sequence
        sequence.AppendCallback(() => { _transform.gameObject.SetActive(true); });
        sequence.Append(_transform.GetComponent<Image>().DOFade(1, time * ((1f - role) / 2)));//在尾部添加一个操作
        sequence.AppendInterval(time * role);//等待一定时间
        sequence.Append(_transform.GetComponent<Image>().DOFade(0, time * ((1f - role) / 2)));//在尾部添加一个操作
        sequence.AppendCallback(() => 
        {
            action();
            _transform.gameObject.SetActive(false);
        });
    }

    /// <summary>
    /// 透明过渡到不透明在过渡到透明
    /// </summary>
    /// <param name="action">在结束后的回调函数</param>
    /// <param name="role">渐变规则,传入的是停留时间权重，变为透明的时间和变为不透明的时间为time*((1f - role) / 2)</param>
    public static void unLookToLookToUnLook(Action action, float role = 0.6f)
    {
        Sequence sequence = DOTween.Sequence();//初始化一个Sequence
        sequence.AppendCallback(() => { _transform.gameObject.SetActive(true); });
        sequence.Append(_transform.GetComponent<Image>().DOFade(1, ((1f - role) / 2)));//在尾部添加一个操作
        sequence.AppendInterval(role);//等待一定时间
        sequence.Append(_transform.GetComponent<Image>().DOFade(0, ((1f - role) / 2)));//在尾部添加一个操作
        sequence.AppendCallback(() =>
        {
            _transform.gameObject.SetActive(false);
            action();
        });
    }

    /// <summary>
    /// 透明过渡到不透明在过渡到透明
    /// </summary>
    /// <param name="time">所需时间</param>
    /// <param name="action1">在开始前的回调函数</param>
    /// <param name="action2">在结束后的回调函数</param>
    /// <param name="role">渐变规则,传入的是停留时间权重，变为透明的时间和变为不透明的时间为time*((1f - role) / 2)</param>
    public static void unLookToLookToUnLook(Action action1,float time, Action action2, float role = 0.6f)
    {
        Sequence sequence = DOTween.Sequence();//初始化一个Sequence
        sequence.AppendCallback(() => 
        {
            action1();
            _transform.gameObject.SetActive(true); 
        });
        sequence.Append(_transform.GetComponent<Image>().DOFade(1, time * ((1f - role) / 2)));//在尾部添加一个操作
        sequence.AppendInterval(time * role);//等待一定时间
        sequence.Append(_transform.GetComponent<Image>().DOFade(0, time * ((1f - role) / 2)));//在尾部添加一个操作
        sequence.AppendCallback(() =>
        {
            _transform.gameObject.SetActive(false);
            action2();
        });
    }

    /// <summary>
    /// 透明过渡到不透明在过渡到透明
    /// </summary>
    /// <param name="action1">在开始前的回调函数</param>
    /// <param name="action2">在结束后的回调函数</param>
    /// <param name="role">渐变规则,传入的是停留时间权重，变为透明的时间和变为不透明的时间为time*((1f - role) / 2)</param>
    public static void unLookToLookToUnLook(Action action1, Action action2, float role = 0.6f)
    {
        Sequence sequence = DOTween.Sequence();//初始化一个Sequence
        sequence.AppendCallback(() =>
        {
            action1();
            _transform.gameObject.SetActive(true);
        });
        sequence.Append(_transform.GetComponent<Image>().DOFade(1, ((1f - role) / 2)));//在尾部添加一个操作
        sequence.AppendInterval(role);//等待一定时间
        sequence.Append(_transform.GetComponent<Image>().DOFade(0, ((1f - role) / 2)));//在尾部添加一个操作
        sequence.AppendCallback(() =>
        {
            _transform.gameObject.SetActive(false);
            action2();

        });
    }

    private void Start()
    {
        _transform = transform;
        if (gameObject.activeInHierarchy)
        {
            gameObject.SetActive(false);
        }
    }
}