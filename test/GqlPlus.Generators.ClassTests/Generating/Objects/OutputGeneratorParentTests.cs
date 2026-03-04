using GqlPlus.Building.Schema.Objects;

namespace GqlPlus.Generating.Objects;

public class OutputGeneratorParentTests
  : GenerateObjectParentTestsBase<IGqlpOutputField>
{
  public OutputGeneratorParentTests()
    : base(TypeKind.Output)
  { }

  internal override GenerateForType<IGqlpObject<IGqlpOutputField>> TypeGenerator { get; }
    = new OutputGenerator();

  protected override ObjFieldBuilder<IGqlpOutputField> MakeField(string name, string type)
    => new OutputFieldBuilder(name, type);
}
