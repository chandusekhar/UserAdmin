﻿using LagoVista.CloudStorage.DocumentDB;
using LagoVista.Core.PlatformSupport;
using System.Threading.Tasks;
using System;
using LagoVista.UserAdmin.Interfaces.Repos.Security;
using LagoVista.UserAdmin.Models.Users;
using LagoVista.IoT.Logging.Loggers;

namespace LagoVista.UserAdmin.Repos.Security
{
    public class RoleRepo : DocumentDBRepoBase<Role>, IRoleRepo
    {
        public RoleRepo(IUserAdminSettings settings, IAdminLogger logger) : base(settings.UserStorage.Uri, settings.UserStorage.AccessKey, settings.UserStorage.ResourceName, logger)
        {

        }

        public Task AddRoleAsync(string orgId, Role role)
        {
            throw new NotImplementedException();
        }

        public Task<Role> GetAsync(string id)
        {
            return GetDocumentAsync(id);
        }

        public Task InsertAsync(Role role)
        {
            return CreateDocumentAsync(role);
        }

        public Task RemoveAsync(string id, string etag = "*")
        {
            return DeleteDocumentAsync(id);
        }

        public Task UpdateAsync(Role role)
        {
            return base.UpsertDocumentAsync(role);
        }
    }
}
