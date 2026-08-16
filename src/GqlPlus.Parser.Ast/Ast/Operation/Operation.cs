namespace GqlPlus.Ast.Operation;

public interface IAstOperation
  : IAstIdentified
  , IAstDirectives
  , IAstModifiers
  , IEquatable<IAstOperation>
{
  string Category { get; }

  IEnumerable<IAstVariable> Variables { get; }

  string? Domain { get; }
  IAstArg? Arg { get; }

  IEnumerable<IAstFragment> Fragments { get; }

  IMap<IAstOpSelection[]> Selections { get; }

  ParseResultKind Result { get; }
  IMessages Errors { get; }

  IEnumerable<IAstArg> Usages { get; }
  IEnumerable<IAstSpread> Spreads { get; }
}

public interface IAstOpSelection
  : IAstError
  , IAstDirectives
  , IAstModifiers;

public interface IAstOpField
  : IAstIdentified
  , IAstOpSelection
  , IEquatable<IAstOpField>
{
  string? FieldAlias { get; }
  IAstArg? Arg { get; }
}

public interface IAstOpInline
  : IAstAbbreviated
  , IAstOpSelection
  , IEquatable<IAstOpInline>
{
  string? OnType { get; }
}

public interface IAstOpSpread
  : IAstIdentified
  , IAstOpSelection
  , IEquatable<IAstOpSpread>;

public interface IAstIdentified
  : IAstAbbreviated
  , IEquatable<IAstIdentified>
{
  string Identifier { get; }
}

public interface IAstVariable
  : IAstIdentified
  , IAstDirectives
  , IAstModifiers
  , IEquatable<IAstVariable>
{
  string? Type { get; }
  IAstConstant? DefaultValue { get; }
}

public interface IAstDirectives
  : IAstAbbreviated
{
  IEnumerable<IAstDirective> Directives { get; }
}

public interface IAstDirective
  : IAstIdentified
{
  IAstArg? Arg { get; }
}

public interface IAstSelections
{
  IEnumerable<IAstSelection> Selections { get; }
}

public interface IAstFragment
  : IAstIdentified
  , IAstDirectives
  , IAstSelections
  , IEquatable<IAstFragment>
{
  string OnType { get; }
}
