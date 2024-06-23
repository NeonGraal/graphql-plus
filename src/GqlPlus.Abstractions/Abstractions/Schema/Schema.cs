namespace GqlPlus.Abstractions.Schema;

public interface IGqlpSchema
  : IGqlpError
{
  IEnumerable<IGqlpDeclaration> Declarations { get; }

  ParseResultKind Result { get; }
  ITokenMessages Errors { get; }

  string Show();
}

public interface IGqlpDeclaration
  : IGqlpAliased
{
  string Label { get; }
}

public interface IGqlpAliased
  : IGqlpNamed
  , IGqlpDescribed
{
  IEnumerable<string> Aliases { get; }
}

public interface IGqlpDescribed
{
  string Description { get; }
}
