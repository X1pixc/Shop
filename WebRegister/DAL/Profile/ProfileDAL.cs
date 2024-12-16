using Microsoft.EntityFrameworkCore;
using WebRegister.DAL.Models;

namespace WebRegister.DAL.Profile;

public class ProfileDAL: IProfileDAL
{
    public void AddProfile(ProfileModel profile)
    {
        var connection = new DBHelper();
        connection.Profiles.Add(profile);
        connection.SaveChanges();
    }

    public ProfileModel GetProfileById(int Id)
    {
        var connection = new DBHelper();
        return connection.Profiles.Find(Id);
    }

    public ProfileModel GetProfileByPhone(string Phone)
    {
        var connection = new DBHelper();
        return connection.Profiles.FirstOrDefault(p => p.Phone == Phone);
    }

    public ProfileModel GetProfileByEmail(string Email)
    {
        var connection = new DBHelper();
        return connection.Profiles.FirstOrDefault(p => p.Email == Email);
    }

    public void UpdateProfile(ProfileModel profile)
    {
        var connection = new DBHelper();
        connection.Profiles.Update(profile);
        connection.SaveChanges();
    }

    public void DeleteProfile(ProfileModel profile)
    {
        var connection = new DBHelper();
        connection.Profiles.Remove(profile);
        connection.SaveChanges();
    }
}