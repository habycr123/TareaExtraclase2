using System;

namespace TareaExtraclase2
{
    public enum SortDirection
    {
        Asc,
        Desc
    }

    public interface Lista
    {
        void InsertInOrder(int value);
        int DeleteFirst();
        int DeleteLast();
        bool DeleteValue(int value);
        int GetMiddle();
        void MergeSorted(Lista listA, Lista listB, SortDirection direction);
    }

    public class Nodo
    {
        public int Value { get; set; }
        public Nodo? Next { get; set; }
        public Nodo? Previous { get; set; }

        public Nodo(int value)
        {
            Value = value;
            Next = null;
            Previous = null;
        }
    }

    public class ListaDoble : Lista
    {
        public Nodo? Head { get; set; }
        public Nodo? Tail { get; set; }

        public ListaDoble()
        {
            Head = null;
            Tail = null;
        }

        public void InsertInOrder(int value)
        {
            Nodo newNode = new Nodo(value);

            if (Head == null)
            {
                Head = newNode;
                Tail = newNode;
            }
            else
            {
                Nodo? current = Head;
                while (current != null && current.Value < value)
                {
                    current = current.Next;
                }

                if (current == Head)
                {
                    newNode.Next = Head;
                    Head.Previous = newNode;
                    Head = newNode;
                }
                else if (current == null)
                {
                    Tail!.Next = newNode;
                    newNode.Previous = Tail;
                    Tail = newNode;
                }
                else
                {
                    newNode.Next = current;
                    newNode.Previous = current.Previous;
                    current.Previous!.Next = newNode;
                    current.Previous = newNode;
                }
            }
        }

        public int DeleteFirst()
        {
            if (Head == null)
            {
                throw new InvalidOperationException("La lista está vacía.");
            }

            int value = Head.Value;
            Head = Head.Next;

            if (Head != null)
            {
                Head.Previous = null;
            }
            else
            {
                Tail = null;
            }

            return value;
        }

        public int DeleteLast()
        {
            if (Tail == null)
            {
                throw new InvalidOperationException("La lista está vacía.");
            }

            int value = Tail.Value;
            Tail = Tail.Previous;

            if (Tail != null)
            {
                Tail.Next = null;
            }
            else
            {
                Head = null;
            }

            return value;
        }

        public bool DeleteValue(int value)
        {
            Nodo? current = Head;

            while (current != null)
            {
                if (current.Value == value)
                {
                    if (current.Previous != null)
                    {
                        current.Previous.Next = current.Next;
                    }
                    else
                    {
                        Head = current.Next;
                    }

                    if (current.Next != null)
                    {
                        current.Next.Previous = current.Previous;
                    }
                    else
                    {
                        Tail = current.Previous;
                    }

                    return true;
                }

                current = current.Next;
            }

            return false;
        }

        public int GetMiddle()
        {
            if (Head == null)
            {
                throw new InvalidOperationException("La lista está vacía.");
            }

            Nodo? slow = Head;
            Nodo? fast = Head;

            while (fast?.Next != null)
            {
                slow = slow?.Next;
                fast = fast.Next.Next;
            }

            return slow!.Value;
        }

        public void MergeSorted(Lista listA, Lista listB, SortDirection direction)
        {
            if (listA == null || listB == null)
            {
                throw new ArgumentNullException("Una o ambas listas son nulas.");
            }

            ListaDoble mergedList = new ListaDoble();
            Nodo? currentA = (listA as ListaDoble)?.Head;
            Nodo? currentB = (listB as ListaDoble)?.Head;

            if (direction == SortDirection.Asc)
            {
                // Fusión ascendente
                while (currentA != null && currentB != null)
                {
                    if (currentA.Value < currentB.Value)
                    {
                        mergedList.InsertInOrder(currentA.Value);
                        currentA = currentA.Next;
                    }
                    else
                    {
                        mergedList.InsertInOrder(currentB.Value);
                        currentB = currentB.Next;
                    }
                }
            }
            else if (direction == SortDirection.Desc)
            {
                // Fusión descendente
                while (currentA != null && currentB != null)
                {
                    if (currentA.Value > currentB.Value)
                    {
                        mergedList.InsertInOrder(currentA.Value);
                        currentA = currentA.Next;
                    }
                    else
                    {
                        mergedList.InsertInOrder(currentB.Value);
                        currentB = currentB.Next;
                    }
                }
            }

            // Agregar los elementos restantes de la lista A
            while (currentA != null)
            {
                mergedList.InsertInOrder(currentA.Value);
                currentA = currentA.Next;
            }

            // Agregar los elementos restantes de la lista B
            while (currentB != null)
            {
                mergedList.InsertInOrder(currentB.Value);
                currentB = currentB.Next;
            }

            // Actualizar la lista actual con los valores de la lista fusionada
            Head = mergedList.Head;
            Tail = mergedList.Tail;
        }

        public void Invert()
        {
            if (Head == null)
            {
                throw new InvalidOperationException("La lista está vacía.");
            }

            Nodo? current = Head;
            Nodo? temp = null;

            while (current != null)
            {
                // Intercambiar los punteros Next y Previous
                temp = current.Previous;
                current.Previous = current.Next;
                current.Next = temp;
                current = current.Previous;
            }

            // Ajustar los punteros Head y Tail
            if (temp != null)
            {
                Tail = Head;
                Head = temp.Previous;
            }
        }

    }
}
