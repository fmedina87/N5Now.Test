using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using N5Now.Test.Domain.Common.Entities;
using N5Now.Test.Domain.Dto;
using N5Now.Test.Domain.Entities;
using N5Now.Test.Domain.Interfaces.Services;
using Nest;
using System.Security;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace N5Now.Test.Application.Services
{
    public class ElasticSearchService : IElasticSearchService
    {
        private readonly IElasticClient _client;
        private readonly ILoggerService _logger;
        private readonly string _indexName;
        private readonly AppSettings _appSettings;

        public ElasticSearchService(ILoggerService logger, IOptions<AppSettings> appSettings)
        {
            _logger = logger;
            _appSettings = appSettings.Value;
            var url = _appSettings.Elasticsearch?.Url ?? string.Empty;
            _indexName = _appSettings.Elasticsearch?.Index ?? string.Empty;
            var settings = new ConnectionSettings(new Uri(url))
                .RequestTimeout(TimeSpan.FromMinutes(1))
                .DisableDirectStreaming()
                .DefaultIndex(_indexName)
                .ThrowExceptions(true);
            _client = new ElasticClient(settings);
        }

        public async Task<bool> IndexPermissionAsync(Permission permission)
        {
            InitializeLists(permission);
            var response = await _client.IndexDocumentAsync(permission);
            if (!response.IsValid)
            {
                _logger.LogError(response.OriginalException, "Error inserting document in Elasticsearch: {Error}");
                return false;
            }
            _logger.LogInformation("Permission indexed successfully: {Id}", permission.Id);
            return true;
        }
        private static void InitializeLists(Permission permission)
        {
            if (permission.Employee != null)
                permission.Employee.Permissions = [];
            if (permission.PermissionType != null)
                permission.PermissionType.Permissions = [];
        }
        public async Task<List<Permission>> GetPermissionsAsync(int page, int pageSize)
        {
            var response = await _client.SearchAsync<Permission>(s => s
            .From((page - 1) * pageSize)
            .Size(pageSize)
            .Query(q => q.MatchAll()));

            return [.. response.Documents];
        }
        public async Task<int> Count()
        {
            var response = await _client.SearchAsync<Permission>(s => s
            .Query(q => q.MatchAll()));

            return response.Documents.Count();
        }
        public async Task<bool> UpdatePermissionAsync(Permission permission)
        {
            InitializeLists(permission);
            var response = await _client.UpdateAsync<Permission>(permission.Id, u => u.Doc(permission));
            if (!response.IsValid)
            {
                _logger.LogError(response.OriginalException, "Error updating document in Elasticsearch: {Error}");
                return false;
            }
            _logger.LogInformation("Permission updated successfully: {Id}", permission.Id);
            return true;
        }
    }
}
