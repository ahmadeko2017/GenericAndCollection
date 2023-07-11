namespace GenericAndCollection.Utility;

public static class PasswordCheker
{
    public static string? Check()
    {
        bool length = false;
        bool capital = false;
        bool lower = false;
        bool number = false;
        string? password;
        
        while (true)
        {
            password = GetInput.GetString("Password : ");
            if (password != null)
                foreach (var character in password)
                {
                    if (password.Length >= 8)
                    {
                        length = true;
                    }

                    if (character >= 48 && character <= 57)
                    {
                        number = true;
                    }

                    if (character >= 65 && character <= 90)
                    {
                        capital = true;
                    }

                    if (character >= 97 && character <= 122)
                    {
                        lower = true;
                    }
                }

            if (length && number && capital && lower)
            {
                break;
            }
            else
            {
                Console.WriteLine("Password must have at least 8 characters with at least one Capital letter, at least one lower case letter and at least one number.");
            }
        }
        return password;
    }
}