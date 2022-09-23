namespace RegisterModule.Interfaces
{
    public interface IUserJobTypeService
    {
        public bool AddUserJobTypes(int[] jobTypes, int userId);
    }
}
