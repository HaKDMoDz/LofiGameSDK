using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Xml.Serialization;
using Lofinil.Architecture;

namespace Lofinil.GameSDK.Engine
{
	// 支持序列化的组件列表容器
	public class GameComponentCollection : IComponentContainer
	{
		// 下面这种东西根本就不能加
		// [XmlElement(typeof(Sprite)), XmlElement(typeof(Transform)), XmlElement(typeof(FrameAnimator))]
		public List<GameComponent> CompList;

		public GameComponentCollection()
		{
			CompList = new List<GameComponent>();
		}

		public int  Add(GameComponent comp)
		{
			CompList.Add(comp);
			return 0;
		}

		public void  Clear()
		{
			CompList.Clear();
		}

		public bool Contains(GameComponent comp)
		{
			return CompList.Contains(comp);
		}

		public int IndexOf(GameComponent comp)
		{
			return CompList.IndexOf(comp);
		}

		public void Insert(int index, GameComponent comp)
		{
			CompList.Insert(index, comp);
		}

		public bool  IsFixedSize
		{
			get { return false; }
		}

		public bool  IsReadOnly
		{
			get { return false; }
		}

		public void Remove(GameComponent comp)
		{
			CompList.Remove(comp);
		}

		public void  RemoveAt(int index)
		{
			CompList.RemoveAt(index);
		}

		public GameComponent  this[int index]
		{
			  get 
			{
				return CompList[index];
			}
			  set 
			{
				CompList[index] = value; 
			}
		}

		public void  CopyTo(GameComponent[] array, int index)
		{
			CompList.CopyTo(array, index);
		}

		public int  Count
		{
			get { return CompList.Count; }
		}

		public bool  IsSynchronized
		{
			get { return true; }
		}

		public object  SyncRoot
		{
			get { return this; }
		}

		public IEnumerator GetEnumerator()
		{
			return CompList.GetEnumerator();
		}

        void IComponentContainer.Add(IComponent component)
        {
            if (component is GameComponent)
                Add((GameComponent)component);
        }

        void IComponentContainer.Remove(IComponent component)
        {
            if (component is GameComponent)
                Remove((GameComponent)component);
        }

        public T QueryComponent<T>() 
            where T : GameComponent
        {
            foreach (GameComponent component in this)
            {
                if (component is T)
                    return (T)component;
            }
            return default(T);
        }

        public void AddRange(GameComponent[] items)
        {
            if(items == null)
                return;

            foreach (GameComponent c in items)
            {
                Add(c);
            }
        }

        public GameComponent[] ToArray()
        {
            return CompList.ToArray();
        }
    }
}
