using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using System.Collections;

namespace Wintellect.PowerCollections.Tests
{
    [TestClass]
    public class stackTests
    {
        [TestMethod]
        public void сount_должен_быть_равен_нулю_при_пустом_стеке() //Тестирование свойства Count в незаполненном стеке, оно должно равняться нулю
        {
            Stack<int> stack = new Stack<int>(5);
            Assert.AreEqual(0, stack.Count);
        }
        [TestMethod]
        public void сount_должен_быть_равен_количеству_запушенных_элементов() //Тестирование свойтсва Count в наполненном стеке
        {
            Stack<int> stack = new Stack<int>(5);
            stack.Push(9);
            stack.Push(8);
            Assert.AreEqual(2, stack.Count);
        }
        [TestMethod]
        public void сapacity_должно_быть_равно_параметру_передаваемому_в_конструктор() //Тестирование свойства Capacity 
        {
            Stack<int> stack = new Stack<int>(10);
            Assert.AreEqual(10, stack.Capacity);
        }
        [TestMethod]
        public void isEmpty_должно_быть_true_в_пустом_стеке() //Тестирование isEmpty в ненаполненном стеке
        {
            Stack<int> stack = new Stack<int>(5);
            Assert.IsTrue(stack.IsEmpty);
        }
        [TestMethod]
        public void isEmpty_должно_быть_false_в_наполненном_стеке() //Тестирование isEmpty в наполненном стеке
        {
            Stack<int> stack = new Stack<int>(5);
            stack.Push(1);
            stack.Push(2);
            Assert.IsFalse(stack.IsEmpty);
        }
        [TestMethod]
        public void getEnumerator_должен_вернуть_перевернутый_массив_запушенных_элементов() //Тестирование GetEnumerator
        {
            Stack<int> stack = new Stack<int>(10);
            int[] nums = new int[] { 1, 2, 3, 4, 5, 6, 7, 8 };
            foreach (int n in nums)
            {
                stack.Push(n);
            }
            var res = from r in stack select r;
            CollectionAssert.AreEqual(res.ToArray(), nums.Reverse().ToArray());
        }
        [TestMethod]
        public void constructor_без_параметров_должен_равняться_пяти() //Тестирование конструктора без параметров
        {
            Stack<int> stack = new Stack<int>();
            Assert.AreEqual(5, stack.Capacity);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void constructor_с_отрицательным_параметром_должен_выкидывать_исключение() //Тестирование конструктора с отрицательными параметрами
        {
            Stack<int> stack = new Stack<int>(-10);
        }

        [TestMethod]
        public void push_при_вызове_должен_поместить_элемент_на_вершину_стека_и_увеличить_count() //Тестирование Push при обычной работе
        {
            Stack<int> stack = new Stack<int>();
            stack.Push(6);
            stack.Push(7);
            Assert.AreEqual(2, stack.Count);
            Assert.AreEqual(7, stack.Pop());
        }
        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void push_при_переполнении_стека_должен_выкидывать_исключение() //Тестирование переполнения Push
        {
            Stack<int> stack = new Stack<int>(0);
            stack.Push(1);
        }
        [TestMethod]
        public void top_при_вызове_должен_вернуть_элемент_с_вершины_стека_и_не_изменить_Count() //Тестирование Top при обычной работе
        {
            Stack<int> stack = new Stack<int>();
            stack.Push(1);
            stack.Push(2);
            stack.Push(3);
            Assert.AreEqual(3, stack.Count);
            Assert.AreEqual(3, stack.Top());
            Assert.AreEqual(3, stack.Count);
        }
        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void top_при_вызове_в_пустом_стеке_должен_выкидывать_исключение() //Тестирование Top при пустом стеке
        {
            Stack<int> stack = new Stack<int>();
            stack.Top();
        }
        public void pop_при_вызове_должен_вернуть_элемент_с_вершины_стека_и_изменить_Count() //Тестирование Pop при обычной работе
        {
            Stack<int> stack = new Stack<int>();
            stack.Push(1);
            stack.Push(2);
            stack.Push(3);
            Assert.AreEqual(3, stack.Pop());
            Assert.AreEqual(2, stack.Pop());
        }
        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void pop_при_вызове_в_пустом_стеке_должен_выкидывать_исключение() //Тестирование Pop при пустом стеке
        {
            Stack<int> stack = new Stack<int>();
            stack.Pop();
        }
    }
}