namespace GqlPlus.Generating.Objects;

public class OutputGeneratorTests
  : ObjectGeneratorTestBase<IGqlpOutputObject, IGqlpOutputField>
{
  public OutputGeneratorTests()
    : base(TypeKind.Output)
  { }

  internal override GenerateForType<IGqlpOutputObject> TypeGenerator { get; }
    = new OutputGenerator();
}
