using WebRegister.DAL.Models;

namespace WebRegister.DAL.Profile;

public interface IProfileDAL
{
    public void AddProfile(ProfileModel profile);
    public ProfileModel GetProfileById(int Id);
    public ProfileModel GetProfileByPhone(string Phone);
    public ProfileModel GetProfileByEmail(string Email);
    public void UpdateProfile(ProfileModel profile);
    public void DeleteProfile(ProfileModel profile);
}