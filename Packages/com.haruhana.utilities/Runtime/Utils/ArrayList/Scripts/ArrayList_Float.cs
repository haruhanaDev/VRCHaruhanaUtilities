
using System;
using UdonSharp;
using VRC.SDK3.Data;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;

namespace Haruhana.Utils.ArrayList
{
    public class ArrayList_Float : UdonSharpBehaviour
    {
        private float[] Arrays = new float[64];
        public int Count {get; private set;} = 0;
        public int Capacity {get; private set;} = 64;

        public float this[int param]
        {
            get => Get(param);
            set => Set(param, value);
        }

        public float Get(int index)
        {
            return Arrays[index];
        }
        public void Set(int index, float value)
        {
            Arrays[index] = value;
        }

        public void Add(float value)
        {
            Arrays[Count] = value;

            Count++;
        }
        public void Insert(int index, float value)
        {
            Array.Copy(Arrays, index, Arrays, index+1, Count-index);

            Arrays[index] = value;

            Count++;
        }
        public void Remove(float value)
        {
            var index = IndexOf(value);

            if (index != -1)
            {
                RemoveAt(index);
            }
        }
        public void RemoveAt(int index)
        {
            Array.Copy(Arrays, index+1, Arrays, index, Count-(index+1));
            Arrays[Count] = default;
            Count--;
        }
        public bool Contain(float value)
        {
            return IndexOf(value) != -1;
        }
        public int IndexOf(float value)
        {
            for (int i = 0; i < Count; i++)
            {
                if (Arrays[i].Equals(value))
                {
                    return i;
                }
            }

            return -1;
        }
        public void Clear(int size)
        {
            Capacity = size;
            Arrays = new float[size];
            Count = 0;
        }
        public void Clear() => Clear(Capacity);

        public DataList ToDataList()
        {
            DataList dataList;
            ToDataList(out dataList);
            return dataList;
        }
        public void ToDataList(out DataList dataList)
        {
            dataList = new DataList();

            for (int i = 0; i < Count; i++)
            {
                dataList.Add(new DataToken(Arrays[i]));
            }
        }

        //public void Reverse()
        //{
        //    
        //}
    }
}
