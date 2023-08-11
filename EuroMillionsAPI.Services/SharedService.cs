using EuroMillionsAPI.Repository;

namespace EuroMillionsAPI.Services
{
    public class SharedService
    {
        private EuromillionDbContext _repository { get; set; }

        public SharedService(EuromillionDbContext repository)
        {
            _repository = repository;
        }

        public EuromillionDbContext Repository { get { return _repository; } }
    }
}
