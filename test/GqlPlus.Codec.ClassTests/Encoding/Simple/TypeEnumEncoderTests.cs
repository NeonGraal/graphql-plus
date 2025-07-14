namespace GqlPlus.Encoding.Simple;

public class TypeEnumEncoderTests
  : ParentTypeEncoderClassTestBase<TypeEnumModel, AliasedModel, EnumLabelModel, string>
{
  public TypeEnumEncoderTests()
    => Encoder = new TypeEnumEncoder(Encoders);

  protected override IEncoder<TypeEnumModel> Encoder { get; }
  protected override SimpleKindModel Kind => SimpleKindModel.Enum;

  protected override EnumLabelModel NewAll(string item, string name) => new(item, name, "");
  protected override AliasedModel NewItem(string item) => new(item, "");
  protected override TypeEnumModel NewModel(string name, string contents, TypeRefModel<SimpleKindModel>? parent)
    => new(name, contents) { Parent = parent };
}
