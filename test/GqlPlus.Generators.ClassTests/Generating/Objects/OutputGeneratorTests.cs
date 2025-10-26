namespace GqlPlus.Generating.Objects;

public class OutputGeneratorTests
  : GenerateObjectTestsBase<IGqlpOutputObject, IGqlpOutputField>
{
  public OutputGeneratorTests()
    : base(TypeKind.Output)
  { }

  internal override GenerateForType<IGqlpOutputObject> TypeGenerator { get; }
    = new OutputGenerator();
}
