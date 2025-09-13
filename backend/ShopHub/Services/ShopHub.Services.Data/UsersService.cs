namespace ShopHub.Services.Data
{
    using AutoMapper;
    
    using ShopHub.Data.Contracts;
    using ShopHub.Data.Models;
    using ShopHub.Services.Data.Contracts;
    using ShopHub.Services.Models.User;

    public class UsersService : IUsersService
    {
        private readonly IMapper mapper;
        private readonly IRepository<User> repository;

        public UsersService(IMapper mapper, IRepository<User> repository)
        {
            this.mapper = mapper;
            this.repository = repository;
        }

        public async Task<UserResponse> GetById(int id)
        {
            User user = await repository.GetByIdAsync(id);
            var response = mapper.Map<UserResponse>(user);

            return response;
        }
    }
}
