namespace GqlPlus.Abstractions.Schema;

public interface IGqlpType
  : IGqlpDeclaration
{ }

public interface IGqlpType<TParent>
  : IGqlpType
  , IEquatable<IGqlpType<TParent>>
  where TParent : IGqlpDescribed
{
  TParent? Parent { get; }
}

public interface IGqlpSimple
  : IGqlpType<IGqlpTypeRef>
{ }

public interface IGqlpTypeRef
  : IGqlpNamed
  , IEquatable<IGqlpTypeRef>
{ }

public interface IGqlpTypeSpecial
  : IGqlpSimple
{
  bool MatchesTypeSpecial(IGqlpType type);
}
