namespace GqlPlus.Generating.Simple;

public class DomainEnumEncoderGeneratorTests
  : GenerateDomainTestsBase<IAstDomainLabel>
{
  protected override DomainKind Kind => DomainKind.Enum;
  internal override GenerateBaseDomain<IAstDomainLabel> Generator { get; }
    = new DomainEnumEncoderGenerator();
  internal override GqlpGeneratorType GeneratorType => GqlpGeneratorType.Enc;
  internal override GqlpBaseType BaseType => GqlpBaseType.Class;

  internal override ForType ForGeneratedCodeName(string name)
    => _ => _ => { };

  internal override ForType ForGeneratedCodeParent(string parent)
    => _ => _ => { };

  internal override ForType ForGeneratedBoth(string contains)
    => ForGeneratedEncoder(contains);

  protected override IAstDomainLabel MakeDomainItem(string item)
    => A.ItemLabel("TestEnum", item);

  internal override ForType ForGeneratedItem(string name, string item)
    => ForGeneratedEncoder("input.Value?.EncodeEnum(\"tstTestEnum\") ?? Structured.Empty(\"tstTestEnum\")");
}
