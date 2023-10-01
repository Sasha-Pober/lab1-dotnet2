namespace CustomLinkedListTesting;
using DataLayer;

[TestFixture]
public class Tests
{
    private CustomLinkedList<string> _list; 
    [SetUp]
    public void Setup()
    {
        _list = new CustomLinkedList<string>();
    }

    [Test]
    public void AddFirst_NewNode_EmptyList_ResultListWithOneNode()
    {
        var node = new Node<string>("Node");

        _list.AddFirst(node);

        Assert.Multiple(() =>
        {
            Assert.That(_list.First, Is.EqualTo(node));
            Assert.That(_list, Has.Count.EqualTo(1));
        });
    }

    [Test]
    public void AddFirst_NewNode_ListWithOneNode_ResultFirstNodeIsAddedNode()
    {
        var node = new Node<string>("oldNode");
        _list.AddFirst(node);

        var node1 = new Node<string>("newNode");
        _list.AddFirst(node1);

        Assert.Multiple(() =>
        {
            Assert.That(_list.First, Is.EqualTo(node1));
            Assert.That(_list, Has.Count.EqualTo(2));
        });
    }

    [Test]
    public void AddLast_NewNode_EmptyList_ResultListWithOneNodeOnLastPlace()
    {
        var node = new Node<string>("NewNode");

        _list.AddLast(node);

        Assert.Multiple(() =>
        {
            Assert.That(_list.Last, Is.EqualTo(node));
            Assert.That(_list.Last, Is.SameAs(node));
            Assert.That(_list, Has.Count.EqualTo(1));
        });
    }

    [Test]
    public void AddLast_NewNode_ListWithOneNode_ResultLastNodeIsNewNode()
    {
        var node = new Node<string>("oldNode");
        _list.AddLast(node);

        Node<string> node1 = new("NewNode");
        _list.AddLast(node1);

        Assert.Multiple(() =>
        {
            Assert.That(_list.Last, Is.EqualTo(node1));
            Assert.That(_list, Has.Count.EqualTo(2));
        });
    }

    [Test]
    public void Clear_ListWith5Elements_ResultEmptyList()
    {
        for(int i = 0; i < 5; i++)
        {
            _list.AddLast(new Node<string>($"node{i}"));
        }

        _list.Clear();

        Assert.Multiple(() =>
        {
            Assert.That(_list, Has.Count.EqualTo(0));
            Assert.True(_list.First == null && _list.Last == null);
        });
        
    }

    [Test]
    public void AddBefore_EmptyList_ResultListWithOneElementOnFirstPlace()
    {
        Node<string> node = new("newNode");

        _list.AddBefore(node, null);

        Assert.Multiple(() =>
        {
            Assert.That(_list.First, Is.EqualTo(node));
            Assert.That(_list.First, Is.SameAs(node));
            Assert.That(_list, Has.Count.EqualTo(1));
        });
    }


    [Test]
    public void AddBefore_ListWith1Node_Result2ElementsWithNewNodeOnTheFirstPlace()
    {
        Node<string> node = new("OldNode");
        _list.AddLast(node);

        Node<string> node1 = new("NewNode");

        _list.AddBefore(node1, node);

        
        Assert.Multiple(() =>
        {
            Assert.That(_list.First, Is.SameAs(node1));
            Assert.That(_list.First, Is.EqualTo(node1));
            Assert.That(_list, Has.Count.EqualTo(2));
        });
    }

    [Test]
    public void AddBefore_ListWith1NodeButOldNodeIsNotFromList_ResultNullRefException()
    {
        Node<string> node = new("oldNode");

        Node<string> fakeOldNode = new("OldNode");

        _list.AddLast(node);

        Node<string> newNode = new("NewNode");

        Assert.Throws<NullReferenceException>(() => _list.AddBefore(newNode, fakeOldNode));
    }

    [Test]
    public void AddBefore_ListWith3Elements_ResultAddedNodeBeforeLastElement()
    {
        Node<string> node1 = new("Node1");
        Node<string> node2 = new("Node2");
        Node<string> node3 = new("Node3");

        _list.AddLast(node1);
        _list.AddLast(node2);
        _list.AddLast(node3);

        Node<string> node4 = new("Node4");

        _list.AddBefore(node4, node3);

        Assert.Multiple(() =>
        {
            Assert.That(_list, Has.Count.EqualTo(4));
            Assert.That(node3.Previous, Is.EqualTo(node4));
            Assert.That(node3.Previous, Is.SameAs(node4));
            Assert.That(_list.Last, Is.EqualTo(node3));
            Assert.That(_list.Last, Is.SameAs(node3));
        });
        
    }

    [Test]
    public void AddAfter_EmptyList_ResultListWith1ElementOnFirstPlace()
    {
        Node<string> node1 = new("Node");

        _list.AddAfter(node1, null);

        Assert.Multiple(() =>
        {
            Assert.That(_list, Has.Count.EqualTo(1));
            Assert.That(_list.First, Is.EqualTo(node1));
            Assert.That(_list.First, Is.SameAs(node1));
        });
    }

    [Test]
    public void AddAfter_ListWith1Element_ResultListWith2ElementsWithNewNodeOnTheLastPlace()
    {
        Node<string> node1 = new("node1");

        _list.AddLast(node1);

        Node<string> node2 = new("node2");

        _list.AddAfter(node2, node1);

        Assert.Multiple(() => 
        {
            Assert.That(_list, Has.Count.EqualTo(2));
            Assert.That(_list.Last, Is.EqualTo(node2));
            Assert.That(_list.Last, Is.SameAs(node2));
            Assert.That(_list.First, Is.EqualTo(node1));
            Assert.That(_list.First, Is.SameAs(node1));
        });

    }

    [Test]
    public void AddAfter_ListWith1NodeButOldNodeIsNotFromList_ResultThrowNullrefException()
    {
        Node<string> node1 = new("oldNode");
        Node<string> fakeNode = new("oldNode");
        _list.AddLast(node1);

        Node<string> node2 = new("newNode");

        Assert.Throws<NullReferenceException>(() => _list.AddAfter(node2, fakeNode));
    }

    [Test]
    public void AddAfter_ListWith3Elements_ResultAddedElementAfterFirst()
    {
        Node<string> node1 = new("Node1");
        Node<string> node2 = new("Node2");
        Node<string> node3 = new("Node3");

        _list.AddLast(node1);
        _list.AddLast(node2);
        _list.AddLast(node3);

        Node<string> node4 = new("Node4");

        _list.AddAfter(node4, node1);

        Assert.Multiple(() =>
        {
            Assert.That(_list, Has.Count.EqualTo(4));
            Assert.That(node1.Next, Is.EqualTo(node4));
            Assert.That(node1.Next, Is.SameAs(node4));
            Assert.That(_list.First, Is.EqualTo(node1));
            Assert.That(_list.First, Is.SameAs(node1));
        });
    }

}