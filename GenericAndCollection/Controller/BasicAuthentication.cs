using GenericAndCollection.Model;

namespace GenericAndCollection.Controller;

public class BasicAuthentication
{
    public readonly List<User> Users = new List<User>();
    
    public void CreateUser(int id, string? firstName, string? lastName, string? password)
    {
        var user = new User(id, firstName, lastName, password);
        Users.Add(user);
    }

    public User Search(string? fullName)
    {
        foreach (var user in Users)
        {
            if (user.Name.ToLower() == fullName?.ToLower())
            {
                return user;
            }
        }
        return null;
    }
    
    public bool LoginUser(string? userName, string? password)
    {
        foreach (var user in Users)
        {
            if (user.UserName == userName && user.Password == password)
            {
                return true;
            }
        }
        return false;
    }

    public void EditUser(int id, string? firstName, string? lastName, string? password)
    {
        var count = 0;
        foreach (var user in Users)
        {
            if (user.Id == id)
            {
                Users[count].Name = $"{firstName} {lastName}";
                Users[count].UserName = $"{firstName?[0..2]}{lastName?[0..2]}";
                Users[count].Password = password;
                break;
            }
            count++;
        }
    }
    
    public User GetUserById(int id)
    {
        foreach (var user in Users)
        {
            if (user.Id == id)
            {
                return user;
            }
        }
        return null;
    }
    
    public bool CheckUserById(int id)
    {
        foreach (var user in Users)
        {
            if (user.Id == id)
            {
                return true;
            }
        }
        return false;
    }
}