
namespace GqlPlus.Abstractions.Schema;

public interface IGqlpType
  : IAstDeclaration
{
  TypeKind Kind { get; }
}

public interface IGqlpType<TParent>
  : IGqlpType
  , IEquatable<IGqlpType<TParent>>
  where TParent : IAstDescribed
{
  TParent? Parent { get; }
}

public interface IGqlpSimple
  : IGqlpType<IGqlpTypeRef>
{ }

public interface IGqlpTypeRef
  : IAstNamed
  , IEquatable<IGqlpTypeRef>
{ }

public interface IGqlpTypeSpecial
  : IGqlpSimple
{
  bool MatchesKindSpecial(HashSet<TypeKind> validKinds);
  bool MatchesTypeSpecial(IGqlpType type);
}

public enum TypeKind
{
  Internal,
  Special,

  Domain,
  Enum,
  Union,
  Dual,
  Input,
  Output,
}
