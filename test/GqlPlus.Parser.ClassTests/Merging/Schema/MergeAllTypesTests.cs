using GqlPlus.Abstractions.Schema;
using GqlPlus.Ast.Schema.Objects;
using GqlPlus.Ast.Schema.Simple;

namespace GqlPlus.Merging.Schema;

public class MergeAllTypesTests
  : TestAbbreviatedMerger<IAstType>
{
  [Theory, RepeatData]
  public void CanMerge_TwoAstsSameNameDifferentTypes_ReturnsErrors(string input)
    => CanMerge_Errors([MakeAst(input),
      new AstObject<IAstDualField>(TypeKind.Dual, AstNulls.At, input, "")]);

  [Theory, RepeatData]
  public void FixupType_WithDomainLabel_FixesType(string enumType, string enumLabel, string domainType)
  {
    this.SkipEqual(enumType, domainType);

    // Arrange
    DomainLabelAst domainLabel = new(AstNulls.At, "", false, enumLabel);

    IAstType[] types = [
      new EnumDeclAst(AstNulls.At, enumType, [new(AstNulls.At, enumLabel, "")]),
      new AstDomain<DomainLabelAst, IAstDomainLabel>(AstNulls.At, domainType, DomainKind.Enum, [domainLabel]),
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

    IAstType[] types = [
      new EnumDeclAst(AstNulls.At, enumType, [new(AstNulls.At, enumLabel, "")]),
      new AstObject < IAstOutputField > (TypeKind.Output, AstNulls.At, outputType, "") { ObjFields = [field] },
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
    this.SkipEqualAny([outputType, fieldType, enumType]);

    // Arrange
    TypeArgAst arg = new(AstNulls.At, "", "") {
      EnumValue = new EnumValueAst(AstNulls.At, enumLabel)
    };

    OutputFieldAst field = new(AstNulls.At, fieldName, new ObjBaseAst(AstNulls.At, fieldType, "") {
      Args = [arg]
    });

    IAstType[] types = [
      new EnumDeclAst(AstNulls.At, enumType, [new(AstNulls.At, enumLabel, "")]),
      new AstObject<IAstOutputField>(TypeKind.Output, AstNulls.At, outputType, "") { ObjFields = [field] },
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

    IAstType[] types = [
      new EnumDeclAst(AstNulls.At, enumType, [new(AstNulls.At, enumLabel, "")]),
      new AstObject<IAstOutputField>(TypeKind.Output, AstNulls.At, outputType, "") { Alternates = [alt] },
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
    this.SkipEqualAny([outputType, enumType, altType]);

    // Arrange
    TypeArgAst arg = new(AstNulls.At, "", "") {
      EnumValue = new EnumValueAst(AstNulls.At, enumLabel)
    };
    AlternateAst alt = new(AstNulls.At, altType, "") {
      Args = [arg]
    };

    IAstType[] types = [
      new EnumDeclAst(AstNulls.At, enumType, [new(AstNulls.At, enumLabel, "")]),
      new AstObject<IAstOutputField>(TypeKind.Output, AstNulls.At, outputType, "") { Alternates = [alt] },
    ];

    // Act

    _merger.Merge(types);

    // Assert
    arg.Name.ShouldBe(enumType);
    arg.EnumValue.EnumType.ShouldBe(enumType);
  }

  [Theory, RepeatData]
  public void FixupType_WithFieldTypeAsBuiltIn_DoesNotOverride(string enumType, string outputType, string fieldName)
  {
    this.SkipIf(enumType == BuiltIn.BooleanType);
    this.SkipEqual(outputType, enumType);

    // Arrange
    OutputFieldAst field = new(AstNulls.At, fieldName, new ObjBaseAst(AstNulls.At, BuiltIn.BooleanType, ""));

    IAstType[] types = [
      new EnumDeclAst(AstNulls.At, enumType, [new(AstNulls.At, BuiltIn.BooleanType, "")]),
      new AstObject<IAstOutputField>(TypeKind.Output, AstNulls.At, outputType, "") { ObjFields = [field] },
    ];

    // Act

    _merger.Merge(types);

    // Assert
    field.Type.Name.ShouldBe(BuiltIn.BooleanType);
  }

  private readonly MergeAllTypes _merger;

  public MergeAllTypesTests(ITestOutputHelper outputHelper)
  {
    IMergeAll<IAstType> result = Substitute.For<IMergeAll<IAstType>>();
    result.CanMerge([]).ReturnsForAnyArgs(EmptyMessages);
    result.Merge([]).ReturnsForAnyArgs(c => c.Arg<IEnumerable<IAstType>>());

    IMergerRepository mergers = MergeRepo(outputHelper.ToLoggerFactory());
    mergers.AllMergersFor<IAstType>().Returns([result]);
    _merger = new(mergers);
  }

  protected override IMerge<IAstType> MergerBase => _merger;

  protected override IAstType MakeAst(string input)
    => new EnumDeclAst(AstNulls.At, input, []);
}
