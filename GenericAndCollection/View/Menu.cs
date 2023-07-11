

using GenericAndCollection.Controller;
using GenericAndCollection.Model;
using GenericAndCollection.Utility;

namespace GenericAndCollection.View;

public class Menu
{
    private int _count;
    readonly BasicAuthentication _auth = new BasicAuthentication();
    
    public void MenuApp()
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("========================");
            Console.WriteLine("  BASIC AUTHENTICATION");
            Console.WriteLine("========================");
            Console.WriteLine(" [1] Create User");
            Console.WriteLine(" [2] Show User");
            Console.WriteLine(" [3] Search User");
            Console.WriteLine(" [4] Login User");
            Console.WriteLine(" [5] Info Author");
            Console.WriteLine(" [6] Exit");
            Console.WriteLine("========================");
            Console.Write("\nInsert Your Choice : ");
            var input = Console.ReadLine();
            switch (input)
            {
                case "1":
                    Console.Clear();
                    Console.WriteLine("========================");
                    Console.WriteLine("      CREATE-USER");
                    Console.WriteLine("========================");
                    AddUser();
                    Console.ReadKey();
                    break;
                case "2":
                    Console.Clear();
                    Console.WriteLine("========================");
                    Console.WriteLine("       SHOW-USER");
                    Console.WriteLine("========================");
                    ShowUser();
                    Console.ReadKey();
                    break;
                case "3":
                    Console.Clear();
                    Console.WriteLine("========================");
                    Console.WriteLine("      SEARCH-USER");
                    Console.WriteLine("========================");
                    SearchUser();
                    Console.ReadKey();
                    break;
                case "4":
                    Console.Clear();
                    Console.WriteLine("========================");
                    Console.WriteLine("      LOGIN-USER");
                    Console.WriteLine("========================");
                    LoginUser();
                    Console.ReadKey();
                    break;
                case "5":
                    Console.WriteLine("========================");
                    Console.WriteLine("       INFO-AUTHOR");
                    Console.WriteLine("========================");
                    InfoAuthor();
                    Console.ReadKey();
                    break;
                case "6":
                    Console.Clear();
                    Console.WriteLine("========================");
                    Console.WriteLine("      EXIT-PROGRAM");
                    Console.WriteLine("========================");
                    Environment.Exit(0);
                    break;
                default:
                    Console.Clear();
                    MenuApp();
                    break;
            }
        }
        
        // ReSharper disable once FunctionNeverReturns
    }

    private void AddUser()
    {
        var firstName = GetInput.GetString("First Name : ");
        
        var lastName = GetInput.GetString("Last Name : ");

        var password = PasswordCheker.Check();
        _auth.CreateUser(this._count, firstName, lastName, password);
        this._count++;
        Console.WriteLine("========================");
        Console.WriteLine("Account was Created . . .");
    }

    private void ShowUser()
    {
        foreach (var user in _auth.Users)
        {
            PrintUser(user);
        }
        
        Console.WriteLine(" [1] Edit User");
        Console.WriteLine(" [2] Delete User");
        Console.WriteLine(" [3] Back");
        Console.WriteLine("========================");
        Console.Write("\nInsert Your Choice : ");
        var input = Console.ReadLine();
        
        int id;
        switch (input)
        {
            case "1":
                Console.Clear();
                Console.WriteLine("========================");
                Console.WriteLine("       EDIT-USER");
                Console.WriteLine("========================");
                Console.Write("Id         : ");
                id = GetInput.GetInt();
                if (_auth.CheckUserById(id))
                {
                    var firstName = GetInput.GetString("First Name : ");
                    
                    var lastName = GetInput.GetString("last Name : ");

                    var password = PasswordCheker.Check();
                
                    _auth.EditUser(id, firstName, lastName, password);
                    Console.WriteLine("========================");
                    Console.WriteLine("Change Account Success . . .");
                }
                else
                {
                    Console.WriteLine("========================");
                    Console.WriteLine($"Id : {id}, tidak ditemukan . . .");
                }
                break;
            case "2" :
                Console.Write("Id : ");
                id = GetInput.GetInt();
                var user = _auth.GetUserById(id);
                if (user != null)
                {
                    _auth.Users.Remove(user);
                    Console.WriteLine("========================");
                    Console.WriteLine("Delete Account Success . . .");
                }
                else
                {
                    Console.WriteLine("========================");
                    Console.WriteLine("Id Not Match . . .");
                }
                break;
            case "3" :
                MenuApp();
                break;
            default:
                Console.Clear();
                ShowUser();
                break;
        }
    }

    private void PrintUser(User user)
    {
        Console.WriteLine($"ID       : {user.Id}");
        Console.WriteLine($"Name     : {user.Name}");
        Console.WriteLine($"Username : {user.UserName}");
        Console.WriteLine($"Password : {user.Password}");
        Console.WriteLine("========================");
    }
    
    private void InfoAuthor()
    {
        Console.WriteLine($"ID       : 001");
        Console.WriteLine($"Name     : Ahmad Eko Kurniawan");
        Console.WriteLine($"Username : Kurniawan2023");
        Console.WriteLine($"Password : Ahmad123");
        Console.WriteLine("========================");
    }

    private void SearchUser()
    {
        var fullName = GetInput.GetString("Insert Name : ");
        Console.WriteLine("========================");
        var result = _auth.Search(fullName);
        if (result != null)
        {
            PrintUser(result);
        }
        else
        {
            Console.WriteLine("Account Not Found . . .");
        }

        Console.ReadKey();
    }

    private void LoginUser()
    {
        var userName = GetInput.GetString("Username : ");
        var password = PasswordCheker.Check();
        var status = _auth.LoginUser(userName, password);
        if (status)
        {
            Console.WriteLine("========================");
            Console.WriteLine("Login Success. . .");
        }
        else
        {
            Console.WriteLine("========================");
            Console.WriteLine("Login Failed . . .");
        }
    }
}
