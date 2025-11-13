using GqlPlus.Abstractions.Schema;
using GqlPlus.Ast.Schema.Objects;
using GqlPlus.Merging.Objects;

namespace GqlPlus.Merging.Schema.Objects;

public abstract class TestObjectMerger<TObjField>
  : TestTypedMerger<IGqlpType, IGqlpObject<TObjField>, IGqlpObjBase, TObjField>
  where TObjField : IGqlpObjField
{
  [Theory, RepeatData]
  public void CanMerge_TwoAstsTypeParamsCantMerge_ReturnsErrors(string name, string[] typeParams)
    => this
      .SkipUnless(typeParams)
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

  protected IMerge<IGqlpTypeParam> TypeParams { get; }
  protected IMerge<IGqlpAlternate> Alternates { get; }
  protected IMerge<TObjField> Fields { get; }

  protected TestObjectMerger(TypeKind kind)
  {
    _kind = kind;
    TypeParams = Merger<IGqlpTypeParam>();
    Alternates = Merger<IGqlpAlternate>();
    Fields = Merger<TObjField>();
  }

  private readonly TypeKind _kind;
  internal abstract AstObjectsMerger<TObjField> MergerObject { get; }
  internal override AstTypeMerger<IGqlpType, IGqlpObject<TObjField>, IGqlpObjBase, TObjField> MergerTyped => MergerObject;

  protected IGqlpObject<TObjField> MakeObject(
    string name,
    string[]? aliases = null,
    string description = "",
    IGqlpObjBase? parent = default,
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

  protected IGqlpObjBase MakeBase(string type)
    => new ObjBaseAst(AstNulls.At, type, "");

  protected abstract TObjField[] MakeFields(FieldInput[]? fields);

  protected override IGqlpObject<TObjField> MakeTyped(string name, string[]? aliases = null, string description = "", IGqlpObjBase? parent = default)
    => MakeObject(name, aliases, description, parent);
  protected override IGqlpObjBase? MakeParent(string? parent)
    => string.IsNullOrWhiteSpace(parent) ? null : MakeBase(parent!);
}
