//------------------------------------------------------------
// Game Framework
// Copyright © 2013-2020 Jiang Yin. All rights reserved.
// Homepage: https://gameframework.cn/
// Feedback: mailto:ellan@gameframework.cn
//------------------------------------------------------------

using Framework;
using UnityEngine;

namespace Task
{
    /// <summary>
    /// 任务基类。
    /// </summary>
    public class TaskBase : IReference
    {
        /// <summary>
        /// 任务默认优先级。
        /// </summary>
        public const int DefaultPriority = 0;

        public MonoBehaviour Mono;
        private int m_SerialId;
        private int m_Priority;
        private TaskStatus m_Status;
        private object m_UserData;

        /// <summary>
        /// 初始化任务基类的新实例。
        /// </summary>
        public TaskBase()
        {
            m_SerialId = 0;
            m_Priority = DefaultPriority;
            m_Status = TaskStatus.Free;
            m_UserData = null;
        }

        /// <summary>
        /// 获取任务的序列编号。
        /// </summary>
        public int SerialId
        {
            get
            {
                return m_SerialId;
            }
        }

        /// <summary>
        /// 获取任务的优先级。
        /// </summary>
        public int Priority
        {
            get
            {
                return m_Priority;
            }
        }

        /// <summary>
        /// 获取任务的状态。
        /// </summary>
        public TaskStatus Status
        {
            get
            {
                return m_Status;
            }
            set
            {
                m_Status = value;
            }
        }

        /// <summary>
        /// 获取或设置用户自定义数据。
        /// </summary>
        public object UserData
        {
            get
            {
                return m_UserData;
            }
            set
            {
                m_UserData = value;
            }
        }

        /// <summary>
        /// 初始化任务基类。
        /// </summary>
        /// <param name="serialId">任务的序列编号。</param>
        /// <param name="priority">任务的优先级。</param>
        public void Initialize(int serialId, int priority)
        {
            m_SerialId = serialId;
            m_Priority = priority;
        }

        /// <summary>
        /// 清理任务基类。
        /// </summary>
        public virtual void Clear()
        {
            m_SerialId = 0;
            m_Priority = DefaultPriority;
            m_Status = TaskStatus.Free;
            m_UserData = null;
        }

        /// <summary>
        /// 任务生成时调用。
        /// </summary>
        public virtual void OnGenerate()
        {
        }

        /// <summary>
        /// 任务开始时调用。
        /// </summary>
        public virtual void OnStart()
        {
        }

        /// <summary>
        /// 任务轮询时调用。
        /// </summary>
        public virtual void OnUpdate()
        {
        }

        /// <summary>
        /// 任务完成时调用。
        /// </summary>
        public virtual void OnComplete()
        {
            m_Status = TaskStatus.Completed;
        }

        /// <summary>
        /// 任务失败时调用。
        /// </summary>
        public virtual void OnFailure()
        {
            m_Status = TaskStatus.Failed;
        }

        /// <summary>
        /// 任务取消时调用。
        /// </summary>
        public virtual void OnCancel()
        {
        }
    }
}
