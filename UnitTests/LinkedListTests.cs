using CustomStructure;

namespace UnitTests;

public class LinkedListTests
{
    [Test]
    public void AddLast_Number_CorrectPlace()
    {
        // Arrange
        LinkedList<int> list = new(new int[] { 1, 2, 3, 4, 5 });

        // Act
        list.AddLast(99);

        // Assert
        Assert.That(list?.Last?.Value, Is.EqualTo(99));
    }

    [Test]
    public void AddAfter_Number_CorrectPlace()
    {
        // Arrange
        LinkedList<int> list = new(new int[] { 1, 2, 4, 5 });
        LinkedListNode<int> secondNode = list.First!.Next!;
        LinkedListNode<int> thirdNode = new(3);

        // Act
        list.AddAfter(secondNode, thirdNode);

        // Assert
        Assert.That(list.ElementAt(2), Is.EqualTo(3));
    }

    [Test]
    public void AddAfter_Number_ArgumentNullException()
    {
        // Arrange
        LinkedList<int> list = new(new int[] { 1 });
        LinkedListNode<int> secondNode = list.Last!.Next!;
        LinkedListNode<int> thirdNode = new(3);

        // Assert
        Assert.Throws<ArgumentNullException>(() => list.AddAfter(secondNode, thirdNode));
    }

    [Test]
    public void RemoveFirst_String_DoesNotExist()
    {
        // Arrange
        LinkedList<int> list = new(new int[] { 1, 2, 3, 4, 5 });

        // Act
        list.RemoveFirst();

        // Assert
        Assert.That(list?.First?.Value, Is.EqualTo(2));
    }

    [Test]
    public void RemoveLast_EmptyList_InvalidOperationException()
    {
        // Arrange
        LinkedList<Person> list = new();

        // Assert
        Assert.Throws<InvalidOperationException>(list.RemoveLast);
    }

    [Test]
    public void Contains_Person_ReturnsTrueOrFalse()
    {
        // Arrange
        LinkedList<Person> list = new();
        list.AddLast(new Person("Богдан", "Саврак"));
        list.AddLast(new Person("Михайло", "Саврак"));

        // Act
        bool isBohdan = list.Contains(new Person("Богдан", "Саврак"));
        bool isStepan = list.Contains(new Person("Степан", "Саврак"));

        // Assert
        Assert.Multiple(() =>
        {
            Assert.That(isBohdan, Is.True);
            Assert.That(isStepan, Is.False);
        });
    }

    [Test]
    public void Find_Node_ReturnsTrue()
    {
        // Arrange
        LinkedList<int> list = new(new int[] { 1, 2, 3, 4, 5 });

        // Act
        LinkedListNode<int>? four = list.Find(4);

        // Assert
        Assert.That(four?.Value, Is.EqualTo(4));
    }

    [Test]
    public void Clear_All_EmptyList()
    {
        // Arrange
        LinkedList<Person> list = new();
        list.AddLast(new Person("Богдан", "Саврак"));
        list.AddLast(new Person("Михайло", "Саврак"));

        // Act
        list.Clear();

        // Assert
        Assert.That(list, Is.Empty);
    }

    [Test]
    public void Sum_NumberBiggerThan5_CorrectSum()
    {
        // Arrange
        LinkedList<int> list = new(new int[] { 15, 1, 4, 65, 10 });

        // Act
        int sum = list.Sum((number) => number > 5 ? number : 0);

        // Assert
        Assert.That(sum, Is.EqualTo(15 + 65 + 10));
    }

    [Test]
    public void Count_Nodes_CorrectNumber()
    {
        // Arrange
        LinkedList<int> list = new(new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 });

        // Act
        list.RemoveFirst();
        list.RemoveFirst();
        list.RemoveLast();
        list.AddFirst(-1);
        list.AddLast(10);

        // Assert
        Assert.That(list, Has.Count.EqualTo(9));
    }

}