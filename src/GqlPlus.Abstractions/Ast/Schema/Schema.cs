namespace GqlPlus.Abstractions.Schema;

public interface IAstSchema
  : IAstAbbreviated
  , IEquatable<IAstSchema>
{
  IEnumerable<IAstDeclaration> Declarations { get; }

  ParseResultKind Result { get; }
  IMessages Errors { get; }
}

public interface IAstDeclaration
  : IAstAliased
{
  string Label { get; }
}

public interface IAstAliased
  : IAstNamed
  , IEquatable<IAstAliased>
{
  IEnumerable<string> Aliases { get; }

  bool IsNameOrAlias(string id);
}

public interface IAstDescribed
  : IAstAbbreviated
  , IEquatable<IAstDescribed>
{
  string Description { get; }
}

public interface IAstNamed
  : IAstDescribed
  , IEquatable<IAstNamed>
{
  string Name { get; }
}
