namespace GqlPlus.Encoding.Simple;

public class TypeUnionEncoderTests
  : ParentTypeEncoderClassTestBase<TypeUnionModel, NamedModel, UnionMemberModel, string>
{
  public TypeUnionEncoderTests()
    => Encoder = new TypeUnionEncoder(Encoders);

  protected override IEncoder<TypeUnionModel> Encoder { get; }
  protected override SimpleKindModel Kind => SimpleKindModel.Union;

  protected override UnionMemberModel NewAll(string item, string name) => new(item, name, "");
  protected override NamedModel NewItem(string item) => new(item, "");
  protected override TypeUnionModel NewModel(string name, string contents, TypeRefModel<SimpleKindModel>? parent)
    => new(name, contents) { Parent = parent };
}
