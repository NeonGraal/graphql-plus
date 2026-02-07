using DiffEngine;
using GqlPlus.Merging;
using GqlPlus.Parsing;
using GqlPlus.Parsing.Schema;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Xunit.DependencyInjection.Logging;

namespace GqlPlus;

public static class ComponentTestStartup
{
  static ComponentTestStartup()
    => DiffRunner.MaxInstancesToLaunch(20);

  public static IServiceCollection AddComponentTest(this IServiceCollection services, bool checkEnv = true)
    => services
      .AddLogging(lb => {
        lb.AddFilter("NullVerifier", LogLevel.Warning);
        lb.AddXunitOutput(options => options.TimestampFormat = "HH:mm:ss.fff");
        if (checkEnv && string.IsNullOrWhiteSpace(Environment.GetEnvironmentVariable("GQLPLUS_TEST_LOGGING"))) {
          lb.AddFilter(l => l == LogLevel.Critical);
        }
      })
      .AddFieldObjectKinds()
      .AddCommonParsers()
      .AddSingleton(_ => services);

  public static IServiceCollection AddComponentParsers(this IServiceCollection services, bool checkEnv = true)
    => services
      .AddComponentTest(checkEnv)
      .AddTransient<ISchemaParseChecks, SchemaParseChecks>()
      .AddSchemaParsers()
      .AddMergers();

  private static readonly string s_projectDir = AttributeReader.GetProjectDirectory();

  public static void WriteHtmlFile(this string contents, string dir, string file)
  {
    string dirPath = Path.Join(s_projectDir, "..", "Html", dir);
    if (!Directory.Exists(dirPath)) {
      Directory.CreateDirectory(dirPath);
    }

    string filePath = Path.Join(dirPath, file + ".html");
    const int MaxAttempts = 8;
    for (int attempt = 1; attempt <= MaxAttempts; ++attempt) {
      try {
        File.WriteAllText(filePath, contents);
        return;
      } catch (IOException) {
        if (attempt >= MaxAttempts) throw;
        Thread.Sleep(50 * attempt);
      } catch (UnauthorizedAccessException) {
        if (attempt >= MaxAttempts) throw;
        Thread.Sleep(50 * attempt);
      }
    }
  }

  public static async Task WriteHtmlFileAsync(this ValueTask<string> contents, string dir, string file)
  {
    string dirPath = Path.Join(s_projectDir, "..", "Html", dir);
    if (!Directory.Exists(dirPath)) {
      Directory.CreateDirectory(dirPath);
    }

    string filePath = Path.Join(dirPath, file + ".html");
    const int MaxAttempts = 8;
    string text = await contents;
    for (int attempt = 1; attempt <= MaxAttempts; ++attempt) {
      try {
        await File.WriteAllTextAsync(filePath, text);
        return;
      } catch (IOException) {
        if (attempt >= MaxAttempts) throw;
        await Task.Delay(50 * attempt);
      } catch (UnauthorizedAccessException) {
        if (attempt >= MaxAttempts) throw;
        await Task.Delay(50 * attempt);
      }
    }
  }
}
