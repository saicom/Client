﻿//------------------------------------------------------------
// Game Framework
// Copyright © 2013-2020 Jiang Yin. All rights reserved.
// Homepage: https://gameframework.cn/
// Feedback: mailto:ellan@gameframework.cn
//------------------------------------------------------------

using Framework;
using System;
using System.Collections.Generic;
using Utils;

namespace Task
{
    /// <summary>
    /// 任务管理器。
    /// </summary>
    internal sealed class TaskManager : UnitySingleton<TaskManager>
    {
        private readonly SafeLinkedList<TaskBase> m_Tasks;
        private int m_Serial;

        /// <summary>
        /// 初始化任务管理器的新实例。
        /// </summary>
        public TaskManager()
        {
            m_Tasks = new SafeLinkedList<TaskBase>();
            m_Serial = 0;
        }

        /// <summary>
        /// 获取任务数量。
        /// </summary>
        public int Count
        {
            get
            {
                return m_Tasks.Count;
            }
        }

        /// <summary>
        /// 任务管理器轮询。
        /// </summary>
        public void Update()
        {
            LinkedListNode<TaskBase> current = m_Tasks.First;
            while (current != null)
            {
                TaskBase task = current.Value;
                if (task.Status == TaskStatus.Free)
                {
                    throw new Exception("Task status is invalid.");
                }

                if (task.Status == TaskStatus.Waiting)
                {
                    task.Status = TaskStatus.Running;
                    task.OnStart();
                }

                if (task.Status == TaskStatus.Running)
                {
                    task.OnUpdate();
                    current = current.Next;
                }
                else
                {
                    LinkedListNode<TaskBase> next = current.Next;
                    m_Tasks.Remove(current);
                    ReferencePool.Release(task);
                    current = next;
                }
            }
        }

        /// <summary>
        /// 关闭并清理任务管理器。
        /// </summary>
        void Shutdown()
        {
            CancelAllTasks();

            foreach (TaskBase task in m_Tasks)
            {
                ReferencePool.Release(task);
            }

            m_Tasks.Clear();
        }

        /// <summary>
        /// 生成任务。
        /// </summary>
        /// <typeparam name="T">任务的类型。</typeparam>
        /// <returns>生成的指定类型的任务。</returns>
        public T GenerateTask<T>() where T : TaskBase, new()
        {
            return GenerateTask<T>(TaskBase.DefaultPriority);
        }

        /// <summary>
        /// 生成任务。
        /// </summary>
        /// <typeparam name="T">任务的类型。</typeparam>
        /// <param name="priority">任务的优先级。</param>
        /// <returns>生成的指定类型的任务。</returns>
        public T GenerateTask<T>(int priority) where T : TaskBase, new()
        {
            T task = ReferencePool.Acquire<T>();
            task.Initialize(++m_Serial, priority);
            task.Status = TaskStatus.Waiting;
            task.Mono = this;
            task.OnGenerate();

            LinkedListNode<TaskBase> current = m_Tasks.First;
            while (current != null)
            {
                if (task.Priority > current.Value.Priority)
                {
                    break;
                }

                current = current.Next;
            }

            if (current != null)
            {
                m_Tasks.AddBefore(current, task);
            }
            else
            {
                m_Tasks.AddLast(task);
            }

            return task;
        }

        /// <summary>
        /// 取消任务。
        /// </summary>
        /// <param name="serialId">要取消的任务的序列编号。</param>
        /// <returns>是否取消任务成功。</returns>
        public bool CancelTask(int serialId)
        {
            foreach (TaskBase task in m_Tasks)
            {
                if (task.SerialId != serialId)
                {
                    continue;
                }

                if (task.Status != TaskStatus.Waiting && task.Status != TaskStatus.Running)
                {
                    return false;
                }


                task.Status = TaskStatus.Canceled;
                task.OnCancel();
                return true;
            }

            return false;
        }

        /// <summary>
        /// 取消任务。
        /// </summary>
        /// <param name="task">要取消的任务。</param>
        /// <returns>是否取消任务成功。</returns>
        public bool CancelTask(TaskBase task)
        {
            if (task == null)
            {
                throw new Exception("Task is invalid.");
            }

            return CancelTask(task.SerialId);
        }

        /// <summary>
        /// 取消任务。
        /// </summary>
        /// <param name="task">要取消的任务。</param>
        /// <param name="reason">任务取消的原因。</param>
        /// <returns>是否取消任务成功。</returns>
        public bool CancelTask(TaskBase task, string reason)
        {
            if (task == null)
            {
                throw new Exception("Task is invalid.");
            }

            return CancelTask(task.SerialId);
        }

        /// <summary>
        /// 取消所有任务。
        /// </summary>
        /// <param name="reason">任务取消的原因。</param>
        public void CancelAllTasks()
        {
            foreach (TaskBase task in m_Tasks)
            {
                if (task.Status != TaskStatus.Waiting && task.Status != TaskStatus.Running)
                {
                    continue;
                }

                task.OnCancel();
            }
        }
    }
}
