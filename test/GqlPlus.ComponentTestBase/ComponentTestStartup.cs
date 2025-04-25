﻿using DiffEngine;
using GqlPlus.Merging;
using GqlPlus.Parsing;
using GqlPlus.Parsing.Operation;
using GqlPlus.Parsing.Schema;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Xunit.DependencyInjection.Logging;

namespace GqlPlus;

public static class ComponentTestStartup
{
  static ComponentTestStartup()
    => DiffRunner.MaxInstancesToLaunch(20);

  public static IServiceCollection AddComponentTest(this IServiceCollection services)
    => services
      .AddLogging(ConfigureComponentLogging)
      //.AddSkippableFactSupport()
      .AddTransient<ISchemaParseChecks, SchemaParseChecks>()
      .AddCommonParsers()
      .AddOperationParsers()
      .AddSchemaParsers()
      .AddMergers()
      .AddSingleton(_ => services);

  private static void ConfigureComponentLogging(ILoggingBuilder builder)
  {
    builder.AddFilter("NullVerifier", LogLevel.Warning);
    builder.AddXunitOutput(options => options.TimestampFormat = "HH:mm:ss.fff");
    if (string.IsNullOrWhiteSpace(Environment.GetEnvironmentVariable("GQLPLUS_VERIFIER_LOGGING"))) {
      builder.AddFilter("AstParentItemVerifier", LogLevel.Warning);
      builder.AddFilter("GroupedVerifier", LogLevel.Warning);
    }
  }

  private static readonly string s_projectDir = AttributeReader.GetProjectDirectory();

  public static void WriteHtmlFile(this string contents, string dir, string file)
  {
    string dirPath = Path.Join(s_projectDir, "..", "Html", dir);
    if (!Directory.Exists(dirPath)) {
      Directory.CreateDirectory(dirPath);
    }

    string filePath = Path.Join(dirPath, file + ".html");
    try {
      File.WriteAllText(filePath, contents);
    } catch (IOException) {
      Thread.Sleep(100);
      File.WriteAllText(filePath, contents);
    }
  }

  public static async Task WriteHtmlFileAsync(this ValueTask<string> contents, string dir, string file)
  {
    string dirPath = Path.Join(s_projectDir, "..", "Html", dir);
    if (!Directory.Exists(dirPath)) {
      Directory.CreateDirectory(dirPath);
    }

    string filePath = Path.Join(dirPath, file + ".html");

    try {
      await File.WriteAllTextAsync(filePath, await contents);
    } catch (IOException) {
      await Task.Delay(100);
      await File.WriteAllTextAsync(filePath, await contents);
    }
  }
}
