using WebRegister.DAL.Models;
using WebRegister.DAL.Profile;

namespace WebRegister.BLL.Profile;

public class ProfileBLL(IProfileDAL profileDal): IProfileBLL
{
    public void AddProfile(ProfileModel profile)
    {
        profileDal.AddProfile(profile);
    }

    public ProfileModel GetProfileById(int Id)
    {
        return profileDal.GetProfileById(Id);
    }

    public ProfileModel GetProfileByPhone(string Phone)
    {
        return profileDal.GetProfileByPhone(Phone);
    }

    public ProfileModel GetProfileByEmail(string Email)
    {
        return profileDal.GetProfileByEmail(Email);
    }

    public void UpdateProfile(ProfileModel profile)
    {
        profileDal.UpdateProfile(profile);
    }

    public void DeleteProfile(ProfileModel profile)
    {
        profileDal.DeleteProfile(profile);
    }
}