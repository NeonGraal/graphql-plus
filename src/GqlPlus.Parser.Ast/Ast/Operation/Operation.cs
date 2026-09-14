namespace GqlPlus.Ast.Operation;

public interface IAstOperationBase
{
  string Category { get; }
  IEnumerable<IAstVariable> Variables { get; }
  IAstArg? Argument { get; }
  IMap<IAstSelection[]> Selections { get; }
  IEnumerable<IAstFragment> Fragments { get; }
}

public interface IAstOperation
  : IAstIdentified
  , IAstDirectives
  , IAstModifiers
  , IAstOperationBase
  , IEquatable<IAstOperation>
{
  string? Domain { get; }

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
  , IEquatable<IAstFragment>
{
  string OnType { get; }
}
