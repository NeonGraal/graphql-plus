namespace GqlPlus.Abstractions.Schema;

public interface IGqlpType
  : IGqlpDeclaration
{ }

public interface IGqlpType<TParent>
  : IGqlpType
  , IEquatable<IGqlpType<TParent>>
{
  TParent? Parent { get; }
}

public interface IGqlpSimple
  : IGqlpType<string>
{ }

public interface IGqlpTypeRef
  : IGqlpNamed
{ }

public interface IGqlpTypeSpecial
  : IGqlpSimple
{ }
