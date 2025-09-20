using GqlPlus.Abstractions.Schema;
using GqlPlus.Ast.Schema.Objects;
using GqlPlus.Ast.Schema.Simple;

namespace GqlPlus.Merging.Schema;

public class MergeAllTypesTests
  : TestAbbreviatedMerger<IGqlpType>
{
  [Theory, RepeatData]
  public void FixupType_WithEnums_FixesType(string outputType, string enumType, string enumLabel, string fieldName, string domainType)
  {
    this.SkipEqual3(outputType, enumType, domainType);

    // Arrange
    OutputFieldAst field = new(AstNulls.At, fieldName, new OutputBaseAst(AstNulls.At, "", "")) {
      EnumLabel = enumLabel
    };
    DomainLabelAst domainLabel = new(AstNulls.At, "", false, enumLabel);

    IGqlpType[] types = [
      new EnumDeclAst(AstNulls.At, enumType, [new(AstNulls.At, enumLabel, "")]),
      new OutputDeclAst(AstNulls.At, outputType) { ObjFields = [field] },
      new AstDomain<DomainLabelAst, IGqlpDomainLabel>(AstNulls.At, domainType, DomainKind.Enum, [domainLabel]),
    ];

    // Act

    _merger.Merge(types);

    // Assert
    field.Type.Name.ShouldBe(enumType);
    domainLabel.EnumType.ShouldBe(enumType);
  }

  private readonly MergeAllTypes _merger;

  public MergeAllTypesTests(ITestOutputHelper outputHelper)
  {
    IMergeAll<IGqlpType> result = Substitute.For<IMergeAll<IGqlpType>>();
    result.CanMerge([]).ReturnsForAnyArgs(EmptyMessages);
    result.Merge([]).ReturnsForAnyArgs(c => c.Arg<IEnumerable<IGqlpType>>());

    _merger = new(outputHelper.ToLoggerFactory(), [result]);
  }

  protected override IMerge<IGqlpType> MergerBase => _merger;

  protected override IGqlpType MakeAst(string input)
    => new EnumDeclAst(AstNulls.At, input, []);
}
