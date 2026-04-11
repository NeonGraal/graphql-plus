namespace GqlPlus.Ast.Schema;

public interface IAstType
  : IAstDeclaration
{
  TypeKind Kind { get; }
}

public interface IAstType<TParent>
  : IAstType
  , IEquatable<IAstType<TParent>>
  where TParent : IAstDescribed
{
  TParent? Parent { get; }
}

public interface IAstSimple
  : IAstType<IAstTypeRef>
{ }

public interface IAstTypeRef
  : IAstNamed
  , IEquatable<IAstTypeRef>
{ }

public interface IAstTypeSpecial
  : IAstSimple
{
  bool MatchesKindSpecial(HashSet<TypeKind> validKinds);
  bool MatchesTypeSpecial(IAstType type);
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
