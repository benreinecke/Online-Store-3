using System;
using System.Security.Cryptography;

public class User
{
    private bool admin;
    private string email;
    private string password;
    private Cart cart;

    private string salt;

    private SHA256 sha256 = SHA256.Create();
    private RandomNumberGenerator rng = RandomNumberGenerator().Create();

    public User(string email, string password, bool admin)
    {
        this.admin = admin;
        this.cart = new Cart(this);
        this.email = email;
        byte salt_array[32] = new byte[32];
        this.salt = Convert.ToBase64String(rng.GetNonZeroBytes(salt_array));
        this.password = getHash(password);
    }

    public bool signIn(string email, string password)
    {
        return this.email.Equals(email) && this.password.Equals(password);
    }

    public bool verifyPassword(string password)
    {
        return this.password.Equals(getHash(password));
    }

    private string getHash(string password)
    {
        return Convert.ToBase64String(sha256.ComputeHash(password + this.salt));
    }
}
