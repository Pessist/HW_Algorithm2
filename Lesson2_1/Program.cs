using System;
using static Lesson2_1.Program;

namespace Lesson2_1
{
    class Program
    {
        public sealed class Node
        {
            public int Value { get; set; }
            public Node NextNode { get; set; }
            public Node PrevNode { get; set; }
        }

        //Начальную и конечную ноду нужно хранить в самой реализации интерфейса
        public interface ILinkedList
        {
            int GetCount(); // возвращает количество элементов в списке
            void AddNode(int value); // добавляет новый элемент списка
            void AddNodeAfter(Node node, int value); // добавляет новый элемент списка после определённого элемента
            void RemoveNode(int index); // удаляет элемент по порядковому номеру
            void RemoveNode(Node node); // удаляет указанный элемент
            Node FindNode(int searchValue); // ищет элемент по его значению
        }

        private class DoublyLinkedList : ILinkedList
        {
            private int count = 0;
            private Node head;
            private Node tail;

            public void AddNode(int value) // добавление на конец списка нового элемента.
            {

                var addNode = new Node { Value = value };

                if (head == null)
                {
                    head = addNode;
                }
                else
                {
                    tail.NextNode = addNode;
                    addNode.PrevNode = tail;
                }

                tail = addNode;

                count++;
            }

            public void AddNodeAfter(Node node, int value)
            {
                var newNode = new Node { Value = value };

                var nextItem = node.NextNode;

                node.NextNode = newNode;

                newNode.NextNode = nextItem;
                //newNode.PrevNode = prevItem;

                count++;
            }

            public Node FindNode(int searchValue)
            {
                throw new NotImplementedException();
            }

            public int GetCount() => count;


            public void RemoveNode(int index)
            {
                throw new NotImplementedException();
            }

            public void RemoveNode(Node node)
            {
                throw new NotImplementedException();
            }
        }

        static void Main(string[] args)
        {
            var list = new DoublyLinkedList();

            var root = new Node { Value = 12 };

            list.AddNode(35);
            list.AddNode(42);
            list.AddNode(55);
            list.AddNode(125);

            var addAfterNode = new DoublyLinkedList();

            addAfterNode.AddNodeAfter(root, 47);

            var count = list.GetCount();

        }
    }
}
