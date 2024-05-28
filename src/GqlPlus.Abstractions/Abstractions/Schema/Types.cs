namespace GqlPlus.Abstractions.Schema;

public interface IGqlpType
  : IGqlpDeclaration
{ }

public interface IGqlpTypeSpecial
  : IGqlpType<string>
{ }

public interface IGqlpType<TParent>
  : IGqlpType
{
  TParent? Parent { get; }
}

public interface IGqlpCollection
{
  //* Value Opt is invalid
  ModifierKind CollectionKind { get; }
  IGqlpFieldKey? Key { get; }
}
