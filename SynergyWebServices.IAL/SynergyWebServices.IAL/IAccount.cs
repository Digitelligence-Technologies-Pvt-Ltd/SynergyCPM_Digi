using SynergyWebServices.DEL;
using System.Threading.Tasks;

namespace SynergyWebServices.IAL;

    public interface IAccount
    {

    public  Task<CommonEntity.CommonResponse> Login(AccountsEntity.Login data);
    public Task<CommonEntity.CommonResponse> LoginUID(string data);


     }

