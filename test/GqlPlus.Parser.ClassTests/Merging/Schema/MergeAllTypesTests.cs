using GqlPlus.Abstractions.Schema;
using GqlPlus.Ast.Schema.Objects;
using GqlPlus.Ast.Schema.Simple;

namespace GqlPlus.Merging.Schema;

public class MergeAllTypesTests
  : TestAbbreviatedMerger<IGqlpType>
{
  [Theory, RepeatData]
  public void FixupType_WithDomainLabel_FixesType(string enumType, string enumLabel, string domainType)
  {
    this.SkipEqual(enumType, domainType);

    // Arrange
    DomainLabelAst domainLabel = new(AstNulls.At, "", false, enumLabel);

    IGqlpType[] types = [
      new EnumDeclAst(AstNulls.At, enumType, [new(AstNulls.At, enumLabel, "")]),
      new AstDomain<DomainLabelAst, IGqlpDomainLabel>(AstNulls.At, domainType, DomainKind.Enum, [domainLabel]),
    ];

    // Act

    _merger.Merge(types);

    // Assert
    domainLabel.EnumType.ShouldBe(enumType);
  }

  [Theory, RepeatData]
  public void FixupType_WithFieldLabel_FixesType(string enumType, string enumLabel, string outputType, string fieldName)
  {
    this.SkipEqual(outputType, enumType);

    // Arrange
    OutputFieldAst field = new(AstNulls.At, fieldName, new ObjBaseAst(AstNulls.At, "", "")) {
      EnumValue = new EnumValueAst(AstNulls.At, enumLabel)
    };

    IGqlpType[] types = [
      new EnumDeclAst(AstNulls.At, enumType, [new(AstNulls.At, enumLabel, "")]),
      new AstObject < IGqlpOutputField > (TypeKind.Output, AstNulls.At, outputType, "") { ObjFields = [field] },
    ];

    // Act

    _merger.Merge(types);

    // Assert
    field.Type.Name.ShouldBe(enumType);
    field.EnumValue.EnumType.ShouldBe(enumType);
  }

  [Theory, RepeatData]
  public void FixupType_WithFieldArgLabel_FixesType(string enumType, string enumLabel, string outputType, string fieldName, string fieldType)
  {
    this.SkipEqual3(outputType, fieldType, enumType);

    // Arrange
    TypeArgAst arg = new(AstNulls.At, "", "") {
      EnumValue = new EnumValueAst(AstNulls.At, enumLabel)
    };

    OutputFieldAst field = new(AstNulls.At, fieldName, new ObjBaseAst(AstNulls.At, fieldType, "") {
      Args = [arg]
    });

    IGqlpType[] types = [
      new EnumDeclAst(AstNulls.At, enumType, [new(AstNulls.At, enumLabel, "")]),
      new AstObject<IGqlpOutputField>(TypeKind.Output, AstNulls.At, outputType, "") { ObjFields = [field] },
    ];

    // Act

    _merger.Merge(types);

    // Assert
    arg.Name.ShouldBe(enumType);
    arg.EnumValue.EnumType.ShouldBe(enumType);
  }

  [Theory, RepeatData]
  public void FixupType_WithAltLabel_FixesType(string enumType, string enumLabel, string outputType)
  {
    this.SkipEqual(outputType, enumType);

    // Arrange
    AlternateAst alt = new(AstNulls.At, "", "") {
      EnumValue = new EnumValueAst(AstNulls.At, enumLabel)
    };

    IGqlpType[] types = [
      new EnumDeclAst(AstNulls.At, enumType, [new(AstNulls.At, enumLabel, "")]),
      new AstObject<IGqlpOutputField>(TypeKind.Output, AstNulls.At, outputType, "") { Alternates = [alt] },
    ];

    // Act

    _merger.Merge(types);

    // Assert
    alt.Name.ShouldBe(enumType);
    alt.EnumValue.EnumType.ShouldBe(enumType);
  }

  [Theory, RepeatData]
  public void FixupType_WithAltArgLabel_FixesType(string enumType, string enumLabel, string outputType, string altType)
  {
    this.SkipEqual3(outputType, enumType, altType);

    // Arrange
    TypeArgAst arg = new(AstNulls.At, "", "") {
      EnumValue = new EnumValueAst(AstNulls.At, enumLabel)
    };
    AlternateAst alt = new(AstNulls.At, altType, "") {
      Args = [arg]
    };

    IGqlpType[] types = [
      new EnumDeclAst(AstNulls.At, enumType, [new(AstNulls.At, enumLabel, "")]),
      new AstObject<IGqlpOutputField>(TypeKind.Output, AstNulls.At, outputType, "") { Alternates = [alt] },
    ];

    // Act

    _merger.Merge(types);

    // Assert
    arg.Name.ShouldBe(enumType);
    arg.EnumValue.EnumType.ShouldBe(enumType);
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
