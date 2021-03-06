﻿using LagoVista.Core.Attributes;
using LagoVista.Core.Models;
using LagoVista.UserAdmin.Models;
using LagoVista.UserAdmin.Models.Resources;
using LagoVista.UserAdmin.Resources;
using System;
using System.Collections.Generic;

namespace LagoVista.UserAdmin.ViewModels.Organization
{
    [EntityDescription(Domains.OrganizationViewModels, UserAdminResources.Names.OrganizationDetailVM_Title, UserAdminResources.Names.OrganizationDetailVM_Help, UserAdminResources.Names.OrganizationDetailsVM_Description, EntityDescriptionAttribute.EntityTypes.ViewModel, typeof(UserAdminResources))]
    public class OrganizationDetailsViewModel
    {
        public String OrganizationName { get; set; }
        public Models.Orgs.Organization Organization { get; set; }
        public IEnumerable<UserInfoSummary> People { get; set; }
        public IEnumerable<Models.Orgs.OrgLocation> Locations { get; set; }
    }
}
