using NUnit.Framework;
using System;
using System.Collections;
using System.Text;
using TestNinja.Fundamentals;

namespace TestNinja.UnitTests
{
    [TestFixture]
    public class StackTests
    {
        private Stack<string> _stack;

        [SetUp]
        public void SetUp()
        {
            _stack = new Stack<string>();
        }

        [Test]
        public void Count_Empty_ReturnsZero()
        {
            var result = _stack.Count;
            Assert.That(result, Is.EqualTo(0));
        }

        [Test]
        public void Push_WhenNullObject_ReturnsArgumentNullException()
        {
            Assert.That(() => _stack.Push(null), Throws.Exception.TypeOf<ArgumentNullException>());
        }

        [Test]
        public void Push_WhenNonNullObject_AddsObjectToStack()
        {
            _stack.Push("abc");
            Assert.That(_stack.Count, Is.EqualTo(1));
        }

        [Test]
        public void Pop_WhenEmptyStack_ReturnsInvalidOperationException()
        {
            Assert.That(() => _stack.Pop(), Throws.Exception.TypeOf<InvalidOperationException>());
        }

        [Test]
        public void Pop_WhenNonEmptyStack_ReducesCountBy1()
        {
            _stack.Push("abc");
            _stack.Pop();
            var result = _stack.Count;
            Assert.That(result, Is.EqualTo(0));
        }

        [Test]
        public void Pop_WhenNonEmptyStack_ReturnsRemovedItem()
        {
            _stack.Push("abc");
            var result = _stack.Pop();
            Assert.That(result, Is.EqualTo("abc"));
        }

        [Test]
        public void Peek_WhenEmptyStack_ReturnsInvalidOperationException()
        {
            Assert.That(() => _stack.Peek(), Throws.Exception.TypeOf<InvalidOperationException>());
        }

        [Test]
        public void Peek_WhenNonEmptyStack_ReturnsLastItemAdded()
        {
            _stack.Push("abc");
            _stack.Push("def");
            var result = _stack.Peek();
            Assert.That(result, Is.EqualTo("def"));
        }
    }
}
