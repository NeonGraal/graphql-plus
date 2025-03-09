using System.Text;

namespace GqlPlus;

internal sealed class GeneratorContext
{
  private readonly StringBuilder _builder = new();

  public GeneratorContext(string path, GqlModelOptions options)
  {
    File = Path.GetFileNameWithoutExtension(path);
    Options = options;

    AppendLine("// Generated from " + path);
    AppendLine("\n/*");
  }

  public string File { get; }
  public GqlModelOptions Options { get; }

  public void AppendLine(string text)
    => _builder.AppendLine(text);
  public override string ToString()
    => _builder.ToString();
}
