using EmployeeApi.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace EmployeeApi.Services
{
    public class EmployeeService
    {
        private readonly IMongoCollection<Employee> _employees;

        public EmployeeService(IOptions<MongoDBSettings> dbSettings, MongoClient mongoClient)
        {
            var database = mongoClient.GetDatabase(dbSettings.Value.DatabaseName);
            _employees = database.GetCollection<Employee>(dbSettings.Value.CollectionName);
        }

        public async Task<List<Employee>> GetEmployees() =>
            await _employees.Find(employee => true).ToListAsync();

        public async Task<Employee> GetEmployeeByEmail(string email) =>
            await _employees.Find(employee => employee.Email == email).FirstOrDefaultAsync();

        public async Task CreateEmployee(Employee employee) =>
            await _employees.InsertOneAsync(employee);

        public async Task<Employee> GetEmployeeById(string id) =>
            await _employees.Find(employee => employee.Id == id).FirstOrDefaultAsync();
    }
}
