﻿// Copyright (c) Brock Allen & Dominick Baier. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.


using IdentityServer4;
using IdentityServer4.Models;
using System.Collections.Generic;

namespace MultiShop.IdentityServer
{
    public static class Config
    {
        public static IEnumerable<ApiResource> ApiResources => new ApiResource[]
        {
            new ApiResource("ResourceCatalog")
            {
                Scopes = {"CatalogFullPermission", "CatalogReadPermission"}
            },
            new ApiResource("ResourceDiscount")
            {
                Scopes = {"DiscountFullPermission"}
            },
            new ApiResource("ResourceOrder")
            {
                Scopes = {"OrderFullPermission"}
            },
            new ApiResource("ResourceCargo")
            {
                Scopes = {"CargoFullPermission", "CargoReadPermission"}
            },
            new ApiResource("ResourceBasket")
            {
                Scopes = {"BasketFullPermission"}
            },
            new ApiResource(IdentityServerConstants.LocalApi.ScopeName)
        };

        public static IEnumerable<IdentityResource> IdentityResources => new IdentityResource[]
        {
            new IdentityResources.OpenId(),
            new IdentityResources.Email(),
            new IdentityResources.Profile()
        };

        public static IEnumerable<ApiScope> ApiScopes => new ApiScope[]
        {
            new ApiScope("CatalogFullPermission", "Full authority for catalog oprerations"),
            new ApiScope("CatalogReadPermission", "Reading authority for catalog oprerations"),
            new ApiScope("DiscountFullPermission", "Full authority for discount oprerations"),
            new ApiScope("OrderFullPermission", "Full authority for order oprerations"),
            new ApiScope("CargoFullPermission", "Full authority for cargo oprerations"),
            new ApiScope("CargoReadPermission", "Reading authority for cargo oprerations"),
            new ApiScope("BasketFullPermission", "Reading authority for basket oprerations"),
            new ApiScope(IdentityServerConstants.LocalApi.ScopeName)
        };

        public static IEnumerable<Client> Clients => new Client[]
        {
            //Visitor
            new Client
            {
                ClientId = "MultiShopVisitorId",
                ClientName = "MultiShop Visitor User",
                AllowedGrantTypes = GrantTypes.ClientCredentials,
                ClientSecrets = {new Secret("multishopsecret".Sha256())},
                AllowedScopes =
                {
                    "DiscountFullPermission",
                    "CatalogReadPermission"
                }                
            },

            //Manager
            new Client
            {
                ClientId = "MultiShopManagerId",
                ClientName = "MultiShop Manager User",
                AllowedGrantTypes = GrantTypes.ResourceOwnerPassword,
                ClientSecrets = {new Secret("multishopsecret".Sha256())},
                AllowedScopes =
                {
                    "CatalogFullPermission",
                    "CatalogReadPremission",
                    "DiscountFullPermission",
                    "CargoReadPermission"
                }
            },

            //Admin
            new Client
            {
                ClientId = "MultiShopAdminId",
                ClientName = "MultiShop Admin User",
                AllowedGrantTypes = GrantTypes.ResourceOwnerPassword,
                ClientSecrets = {new Secret("multishopsecret".Sha256())},
                AllowedScopes =
                {
                    "CatalogFullPermission",
                    "CatalogReadPremission",
                    "DiscountFullPermission",
                    "OrderFullPermission",
                    "CargoReadPermission",
                    "CargoFullPermission",
                    "BasketFullPermission",
                    IdentityServerConstants.LocalApi.ScopeName,
                    IdentityServerConstants.StandardScopes.Email,
                    IdentityServerConstants.StandardScopes.OpenId,
                    IdentityServerConstants.StandardScopes.Profile,
                },
                AccessTokenLifetime = 600
            }
        };
    }
}