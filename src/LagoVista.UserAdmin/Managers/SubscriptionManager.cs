﻿using LagoVista.Core.Interfaces;
using LagoVista.Core.Managers;
using LagoVista.UserAdmin.Interfaces.Managers;
using LagoVista.UserAdmin.Interfaces.Repos.Orgs;
using System;
using System.Collections.Generic;
using LagoVista.Core.Models;
using LagoVista.Core.Validation;
using LagoVista.UserAdmin.Models.Orgs;
using System.Threading.Tasks;
using LagoVista.IoT.Logging.Loggers;

namespace LagoVista.UserAdmin.Managers
{
    public class SubscriptionManager : ManagerBase, ISubscriptionManager
    {
        ISubscriptionRepo _subscriptionRepo;
        public SubscriptionManager(ISubscriptionRepo subscriptionRepo, IDependencyManager depManager, ISecurity security, IAdminLogger logger, IAppConfig appConfig) : base(logger, appConfig, depManager, security)
        {
            _subscriptionRepo = subscriptionRepo;
        }

        public async Task<InvokeResult> AddSubscriptionAsync(Subscription subscription, EntityHeader org, EntityHeader user)
        {
            await AuthorizeAsync( user, org, "addSubscription", subscription);            

            await _subscriptionRepo.AddSubscriptionAsync(subscription);

            return new InvokeResult();
        }

        public async Task<DependentObjectCheckResult> CheckInUseAsync(Guid id, EntityHeader org, EntityHeader user)
        {
            var subscription = await _subscriptionRepo.GetSubscriptionAsync(id);
            await AuthorizeAsync(user, org, "getSubscription", subscription);

            return await CheckForDepenenciesAsync(subscription);            
        }

        public async Task<InvokeResult> DeleteSubscriptionAsync(Guid id, EntityHeader org, EntityHeader user)
        {
            var subscription = await _subscriptionRepo.GetSubscriptionAsync(id);
            await AuthorizeAsync(user, org, "deleteSubscription", subscription);
            await ConfirmNoDepenenciesAsync(subscription);

            await _subscriptionRepo.DeleteSubscriptionAsync(subscription.Id);

            return new InvokeResult();
        }

        public async Task<Subscription> GetSubscriptionAsync(Guid id, EntityHeader org, EntityHeader user)
        {
            var subscription = await _subscriptionRepo.GetSubscriptionAsync(id);
            await AuthorizeAsync(user, org, "getSubscription", subscription);

            return subscription;            
        }

        public async Task<IEnumerable<SubscriptionSummary>> GetSubscriptionsForOrgAsync(string orgId, EntityHeader user)
        {
            await AuthorizeOrgAccessAsync(user, orgId, typeof(SubscriptionSummary));

            return await _subscriptionRepo.GetSubscriptionsForOrgAsync(orgId);
        }

        public Task<bool> QueryKeyInUseAsync(string key, EntityHeader org)
        {
            return _subscriptionRepo.QueryKeyInUse(key, org.Id);
        }

        public async Task<InvokeResult> UpdateSubscriptionAsync(Subscription subscription, EntityHeader org, EntityHeader user)
        {
            await AuthorizeAsync(user, org, "updateSubscription", subscription);

            await _subscriptionRepo.UpdateSubscriptionAsync(subscription);

            return new InvokeResult();
        }
    }
}
