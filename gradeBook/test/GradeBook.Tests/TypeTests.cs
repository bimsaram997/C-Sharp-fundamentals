
using System.Reflection;
using System.Security.AccessControl;
using System;
using Xunit;
namespace GradeBook.Tests {
public class TypeTests
{
    public delegate string WriteLogDelegate(string logMessage);
    int count = 0;
    //dotnet add package xunit --version 2.5.1-pre.26

    [Fact]
    public void WriteLogCanPointMethod()
    {
       WriteLogDelegate log = ReturnMessage;
       log += ReturnMessage; //multicast
       log += IncrementCount; //multicast
       var result = log("Hello");
       //Assert.Equal("Hello", result);
       Assert.Equal(3, count);
    }

    string ReturnMessage(string message) {
        count++;
        return  message;
    }

     string IncrementCount(string message) {
        count++;
        return  message.ToLower();
    }

    [Fact]
    public void GetBookReturnsDifferentObjects()
    {
        var book1 = GetBook("Book 1");
        var book2 = GetBook("Book 2");

        Assert.Equal("Book 1", book1.Name);
        Assert.Equal("Book 2", book2.Name);
        Assert.NotSame(book1, book2);
    }

    [Fact]
    public void TwoVariablesCanReferenceSameObject()
    {
        var book1 = GetBook("Book 1");
        var book2 = book1;

        Assert.Same(book1, book2);
        Assert.True(Object.ReferenceEquals(book1, book2));
    }

    [Fact]
    public void ChangeBookName()
    {
        var book1 = GetBook("Book 1");
        SetName(book1, "New Name 1");
        Assert.Equal("New Name 1", book1.Name);
    }
    // [Fact]
    //  public void CSharpIsPassByValue()
    // {
    //     var book1 = GetBook("Book 1");
    //     GetBookSetName(book1, "New Name 1");
    //     Assert.Equal("New Name 1", book1.Name);
    // }

     public void CSharpCanPassByRef()
    {
        var book1 = GetBook("Book 1");
        GetBookSetNameRef(ref book1, "New Name 1");
        Assert.Equal("New Name 1", book1.Name);
    }

     [Fact]
     public void ValueTypeCheck()
    {
        var x = GetInt();
        SetInt(ref x);
        Assert.Equal(42, x); 
    }

    private int GetInt() {
        return 3;
    }
    
    private void SetInt(ref int z) {
        z = 42;
    }

    Book GetBook(string name ){
        return new Book(name);
    }

    public void SetName(Book book, string name) {
        book.Name  = name;
    } 

     public void GetBookSetName(Book book, string name) {
        book  = new Book( name);
    } 
     public void GetBookSetNameRef( ref Book book, string name) {
        book  = new Book( name);
    } 
}
}

