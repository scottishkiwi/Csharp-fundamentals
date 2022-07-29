using Xunit; 

namespace GradeBook.Tests;

public delegate string WriteLogDelegate(string logMessage); 
public class TypeTests
{



    [Fact]
    public void WriteLogDelegateCanPointToMethod()
    {
        WriteLogDelegate log; 

        //log = new WriteLogDelegate(ReturnMessage); // passing in the method 
        log = ReturnMessage; // this is the short hand of above
        
        var result = log("hello"); 
        Assert.Equal("hello", result); 
    }

    string ReturnMessage(string message)
    {
        return message; 
    }

    [Fact]
    public void TwoVarsCanReferenceSameObject()
    {
        var book1 = GetBook("Book 1");
        var book2 = book1; // This is not a copy of book1, it is assigning the reference value of book1 to book2

        Assert.Same(book1, book2); 
    }

    [Fact]
    public void GetBookReturnsDifferentObjects()
    {
        var book1 = GetBook("Book 1");
        var book2 = GetBook("Book 2");

        Assert.Equal("Book 1", book1.Name);
        Assert.Equal("Book 2", book2.Name);
    }

    // No [Fact] here as it is a helper method and not a test function
    Book GetBook(string name)
    {
        return new InMemoryBook(name); 
    }

    [Fact]
    public void CanSetNameFromReference()
    {
        var book1 = GetBook("Book 1");
        SetName(book1, "New Name"); 

        Assert.Equal("New Name", book1.Name);
    }

    private void SetName(Book book, string name)
    {
        book.Name = name;
    }

    
    [Fact]
    public void CSharpIsPassByValue()
    {
        var book1 = GetBook("Book 1");
        GetBookSetName(book1, "New Name"); 

        Assert.Equal("Book 1", book1.Name);
    }
    
    private void GetBookSetName(Book book, string name)
    {
        book = new InMemoryBook(name); 
    }

      [Fact]
    public void CSharpCanPassByRef()
    {
        var book1 = GetBook("Book 1");
        GetBookSetName(ref book1, "New Name"); 

        Assert.Equal("New Name", book1.Name);
    }
    
    private void GetBookSetName(ref Book book, string name)
    {
        book = new InMemoryBook(name); 
    }

    [Fact]
    public void ValueTypesAlsoPassByValue()
    {
        var x = GetInt();
        SetInt(ref x); 
        Assert.Equal(42, x); 
    }

    private void SetInt(ref int x){
        x = 42;
    }

    private int GetInt()
    {
        return 3; 
    }

    [Fact]
    public void StringsBehaveLikeValueTypes()
    {
        string name = "Dan";
        MakeUppercase(name); 

        Assert.Equal("Dan", name); // This passes because strings are a reference type so the MakeUppercase function executes on a different variable 
    }

    private void MakeUppercase(string param)
    {
        param.ToUpper(); // This does not change the string we called the method on, it returns a copy!!
    }
}