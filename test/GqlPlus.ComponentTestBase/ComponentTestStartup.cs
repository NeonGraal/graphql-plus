using DiffEngine;
using GqlPlus.Merging;
using GqlPlus.Parsing;
using GqlPlus.Parsing.Operation;
using GqlPlus.Parsing.Schema;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Xunit.DependencyInjection;
using Xunit.DependencyInjection.Logging;

namespace GqlPlus;

public static class ComponentTestStartup
{
  static ComponentTestStartup()
    => DiffRunner.MaxInstancesToLaunch(20);

  public static IServiceCollection AddComponentTest(this IServiceCollection services)
    => services
      .AddLogging(lb => lb
        .AddXunitOutput(options => options.TimestampFormat = "HH:mm:ss.fff")
        .AddFilter("NullVerifier", LogLevel.Warning)
      )
      .AddSkippableFactSupport()
      .AddCommonParsers()
      .AddOperationParsers()
      .AddSchemaParsers()
      .AddMergers()
      .AddSingleton(_ => services);

  private static readonly string s_projectDir = AttributeReader.GetProjectDirectory();

  public static void WriteHtmlFile(this string contents, string dir, string file)
  {
    string dirPath = Path.Join(s_projectDir, "..", "Html", dir);
    if (!Directory.Exists(dirPath)) {
      Directory.CreateDirectory(dirPath);
    }

    string filePath = Path.Join(dirPath, file + ".html");
    File.WriteAllText(filePath, contents);
  }

  public static async Task WriteHtmlFileAsync(this ValueTask<string> contents, string dir, string file)
  {
    string dirPath = Path.Join(s_projectDir, "..", "Html", dir);
    if (!Directory.Exists(dirPath)) {
      Directory.CreateDirectory(dirPath);
    }

    string filePath = Path.Join(dirPath, file + ".html");
    await File.WriteAllTextAsync(filePath, await contents);
  }
}
