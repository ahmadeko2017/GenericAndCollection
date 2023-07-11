namespace GenericAndCollection.Model;

public class User
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string UserName { get; set; }
    public string? Password { get; set; }

    public User(int id, string? firstName, string? lastName, string? password)
    {
        this.Id = id;
        this.Name = $"{firstName} {lastName}";
        this.UserName = $"{firstName?[0..2]}{lastName?[0..2]}";
        this.Password = password;
    }
}