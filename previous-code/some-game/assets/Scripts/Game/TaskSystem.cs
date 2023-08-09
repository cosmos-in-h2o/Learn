/*
 * 任务系统 
 * 挂载在TaskManager
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

//以下为任务系统后端思路及注意事项
/*
 * 任务系统思路：
 * 先创建一个TaskItem类，类中包括一个任务需求列表，任务ID
 * 然后创建一个任务列表类用来存放整个任务流程，任务类型
 * 然后在TaskSystem中创建一个当前已接任务总列表，在封装一些函数对其进行操作
 */

/*
 * 重新理清下思路(不能用指针真是太难受了，不然实现起来又快速又简单运行还快)
 * 和刚刚想的又些许差别
 * 一共分为了三个层级
 * 1.最高层级：Task指的是单个任务
 * 2.第二层级：TaskStep指的是单个任务里的单个步骤
 * 3.第三层及：TaskFlow指的是单个任务里的单个步骤里的单个流程，这里是同时进行的
 * 然后TaskSystem作为一个单例封装了一个Task的list以和其他操作本list的函数及所需数据
 */

/*
 * 任务系统ID规则：
 * 在TaskSystem中的 now_task_ID -> 单个TaskFlow
 * 命名规则：
 * abcdefghi
 * TaskID：
 * a==1 代表现在线任务
 * a==2 代表往事线任务
 * a==3 代表支线任务
 * bcd 组成的数字代表本任务在所属线的唯一ID
 * TaskStepID：
 * abcd 组成的数字是所属Task的ID
 * ef 组成的数字代表本步骤在所属任务的唯一ID
 * g 是分支选项
 * TaskFlowID：
 * abcdefg 组成的数字是所属TaskStep的ID
 * hi 组成的数字代表本流程在所属步骤的唯一ID
 */

/*
 * 写出来不太一样
 * 没考虑到分支
 * 现在的结构：
 * TaskSystem.tasks->task->step-branch->flow
 * 如果flow全部完成则step完成
 * 如果单个branch完成则step视为完成
 * 如果全部step完成则task完成
 */

[Serializable]
public class TaskFlow
{
    public string flow_name;//任务简述
    public int flow_ID;//此步的ID
    public bool is_complete;//此流程是否完成
}

[Serializable]
public class TaskBranch
{
    public string task_step_name;
    public int task_branch_ID;
    [TextArea]
    public string task_intro;
    //taskstep的step
    public List<TaskFlow> task_flows;
}

[Serializable]
public class TaskStep
{
    public int task_step_Id;
    public bool task_step_is_complete;//当前步骤是否完成
    public List<TaskBranch> steps_branch;//步骤分支
}

[Serializable]
public class Task
{
    public string task_name;//任务名称
    public int task_ID;//任务ID
    public bool task_is_complete;//任务是否完成
    [TextArea]
    public string task_intro;//总的介绍
    public List<TaskStep> task_steps;//任务的分支
}

