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

                newNode.PrevNode = node;

                if (nextItem != null)
                    nextItem.PrevNode = newNode;

                count++;
            }

            public Node FindNode(int searchValue)
            {
                var current = head;
                while (current != null)
                {
                    if (current.Value == searchValue)
                    {
                        return current;
                    }
                    current = current.NextNode;
                }
                return null;
            }

            public int GetCount() => count;


            public void RemoveNode(int index)
            {
                var node = head;

                if (index == 0)
                {
                    head = node.NextNode;
                    head.PrevNode = null;
                }
                else
                {
                    var deleteNode = GetNodeByIndex(index);
                    node = head.NextNode;


                    //поиск удаляемого узла
                    while (deleteNode != null)
                    {
                        if (node.Value == deleteNode.Value)
                        {
                            break;
                        }
                        node = node.NextNode;
                    }

                    if (deleteNode != null)
                    {
                        // если узел не последний
                        if (deleteNode.NextNode != null)
                        {
                            deleteNode.NextNode.PrevNode = deleteNode.PrevNode;
                        }
                        else
                        {
                            // если последний, переустанавливаем tail
                            tail = deleteNode.PrevNode;
                        }

                        // если узел не первый
                        if (deleteNode.PrevNode != null)
                        {
                            deleteNode.PrevNode.NextNode = deleteNode.NextNode;
                        }
                        else
                        {
                            // если первый, переустанавливаем head
                            head = deleteNode.NextNode;
                        }
                        count--;
                    }

                }
            }
            public Node GetNodeByIndex(int Index)
            {
                Node node;

                if (count - 1 >= Index)
                {
                    node = head;
                    for (int i = 1; i <= Index; i++)
                    {
                        node = node.NextNode;
                    }
                }
                else
                {
                    node = tail;
                    for (int i = count - 1; i > Index; i--)
                    {
                        node = node.PrevNode;
                    }
                }
                return node;
            }

            public void RemoveNode(Node node)
            {
                var current = head;

                // поиск удаляемого узла
                while (current != null)
                {
                    if (current.Value == node.Value)
                    {
                        break;
                    }
                    current = current.NextNode;
                }

                if (current != null)
                {
                    // если узел не последний
                    if (current.NextNode != null)
                    {
                        current.NextNode.PrevNode = current.PrevNode;
                    }
                    else
                    {
                        // если последний, переустанавливаем tail
                        tail = current.PrevNode;
                    }

                    // если узел не первый
                    if (current.PrevNode != null)
                    {
                        current.PrevNode.NextNode = current.NextNode;
                    }
                    else
                    {
                        // если первый, переустанавливаем head
                        head = current.NextNode;
                    }
                    count--;
                }
            }
        }

        static void Main(string[] args)
        {
            var linkedList = new DoublyLinkedList();

            var root = new Node { Value = 12 };
            var secondNode = new Node { Value = 18 };
            root.NextNode = secondNode;
            secondNode.PrevNode = root;

            var addAfterNode = new DoublyLinkedList();
            addAfterNode.AddNodeAfter(root, 47);

            linkedList.AddNode(35);
            linkedList.AddNode(42);
            linkedList.AddNode(55);
            linkedList.AddNode(125);
            linkedList.AddNode(133);

            var testNode = linkedList.FindNode(125);

            linkedList.RemoveNode(2);
            linkedList.RemoveNode(testNode);


            var count = linkedList.GetCount();

        }
    }
}
