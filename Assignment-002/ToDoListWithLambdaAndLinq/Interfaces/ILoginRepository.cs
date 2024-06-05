using ToDoListWithLambdaAndLinq.Models;
using System.Threading.Tasks;

namespace ToDoListWithLambdaAndLinq.Interfaces
{
    public interface ILoginRepository
    {
        Task<string> Login(LoginModel login);
    }
}
