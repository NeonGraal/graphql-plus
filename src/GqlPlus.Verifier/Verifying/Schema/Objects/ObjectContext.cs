using GqlPlus.Abstractions.Schema;

namespace GqlPlus.Verifying.Schema.Objects;

public class ObjectContext(
  IMap<IGqlpDescribed> types,
  IMessages errors,
  IMap<string> enumValues,
  TypeKind kind
) : EnumContext(types, errors, enumValues)
{
  private static readonly TypeKind[] s_notObjectKinds = [
    .. Enum.GetValues(typeof(TypeKind)).Cast<TypeKind>().Where(k => k <= TypeKind.Dual)];

  internal HashSet<TypeKind> ParentKinds { get; } = [kind, TypeKind.Dual];
  internal HashSet<TypeKind> FieldKinds { get; } = [kind, .. s_notObjectKinds];
}
