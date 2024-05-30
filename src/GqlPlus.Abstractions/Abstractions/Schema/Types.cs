namespace GqlPlus.Abstractions.Schema;

public interface IGqlpType
  : IGqlpDeclaration
{ }

public interface IGqlpTypeSpecial
  : IGqlpType<string>
{ }

public interface IGqlpSimple
  : IGqlpType
{ }

public interface IGqlpType<TParent>
  : IGqlpType
{
  TParent? Parent { get; }
}
