using DataAccessLayer.Core.Interfaces.UoW;
using Microsoft.Extensions.Logging;

namespace HairCut.Services.Services
{
    public class BaseService
    {
        protected readonly IUnitOfWork _uow;
        protected readonly ILogger Logger;

        public BaseService(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public BaseService(IUnitOfWork uow, ILoggerFactory loggerFactory)
        {
            _uow = uow;
            Logger = loggerFactory.CreateLogger<BaseService>();
        }
    }
}
