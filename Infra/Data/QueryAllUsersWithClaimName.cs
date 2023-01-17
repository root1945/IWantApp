using Dapper;
using IWantApp.Endpoints.Employees;
using Microsoft.Data.SqlClient;

namespace IWantApp.Infra.Data;

public class QueryAllUsersWithClaimName
{
    public readonly IConfiguration configuration;
    public QueryAllUsersWithClaimName(IConfiguration configuration)
    {
        this.configuration = configuration;
    }

    public IEnumerable<EmployeeResponse> Execute(int page, int rows)
    {
        var db = new SqlConnection(configuration["ConnectionStrings:IWantDb"]);
        var query = @"
        SELECT userId Id, ClaimValue Name, Email
        FROM AspNetUserClaims c
        INNER JOIN AspNetUsers u ON u.Id = c.UserId
        WHERE ClaimType = 'Name'
        ORDER BY Name
        OFFSET @Offset ROWS FETCH NEXT @Rows ROWS ONLY";
        var employees = db.Query<EmployeeResponse>(
            query,
            new { Offset = (page - 1) * rows, Rows = rows });
        return employees;
    }
}