public class TaskSystem : MonoBehaviour
{
    //单例模式
    private static TaskSystem instance;
    public static TaskSystem Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType(typeof(TaskSystem)) as TaskSystem;
            }
            return instance;
        }
    }

    public event Action onTaskListChanged;
    public event Action onNowTaskChanged;

    public List<Task> all_tasks;//所有的task

    private List<Task> tasks = new List<Task>();

    private TaskFlow now_task_ID;

    //添加一个任务
    public void addTask(int task_ID)
    {
        //后端
        int task_type = task_ID / 100000000 % 10;
        int task_index_in_this_line = task_ID / 10000000 % 10 * 100 + task_ID / 1000000 % 10 * 10 + task_ID / 100000 % 10;
        int task_step_index = task_ID / 10000 % 10 * 10 + task_ID / 1000 % 10;
        int task_step_branch_index = task_ID / 100;
        int task_flow_index = task_ID / 10 % 10 * 10 + task_ID % 10;

        tasks.Add(all_tasks[task_index_in_this_line]);
        Instance.onTaskListChanged?.Invoke();
        //前端
    }

    //添加一个任务
    public void addTask(Task task)
    {
        //后端
        tasks.Add(task);
        Instance.onTaskListChanged?.Invoke();
        //前端
    }

    //移除一个任务
    public void removeTask(int task_index)
    {
        //后端
        tasks.RemoveAt(task_index);
        Instance.onTaskListChanged?.Invoke();
        //前端

    }

    //移除一个任务
    public void removeTask(Task task)
    {
        //后端
        tasks.Remove(task);
        Instance.onTaskListChanged?.Invoke();
        //前端

    }

    //完成一个流程
    public void completeTaskFlow(TaskFlow task_flow, Action callBack, Action taskComplete, Action stepComplete)
    {
        //完成本流程先将流程设置为完成然后回调完成步骤函数
        task_flow.is_complete = true;
        callBack();
        int task_index = task_flow.flow_ID / 10000000 % 10 * 100 + task_flow.flow_ID / 1000000 % 10 * 10 + task_flow.flow_ID / 100000 % 10;
        int task_step_index = task_flow.flow_ID / 10000 % 10 * 10 + task_flow.flow_ID / 1000 % 10;
        int task_step_branch_index = task_flow.flow_ID / 100;
        int task_flow_index = task_flow.flow_ID / 10 % 10 * 10 + task_flow.flow_ID % 10;

        //如果当前流程是此任务中此步骤中的最后一个
        if (Instance.all_tasks[task_index].task_steps[task_step_index].steps_branch[task_step_branch_index].task_flows.Count == task_flow_index + 1)
        {
            //先将当前步骤设为完成,然后回调函数
            int task_index_in_list = Instance.tasks.IndexOf(Instance.all_tasks[task_index]);//任务在任务列表的位置
            Instance.tasks[task_index_in_list].task_steps[task_step_index].task_step_is_complete = true;
            //如果当前步骤是此任务中最后一个
            if (Instance.all_tasks[task_index].task_steps[task_step_index].steps_branch.Count == task_step_index + 1)
            {
                //先将这个任务设置为完成然后移出当前任务列表，最后回调函数
                Instance.all_tasks[task_index].task_is_complete = true;
                Instance.removeTask(task_index_in_list);
                if (task_index != all_tasks.Count + 1)
                {
                    Instance.tranceTask(Instance.all_tasks[task_index+1].task_steps[0].steps_branch[0].task_flows[0]);
                }
                taskComplete();
            }
            else
            {
                //如果不是最后一个就指向下一个
                Instance.tranceTask(Instance.all_tasks[task_index].task_steps[task_step_index].steps_branch[task_step_branch_index].task_flows[task_flow_index+1]);
                stepComplete();
            }
        }
    }

    //开始追踪任务
    public void tranceTask(TaskFlow task_flow)
    {
        //后端
        Instance.now_task_ID = task_flow;
        Instance.onNowTaskChanged?.Invoke();
        //前端

    }

    //开始追踪任务
    public void tranceTask(int task_ID)
    {
        //后端
        Instance.now_task_ID = Instance.getTaskFlow(task_ID);
        Instance.onNowTaskChanged?.Invoke();
        //前端

    }

    //获取task,step,branch,flow的类型
    public int getTaskType(int ID)
    {
        return ID / 100000000 % 10;
    }

    //获取task
    public Task getTask(int ID)
    {
        int task_index = ID / 10000000 % 10 * 100 + ID / 1000000 % 10 * 10 + ID / 100000 % 10;
        return Instance.all_tasks[task_index];
    }

    //获取step
    public TaskStep getTaskStep(int ID)
    {
        int task_index = ID / 10000000 % 10 * 100 + ID / 1000000 % 10 * 10 + ID / 100000 % 10;
        int task_step_index = ID / 10000 % 10 * 10 + ID / 1000 % 10;
        return Instance.all_tasks[task_index].task_steps[task_step_index];
    }

    //获取branch
    public TaskBranch getTaskBranch(int ID)
    {
        int task_index = ID / 10000000 % 10 * 100 + ID / 1000000 % 10 * 10 + ID / 100000 % 10;
        int task_step_index = ID / 10000 % 10 * 10 + ID / 1000 % 10;
        int task_step_branch_index = ID / 100;
        return Instance.all_tasks[task_index].task_steps[task_step_index].steps_branch[task_step_branch_index];
    }

    //获取flow
    public TaskFlow getTaskFlow(int ID)
    {
        int task_index = ID / 10000000 % 10 * 100 + ID / 1000000 % 10 * 10 + ID / 100000 % 10;
        int task_step_index = ID / 10000 % 10 * 10 + ID / 1000 % 10;
        int task_step_branch_index = ID / 100;
        int task_flow_index = ID / 10 % 10 * 10 + ID % 10;
        return Instance.all_tasks[task_index].task_steps[task_step_index].steps_branch[task_step_branch_index].task_flows[task_flow_index];
    }

    //更新任务列表
    public void undateTaskMenu()
    {
        //后端

        //前端

    }
}