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

public interface IGqlpType
  : IGqlpDeclaration
{ }

public interface IGqlpType<TParent>
  : IGqlpType
{
  TParent? Parent { get; }
}

public interface IGqlpAliased
  : IGqlpNamed, IGqlpDescribed
{
  IEnumerable<string> Aliases { get; }

  void SetAliases(string[] aliases, string description);
}

public interface IGqlpDescribed
{
  string Description { get; }
}
