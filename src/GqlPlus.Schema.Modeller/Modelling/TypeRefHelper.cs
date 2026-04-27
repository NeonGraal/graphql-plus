using System.Diagnostics.CodeAnalysis;
using GqlPlus.Ast.Schema;

namespace GqlPlus.Modelling;

internal static class TypeRefHelper
{
  [return: NotNullIfNotNull(nameof(input))]
  internal static TypeRefModel<TKind>? TypeRef<TKind>(this IAstTypeRef? input, TKind kind)
    where TKind : Enum
    => input?.Name.TypeRef(kind, input.Description);
}
