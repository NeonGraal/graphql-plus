namespace GqlPlus.Generating.Simple;

public class DomainEnumEncoderGeneratorTests
  : GenerateDomainTestsBase<IAstDomainLabel, EnumLabelInput>
{
  protected override DomainKind Kind => DomainKind.Enum;
  internal override GenerateBaseDomain<IAstDomainLabel> Generator { get; }
    = new DomainEnumEncoderGenerator();
  internal override GqlpGeneratorType GeneratorType => GqlpGeneratorType.Enc;
  internal override GqlpBaseType BaseType => GqlpBaseType.Class;

  internal override ForType ForGeneratedCodeName(string name)
    => _ => r => {
      if (!string.IsNullOrWhiteSpace(r)) {
        r.ShouldContain(TestPrefix + name + "Encoder");
      }
    };

  internal override ForType ForGeneratedCodeParent(string parent)
    => _ => r => r.ShouldNotContain(": " + parent);

  internal override ForType ForGeneratedBoth(string contains)
    => ForGeneratedEncoder(contains);

  protected override IAstDomainLabel MakeDomainItem(EnumLabelInput item)
    => A.ItemLabel(item.EnumType, item.Label);

  internal override ForType ForGeneratedItem(string name, EnumLabelInput item)
    => ForGeneratedEncoder($"input.Value?.EncodeEnum(\"tst{item.EnumType}\")!;");

  internal override ForType[] ForGeneratedItems(string name, EnumLabelInput[] items)
    => [ForGeneratedCodeName(name),
      ForGeneratedEncoder($"input.Value?.EncodeEnum(\"{name}\")!;")];
}
