namespace GqlPlus.Abstractions.Operation;

public interface IGqlpOperation
  : IGqlpIdentified, IGqlpDirectives, IGqlpModifiers
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
{
  string Identifier { get; }
}

public interface IGqlpVariable
  : IGqlpIdentified, IGqlpDirectives, IGqlpModifiers
{
  string? Type { get; }
  IGqlpConstant? DefaultValue { get; }
}

public interface IGqlpDirectives
{
  IEnumerable<IGqlpDirective> Directives { get; init; }
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
  : IGqlpIdentified, IGqlpDirectives, IGqlpSelections
{
  string OnType { get; }
}
