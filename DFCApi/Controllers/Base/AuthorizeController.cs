using Microsoft.AspNetCore.Authorization;

namespace API.Controllers.Base
{
    [Authorize]
    public abstract class AuthorizeController : BaseController
    {
    }
}