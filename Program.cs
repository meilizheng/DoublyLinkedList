namespace DoublyLinkedList
{
    internal class Program
    {
        static void Main(string[] args)
        {
            DoublyLinkedList<int> linkedList = new DoublyLinkedList<int>();

            // Add elements
            linkedList.Add(1);
            linkedList.Add(2);
            linkedList.Add(3);
            linkedList.Add(4);

            // Display forward and backward
            Console.WriteLine("Forward:");
            linkedList.DisplayForward();
            Console.WriteLine("Backward:");
            linkedList.DisplayBackward();

            // Remove an element
            if (linkedList.Remove(2))
                Console.WriteLine("2 removed");

            // Access element by index
            Console.WriteLine($"Element at index 1: {linkedList[1]}");

            // Insert elements at specific positions
            linkedList.InsertAtIndex(1, 6); // Insert 25 at index 1
            linkedList.InsertAtFront(5);     // Insert 5 at the beginning
            linkedList.InsertAtEnd(55);      // Insert 35 at the end

            // Display forward after insertion
            Console.WriteLine("Forward (after insertion):");
            linkedList.DisplayForward();

            // Remove elements at specific positions
            linkedList.RemoveAtFront(); // Remove the first element
            linkedList.RemoveAtEnd();   // Remove the last element
            linkedList.RemoveAtIndex(2); // Remove the element at index 2

            // Display forward after removal
            Console.WriteLine("Forward (after removal):");
            linkedList.DisplayForward();

            // Clear the linked list
            linkedList.Clear();

            // Display forward after clearing
            Console.WriteLine("Forward (after clearing):");
            linkedList.DisplayForward();

            Console.ReadLine();
        }
    }
}