using GqlPlus.Abstractions.Schema;
using GqlPlus.Ast.Schema.Objects;

namespace GqlPlus.Modelling.Schema.Objects;

public class DualFieldModelTests(
  IDualFieldModelChecks checks
) : TestObjectFieldModel<IGqlpDualField, IGqlpDualBase, DualFieldModel>(checks)
{ }

internal sealed class DualFieldModelChecks(
  IModeller<IGqlpDualField, DualFieldModel> modeller,
  IEncoder<DualFieldModel> encoding
) : CheckObjectFieldModel<IGqlpDualField, DualFieldAst, IGqlpDualBase, DualFieldModel>(modeller, encoding, TypeKindModel.Dual)
  , IDualFieldModelChecks
{
  internal override DualFieldAst NewFieldAst(FieldInput input, string[] aliases, bool withModifiers)
    => new(AstNulls.At, input.Name, new DualBaseAst(AstNulls.At, input.Type)) {
      Aliases = aliases,
      Modifiers = withModifiers ? TestMods() : [],
    };
}

public interface IDualFieldModelChecks
  : ICheckObjectFieldModel<IGqlpDualField, DualFieldModel>
{ }
