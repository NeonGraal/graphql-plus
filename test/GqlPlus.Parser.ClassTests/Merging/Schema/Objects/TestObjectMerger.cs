using GqlPlus.Ast.Schema;
using GqlPlus.Ast.Schema.Objects;
using GqlPlus.Merging.Objects;

namespace GqlPlus.Merging.Schema.Objects;

public abstract class TestObjectMerger<TObjField>
  : TestTypedMerger<IAstType, IAstObject<TObjField>, IAstObjBase, TObjField>
  where TObjField : IAstObjField
{
  [Theory, RepeatData]
  public void CanMerge_TwoAstsTypeParamsCantMerge_ReturnsErrors(string name, string[] typeParams)
    => this
      .SkipShortArray(typeParams)
      .CanMergeReturnsError(TypeParams)
      .CanMerge_Errors(
        MakeObject(name, typeParams: typeParams),
        MakeObject(name, typeParams: typeParams));

  [Theory, RepeatData]
  public void CanMerge_TwoAstsAlternatesCantMerge_ReturnsErrors(string name, TypeInput[] alternates)
    => this
      .CanMergeReturnsError(Alternates)
      .CanMerge_Errors(
        MakeObject(name, alternates: alternates),
        MakeObject(name, alternates: alternates));

  [Theory, RepeatData]
  public void CanMerge_TwoAstsFieldsCantMerge_ReturnsErrors(string name, FieldInput[] fields)
    => this
      .CanMergeReturnsError(Fields)
      .CanMerge_Errors(
        MakeObject(name, fields: fields),
        MakeObject(name, fields: fields));

  protected IMerge<IAstTypeParam> TypeParams { get; }
  protected IMerge<IAstAlternate> Alternates { get; }
  protected IMerge<TObjField> Fields { get; }

  protected TestObjectMerger(TypeKind kind)
  {
    _kind = kind;
    TypeParams = Merger<IAstTypeParam>();
    Alternates = Merger<IAstAlternate>();
    Fields = Merger<TObjField>();
  }

  private readonly TypeKind _kind;
  internal abstract AstObjectsMerger<TObjField> MergerObject { get; }
  internal override AstTypeMerger<IAstType, IAstObject<TObjField>, IAstObjBase, TObjField> MergerTyped => MergerObject;

  protected IAstObject<TObjField> MakeObject(
    string name,
    string[]? aliases = null,
    string description = "",
    IAstObjBase? parent = default,
    string[]? typeParams = null,
    FieldInput[]? fields = null,
    TypeInput[]? alternates = null)
    => new AstObject<TObjField>(_kind, AstNulls.At, name, description) {
      Aliases = aliases ?? [],
      Parent = parent,
      TypeParams = typeParams?.TypeParams() ?? [],
      ObjFields = MakeFields(fields),
      Alternates = alternates?.Alternates() ?? []
    };

  protected IAstObjBase MakeBase(string type)
    => new ObjBaseAst(AstNulls.At, type, "");

  protected abstract TObjField[] MakeFields(FieldInput[]? fields);

  protected override IAstObject<TObjField> MakeTyped(string name, string[]? aliases = null, string description = "", IAstObjBase? parent = default)
    => MakeObject(name, aliases, description, parent);
  protected override IAstObjBase? MakeParent(string? parent)
    => string.IsNullOrWhiteSpace(parent) ? null : MakeBase(parent!);
}
