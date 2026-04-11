namespace GqlPlus.Ast.Operation;

public interface IAstOperation
  : IAstIdentified
  , IAstDirectives
  , IAstModifiers
  , IEquatable<IAstOperation>
{
  string Category { get; }

  IEnumerable<IAstVariable> Variables { get; }

  string? ResultType { get; }
  IAstArg? Arg { get; }
  IEnumerable<IAstSelection>? ResultObject { get; }

  IEnumerable<IAstFragment> Fragments { get; }

  ParseResultKind Result { get; }
  IMessages Errors { get; }

  IEnumerable<IAstArg> Usages { get; }
  IEnumerable<IAstSpread> Spreads { get; }
}

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
