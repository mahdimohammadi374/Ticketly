﻿namespace Ticketly.Api.Extensions;

internal static class ConfigurationExtensions
{
    public static void AddModuleConfiguration(this IConfigurationBuilder configurationBuilder, string[] modules)
    {
        foreach (string module in modules)
        {
            configurationBuilder.AddJsonFile($"modules.{module}.json",false,true);
            configurationBuilder.AddJsonFile($"modules.{module}.Development.json", false, true);
        }
    }
}
