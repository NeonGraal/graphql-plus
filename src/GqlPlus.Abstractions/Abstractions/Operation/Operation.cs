namespace GqlPlus.Abstractions.Operation;

public interface IGqlpOperation
  : IGqlpIdentified
  , IGqlpDirectives
  , IGqlpModifiers
  , IEquatable<IGqlpOperation>
{
  string Category { get; }

  IEnumerable<IGqlpVariable> Variables { get; }

  string? ResultType { get; }
  IGqlpArg? Arg { get; }
  IEnumerable<IGqlpSelection>? ResultObject { get; }

  IEnumerable<IGqlpFragment> Fragments { get; }

  ParseResultKind Result { get; }
  ITokenMessages Errors { get; }

  IEnumerable<IGqlpArg> Usages { get; }
  IEnumerable<IGqlpSpread> Spreads { get; }
}

public interface IGqlpIdentified
  : IGqlpAbbreviated
  , IEquatable<IGqlpIdentified>
{
  string Identifier { get; }
}

public interface IGqlpVariable
  : IGqlpIdentified
  , IGqlpDirectives
  , IGqlpModifiers
  , IEquatable<IGqlpVariable>
{
  string? Type { get; }
  IGqlpConstant? DefaultValue { get; }
}

public interface IGqlpDirectives
  : IGqlpError
  , IEquatable<IGqlpDirectives>
{
  IEnumerable<IGqlpDirective> Directives { get; init; }
}

public interface IGqlpDirective
  : IGqlpIdentified
{
  IGqlpArg? Arg { get; }
}

public interface IGqlpFragment
  : IGqlpIdentified
  , IGqlpDirectives
  , IEquatable<IGqlpFragment>
{
  string OnType { get; }
  IEnumerable<IGqlpSelection> Selections { get; }
}
