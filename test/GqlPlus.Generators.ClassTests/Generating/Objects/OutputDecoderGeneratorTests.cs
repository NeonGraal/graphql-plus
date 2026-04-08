using GqlPlus.Building.Schema.Objects;

namespace GqlPlus.Generating.Objects;

public class OutputDecoderGeneratorTests
  : GenerateObjectTestsBase<IGqlpOutputField>
{
  public OutputDecoderGeneratorTests()
    : base(TypeKind.Output)
  { }

  internal override GenerateForType<IGqlpObject<IGqlpOutputField>> TypeGenerator { get; }
    = new OutputDecoderGenerator();
  internal override GqlpGeneratorType GeneratorType => GqlpGeneratorType.Dec;
  internal override GqlpBaseType BaseType => GqlpBaseType.Class;

  internal override ForType ForGeneratedCodeName(string name)
  {
    int bracketIdx = name.IndexOf('<', StringComparison.Ordinal);
    string baseName = bracketIdx >= 0 ? name[..bracketIdx] : name;
    return ForGeneratedDecoder("internal class " + TestPrefix + baseName + "Decoder");
  }

  internal override ForType ForGeneratedCodeParent(string parent)
    => _ => _ => { };

  internal override ForType ForGeneratedBoth(string contains)
    => ForGeneratedDecoder(contains);

  internal override ForType ForGeneratedModel(string contains)
    => _ => result => { };

  protected override ObjFieldBuilder<IGqlpOutputField> MakeField(string name, string type)
    => new OutputFieldBuilder(name, type);
}
