namespace GqlPlus.Abstractions.Operation;

public interface IAstOperation
  : IAstIdentified
  , IAstDirectives
  , IAstModifiers
  , IEquatable<IAstOperation>
{
  string Category { get; }

  IEnumerable<IAstVariable> Variables { get; }

  string? ResultType { get; }
  IGqlpArg? Arg { get; }
  IEnumerable<IGqlpSelection>? ResultObject { get; }

  IEnumerable<IAstFragment> Fragments { get; }

  ParseResultKind Result { get; }
  IMessages Errors { get; }

  IEnumerable<IGqlpArg> Usages { get; }
  IEnumerable<IGqlpSpread> Spreads { get; }
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
  IGqlpArg? Arg { get; }
}

public interface IAstSelections
{
  IEnumerable<IGqlpSelection> Selections { get; }
}

public interface IAstFragment
  : IAstIdentified
  , IAstDirectives
  , IAstSelections
  , IEquatable<IAstFragment>
{
  string OnType { get; }
}
