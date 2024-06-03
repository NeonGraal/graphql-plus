namespace GqlPlus.Abstractions.Schema;

public interface IGqlpSchema
  : IGqlpError
{
  IEnumerable<IGqlpDeclaration> Declarations { get; }

  ParseResultKind Result { get; }
  ITokenMessages Errors { get; }

  string Render();
}

public interface IGqlpDeclaration
  : IGqlpAliased
{
  string Label { get; }
}

public interface IGqlpAliased
  : IGqlpNamed, IGqlpDescribed
{
  IEnumerable<string> Aliases { get; }
}

public interface IGqlpDescribed
{
  string Description { get; }
}
