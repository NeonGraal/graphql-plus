using System.Text;
using System.Text.RegularExpressions;

namespace GqlPlus;

internal sealed class GqlpGeneratorContext
  : GqlpGeneratorTypes
{
  private readonly StringBuilder _builder = new();
  private readonly StringBuilder _prefix;
  private bool _prefixWritten;

  public GqlpGeneratorContext(string path, GqlpGeneratorOptions generatorOptions, GqlpModelOptions modelOptions)
    : base(modelOptions)
  {
    File = Path.GetFileNameWithoutExtension(path);
    GeneratorOptions = generatorOptions;

    _prefix = new();
    _prefix.AppendLine($"// Generated from {path}");
    _prefix.AppendLine($"//   with GeneratorOption: {GeneratorOptions}");
    _prefix.AppendLine($"//   and ModelOption: {ModelOptions}");

    AddTypes(BuiltIn.Internal);
    AddTypes(BuiltIn.Basic);
  }

  public string File { get; }
  public GqlpGeneratorOptions GeneratorOptions { get; }

  public string FileName => $"{ModelOptions.TypePrefix}_{File}_{GeneratorOptions.GeneratorType}.gen.cs";
  public string SafeFile => Safe(File);

  private readonly Regex _unsafeRegex = new(@"[^_a-zA-Z0-9]+");

  public string Safe(string unsafeName)
    => _unsafeRegex.Replace(unsafeName, "_");

  private readonly List<CodecRegistration> _decoderRegistrations = [];
  public IReadOnlyList<CodecRegistration> DecoderRegistrations => _decoderRegistrations;

  public void RegisterDecoder(string serviceType, string implType, bool needsRepo = false)
    => _decoderRegistrations.Add(new(serviceType, implType, needsRepo));

  private readonly List<CodecRegistration> _encoderRegistrations = [];
  public IReadOnlyList<CodecRegistration> EncoderRegistrations => _encoderRegistrations;

  public void RegisterEncoder(string serviceType, string implType, bool needsRepo = false)
    => _encoderRegistrations.Add(new(serviceType, implType, needsRepo));

  public void WritePrefixLine(string text)
    => (_prefixWritten ? _builder : _prefix).AppendLine(text);

  public void Write(string text)
  {
    if (!_prefixWritten) {
      _prefixWritten = true;
      string prefix = _prefix.ToString();
      if (!string.IsNullOrWhiteSpace(prefix)) {
        _builder.AppendLine(prefix);
      }

      if (string.IsNullOrWhiteSpace(text)) {
        return;
      }
    }

    _builder.AppendLine(text);
  }

  public override string ToString()
    => _builder.ToString();
}

internal record struct CodecRegistration(string ServiceType, string ImplType, bool NeedsRepo);
