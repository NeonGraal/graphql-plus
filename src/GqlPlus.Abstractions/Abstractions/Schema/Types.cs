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

public interface IGqlpSimple
  : IGqlpType<string>
{ }
