namespace Src.Infra.Persistence.Repository.Implementation;
using Microsoft.EntityFrameworkCore;
using Src.Infra.Persistence.Model;
using Src.Infra.Persistence.Repository.Contract;

public class UserRepositoryImpl : IUserRepository{

    private readonly AppDbContext _dbContext;

    public UserRepositoryImpl(AppDbContext appDbContext){
        this._dbContext=appDbContext;
    }

    public async Task DeleteUserById(long id){
       int rowsAffected=await _dbContext.User.Where(user=>user.Id==id).ExecuteDeleteAsync();
       if (rowsAffected != 1){throw new InfraException($"nenhum usuário foi encontrado com o id {id}",400);}
    }

    public async Task<bool> ExistsUserRegistredFromEmail(string email){
        return await _dbContext.User.Where(user=>user.Email==email).AnyAsync();
    }

    public async Task<UserPersist> GetUserByEmail(string email){
       UserPersist? possibleEntity=await _dbContext.User.FirstOrDefaultAsync(user=>user.Email==email);
       if(possibleEntity==null){throw new InfraException($"usuário não encontrado com o email {email}",400);}
       return possibleEntity!; 
    }

    public async Task<UserPersist> GetUserById(long id){
       UserPersist? possibleEntity=await _dbContext.User.FindAsync(id);
       if(possibleEntity==null){throw new InfraException($"usuário não encontrado com o id {id}",400);}
       return possibleEntity!;    
    }

    public async Task<UserPersist> RegisterUser(UserPersist entity){
        await _dbContext.User.AddAsync(entity);
        await _dbContext.SaveChangesAsync();
        return entity;
    }

    public async Task<UserPersist> UpdateUser(UserPersist entity, UpdateAccountUserRequestDto dto){
        _dbContext.Entry(entity).CurrentValues.SetValues(dto);
        await _dbContext.SaveChangesAsync();
        return entity;
    }

    public async Task UpdateUserAdmin(UserPersist actEntity, UpdateAccountUserAdminRequestDto dto){
        _dbContext.Entry(actEntity).CurrentValues.SetValues(dto);
        await _dbContext.SaveChangesAsync();
    }
}