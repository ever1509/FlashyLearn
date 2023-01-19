using System.Data;

namespace Application.Common.Interfaces;

public interface IConnectionFactory
{
    IDbConnection GetConnection { get; }
}