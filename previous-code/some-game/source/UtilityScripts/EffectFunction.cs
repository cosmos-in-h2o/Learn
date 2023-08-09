/*
 * 某一动作造成某一效果效果的一些函数
 */

public class EffectFunction
{
    public static EffectFunction instance;
    public static EffectFunction Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new EffectFunction();
            }
            return instance;
        }
    }

    /// <summary>
    /// 回复血量
    /// </summary>
    public void restoreHP(float value)
    {
        PlayerAttribute.Instance.Now_HP+=value;
    }

    /// <summary>
    /// 减少血量
    /// </summary>
    public void reduceHP(float value)
    {
        PlayerAttribute.Instance.Now_HP-=value;
    }

    /// <summary>
    /// 回复梦境力
    /// </summary>
    public void restoreDP(float value)
    {
        PlayerAttribute.Instance.Now_DP += value;
    }

    /// <summary>
    /// 减少梦境力
    /// </summary>
    public void reduceDP(float value)
    {
        PlayerAttribute.Instance.Now_DP -= value;
    }

}