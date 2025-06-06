﻿using Microsoft.AspNetCore.Mvc;
using Server.Models;

namespace Server.Controllers
{
    public class DiscoverEndpointController : Controller
    {
        [HttpGet("~/.well-known/openid-configuration")]
        public JsonResult Index()
        {
            var response = new DiscoveryResponse
            {
                issuer = "https://localhost:8066",
                authorization_endpoint = "https://localhost:8066/Identity/Authorize",
                token_endpoint = "https://localhost:8066/Identity/Token",
                token_endpoint_auth_methods_supported = new string[] { "client_secret_basic", "private_key_jwt" },
                token_endpoint_auth_signing_alg_values_supported = new string[] { "RS256", "ES256" },

                acr_values_supported = new string[] { "urn:mace:incommon:iap:silver", "urn:mace:incommon:iap:bronze" },
                response_types_supported = new string[] { "code", "code id_token", "id_token", "token id_token" },
                subject_types_supported = new string[] { "public", "pairwise" },

                userinfo_encryption_enc_values_supported = new string[] { "A128CBC-HS256", "A128GCM" },
                id_token_signing_alg_values_supported = new string[] { "RS256", "ES256", "HS256" },
                id_token_encryption_alg_values_supported = new string[] { "RSA1_5", "A128KW" },
                id_token_encryption_enc_values_supported = new string[] { "A128CBC-HS256", "A128GCM" },
                request_object_signing_alg_values_supported = new string[] { "none", "RS256", "ES256" },
                display_values_supported = new string[] { "page", "popup" },
                claim_types_supported = new string[] { "normal", "distributed" },

                scopes_supported = new string[] { "openid", "profile", "email", "address", "phone", "offline_access" },
                claims_supported = new string[] { "sub", "iss", "auth_time", "acr", "name", "given_name",
                    "family_name", "nickname", "profile", "picture", "website", "email", "email_verified",
                    "locale", "zoneinfo" },
                claims_parameter_supported = true,
                service_documentation = "https://localhost:7275/connect/service_documentation.html",
                ui_locales_supported = new string[] { "en-US", "en-GB", "en-CA", "fr-FR", "fr-CA" }

            };
            return Json(response);
        }
    }
}
