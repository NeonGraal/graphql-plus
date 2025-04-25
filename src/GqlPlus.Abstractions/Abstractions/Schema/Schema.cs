namespace GqlPlus.Abstractions.Schema;

public interface IGqlpSchema
  : IGqlpAbbreviated
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
{
  IEnumerable<string> Aliases { get; }

  bool IsNameOrAlias(string id);
}

public interface IGqlpDescribed
  : IGqlpAbbreviated
{
  string Description { get; }
}

public interface IGqlpNamed
  : IGqlpDescribed
{
  string Name { get; }
}
