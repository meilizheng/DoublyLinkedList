using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoublyLinkedList
{
    public class DoublyLinkedList<T>
    {
        // Nested class LinkedListNode representing elements in the doubly linked list.
        class LinkedListNode<T>
        {
            // Data stored in the node.
            public T Value { get; set; }

            // Reference to the next node.
            public LinkedListNode<T> Next { get; set; }

            // Reference to the previous node.
            public LinkedListNode<T> Previous { get; set; } 

            public LinkedListNode(T value)
            {
                Value = value;
                Next = null;
                Previous = null;
            }
        }

        private LinkedListNode<T> head;
        private LinkedListNode<T> tail;
        private int count;

        // Gets the number of elements in the list.
        public int Count
        {
            get { return count; }
        }

        // Initializes a new instance of the DoublyLinkedList class.
        public DoublyLinkedList()
        {
            head = null;
            tail = null;
            count = 0;
        }

        // Add an element to the end of the list.
        public void Add(T value)
        {
            // Create a new node with the given value
            LinkedListNode<T> newNode = new LinkedListNode<T>(value);

            // If the list is empty, set the new node as both head and tail
            if (head == null)
            {
                head = newNode;
                tail = newNode;
            }
            else
            {
                // Set the new node's previous pointer to the current tail
                newNode.Previous = tail;
                // Update the current tail's next pointer to point to the new node
                tail.Next = newNode;
                // Update the tail to the new node
                tail = newNode;
            }
            // Increment the count of elements in the list
            count++;
        }

        // Display elements from head to tail.
        public void DisplayForward()
        {
            LinkedListNode<T> current = head;
            while (current != null)
            {
                Console.Write($"{current.Value} => ");
                current = current.Next;
            }
            Console.WriteLine("null");
        }

        // Display elements from tail to head.
        public void DisplayBackward()
        {
            LinkedListNode<T> current = tail;
            while (current != null)
            {
                Console.Write($"{current.Value} => ");
                current = current.Previous;
            }
            Console.WriteLine("null");
        }

        // Remove an element by value.
        public bool Remove(T value)
        {
            LinkedListNode<T> current = head;

            while (current != null)
            {
                if (current.Value.Equals(value))
                {
                    if (current == head) head = head.Next;
                    if (current == tail) tail = tail.Previous;
                    if (current.Next != null) current.Next.Previous = current.Previous;
                    if (current.Previous != null) current.Previous.Next = current.Next;

                    count--;
                    return true;
                }

                current = current.Next;
            }

            return false;
        }

        // Gets or sets the element at the specified index.
        public T this[int index]
        {
            get
            {
                if (index < 0 || index >= count)
                    throw new IndexOutOfRangeException();

                LinkedListNode<T> current = head;
                for (int i = 0; i < index; i++)
                    current = current.Next;

                return current.Value;
            }
        }

        // Insert an element at a specific index.
        public void InsertAtIndex(int index, T value)
        {
            // Check if the index is within valid bounds
            if (index < 0 || index > count)
            {
                throw new ArgumentOutOfRangeException(nameof(index), "Index is out of range.");
            }

            // Create a new node with the given value
            LinkedListNode<T> newNode = new LinkedListNode<T>(value);

            // Handle insertion at the beginning of the list
            if (index == 0)
            {
                newNode.Next = head;

                if (head != null)
                {
                    head.Previous = newNode;
                }

                head = newNode;

                if (count == 0)
                {
                    tail = newNode;
                }
            }
            // Handle insertion at the end of the list
            else if (index == count)
            {
                newNode.Previous = tail;
                tail.Next = newNode;
                tail = newNode;
            }
            // Handle insertion at any other index
            else
            {
                LinkedListNode<T> current = head;
                for (int i = 0; i < index - 1; i++)
                {
                    current = current.Next;
                }
                newNode.Next = current.Next;
                newNode.Previous = current;
                current.Next.Previous = newNode;
                current.Next = newNode;
            }
            // Increment the count of elements in the list
            count++;
        }

        // Insert an element at the beginning of the list.
        public void InsertAtFront(T value)
        {
            InsertAtIndex(0, value);
        }

        // Insert an element at the end of the list.
        public void InsertAtEnd(T value)
        {
            InsertAtIndex(count, value);
        }

        // Remove an element at a specific index.
        public void RemoveAtIndex(int index)
        {
            // Check if the index is within valid bounds
            if (index < 0 || index >= count)
            {
                throw new ArgumentOutOfRangeException(nameof(index), "Index is out of range.");
            }

            LinkedListNode<T> current = head;

            // If the index is 0, remove the first element
            if (index == 0)
            {
                head = current.Next;

                // If the list is not empty, update the previous pointer of the new head to null
                if (head != null)
                {
                    head.Previous = null;
                }
                // If the removed node was the only node in the list, update the tail to null
                if (count == 1)
                {
                    tail = null;
                }
            }
            // If the index is the last element, remove the last element
            else if (index == count - 1)
            {
                current = tail;
                tail = current.Previous;
                tail.Next = null;
            }
            // If the index is neither the first nor the last, remove the element in between
            else
            {
                for (int i = 0; i < index; i++)
                {
                    current = current.Next;
                }
                current.Previous.Next = current.Next;
                current.Next.Previous = current.Previous;
            }
            // Decrement the count of elements in the list
            count--;
        }

        // Remove the element at the beginning of the list.
        public void RemoveAtFront()
        {
            RemoveAtIndex(0);
        }

        // Remove the element at the end of the list.
        public void RemoveAtEnd()
        {
            RemoveAtIndex(count - 1);
        }

        // Clear the entire linked list, resetting it to an empty state.
        public void Clear()
        {
            head = null;
            tail = null;
            count = 0;
        }
    }
}
