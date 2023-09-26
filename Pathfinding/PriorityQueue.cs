using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pathfinding
{
    //  I used this implementation: https://visualstudiomagazine.com/articles/2012/11/01/priority-queues-with-c.aspx
    //  It's a binary heap
    public class PriorityQueue<TElement, TPriority> where TPriority : IComparable<TPriority>
    {
        private readonly List<(TElement element, TPriority priority)> data = new List<(TElement element, TPriority priority)>();

        public int Count {  get { return data.Count; } }

        public void Enqueue(TElement element, TPriority priority)
        {
            data.Add((element, priority));
            int childIndex = data.Count - 1;

            while (childIndex > 0)
            {
                int parentIndex = (childIndex - 1) / 2;
                //If the parent and the child are in the right relative position, stop
                if (data[childIndex].CompareTo(data[parentIndex]) >= 0)
                    break;

                //Otherwise, swap them
                (TElement element, TPriority priority) temp = data[childIndex];
                data[childIndex] = data[parentIndex];
                data[parentIndex] = temp;
                childIndex = parentIndex;
            }
        }

        public TElement Dequeue()
        {
            if (data.Count == 0)
                throw new InvalidOperationException();

            int lastIndex = data.Count - 1;
            TElement frontItem = data[0].element;
            data[0] = data[lastIndex];
            data.RemoveAt(lastIndex);

            --lastIndex;
            int parentIndex = 0;
            while (true)
            {
                int childIndex = parentIndex * 2 + 1;
                //If we're at the end, stop
                if (childIndex > lastIndex) 
                    break;

                int rightChild = childIndex + 1;
                if (rightChild <= lastIndex && data[rightChild].CompareTo(data[childIndex]) < 0)
                    childIndex = rightChild;

                //If the parent and the child are in the right relative position, stop
                if (data[parentIndex].CompareTo(data[childIndex]) <= 0)
                    break;

                //Otherwise, swap them
                (TElement element, TPriority priority) temp = data[parentIndex];
                data[parentIndex] = data[childIndex];
                data[childIndex] = temp;
                parentIndex = childIndex;
            }
            return frontItem;
        }

        public TElement Peek() => data[0].element;
    }
}
