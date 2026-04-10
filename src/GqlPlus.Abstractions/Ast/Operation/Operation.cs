namespace GqlPlus.Abstractions.Operation;

public interface IGqlpOperation
  : IGqlpIdentified
  , IGqlpDirectives
  , IAstModifiers
  , IEquatable<IGqlpOperation>
{
  string Category { get; }

  IEnumerable<IGqlpVariable> Variables { get; }

  string? ResultType { get; }
  IGqlpArg? Arg { get; }
  IEnumerable<IGqlpSelection>? ResultObject { get; }

  IEnumerable<IGqlpFragment> Fragments { get; }

  ParseResultKind Result { get; }
  IMessages Errors { get; }

  IEnumerable<IGqlpArg> Usages { get; }
  IEnumerable<IGqlpSpread> Spreads { get; }
}

public interface IGqlpIdentified
  : IAstAbbreviated
  , IEquatable<IGqlpIdentified>
{
  string Identifier { get; }
}

public interface IGqlpVariable
  : IGqlpIdentified
  , IGqlpDirectives
  , IAstModifiers
  , IEquatable<IGqlpVariable>
{
  string? Type { get; }
  IAstConstant? DefaultValue { get; }
}

public interface IGqlpDirectives
  : IAstAbbreviated
{
  IEnumerable<IGqlpDirective> Directives { get; }
}

public interface IGqlpDirective
  : IGqlpIdentified
{
  IGqlpArg? Arg { get; }
}

public interface IGqlpSelections
{
  IEnumerable<IGqlpSelection> Selections { get; }
}

public interface IGqlpFragment
  : IGqlpIdentified
  , IGqlpDirectives
  , IGqlpSelections
  , IEquatable<IGqlpFragment>
{
  string OnType { get; }
}
