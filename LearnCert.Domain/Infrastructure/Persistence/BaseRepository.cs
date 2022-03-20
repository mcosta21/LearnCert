﻿namespace LearnCert.Domain.Infrastructure.Persistence;

public interface IBaseRepository<TEntity>
{
    void Save<TEntity>(TEntity entity) where TEntity : class;
    void Delete<TEntity>(TEntity entity) where TEntity : class;
    TEntity Update<TEntity>(TEntity entity) where TEntity : class;
}

public class BaseRepository<TEntity> : IBaseRepository<TEntity>
{

    private readonly IUnitOfWork _unitOfWork;
    
    public BaseRepository(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
    
    public void Save<TEntity>(TEntity entity) where TEntity : class
    {
        _unitOfWork.Save(entity);
    }

    public void Delete<TEntity>(TEntity entity) where TEntity : class
    {
        _unitOfWork.Delete(entity);
    }

    public TEntity Update<TEntity>(TEntity entity) where TEntity : class
    {
        return _unitOfWork.Merge(entity);
    }
}