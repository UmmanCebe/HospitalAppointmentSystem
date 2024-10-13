using HospitalAppointmentSystem.Models;

namespace HospitalAppointmentSystem.Repositories.Abstracts;
public interface IEntityRepository<TEntity, TId> where TEntity : Entity<TId>, new()
{
    TEntity Add(TEntity entity);
    TEntity Update(TEntity entity);
    TEntity Delete(TId id);
    List<TEntity> GetAll();
    TEntity GetById(TId id);
}