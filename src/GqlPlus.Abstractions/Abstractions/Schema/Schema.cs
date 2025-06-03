namespace GqlPlus.Abstractions.Schema;

public interface IGqlpSchema
  : IGqlpAbbreviated
  , IEquatable<IGqlpSchema>
{
  IEnumerable<IGqlpDeclaration> Declarations { get; }

  ParseResultKind Result { get; }
  ITokenMessages Errors { get; }
}

public interface IGqlpDeclaration
  : IGqlpAliased
{
  string Label { get; }
}

public interface IGqlpAliased
  : IGqlpNamed
  , IEquatable<IGqlpAliased>
{
  IEnumerable<string> Aliases { get; }

  bool IsNameOrAlias(string id);
}

public interface IGqlpDescribed
  : IGqlpAbbreviated
  , IEquatable<IGqlpDescribed>
{
  string Description { get; }
}

public interface IGqlpNamed
  : IGqlpDescribed
  , IEquatable<IGqlpNamed>
{
  string Name { get; }
}
