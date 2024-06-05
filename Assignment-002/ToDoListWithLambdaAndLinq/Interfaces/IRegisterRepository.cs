using ToDoListWithLambdaAndLinq.Models;

namespace ToDoListWithLambdaAndLinq.Interfaces
{
    public interface IRegisterRepository
    {
        Task RegisterUser(RegisterModel model);
    }
}
