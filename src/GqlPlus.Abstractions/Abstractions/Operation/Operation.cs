namespace GqlPlus.Abstractions.Operation;

public interface IGqlpOperation
  : IGqlpNamed, IGqlpDirectives, IGqlpModifiers
{
  string Category { get; }

  IEnumerable<IGqlpVariable> Variables { get; }

  string? ResultType { get; }
  IGqlpArgument? Argument { get; }
  IEnumerable<IGqlpSelection>? ResultObject { get; }

  IEnumerable<IGqlpFragment> Fragments { get; }

  ParseResultKind Result { get; }
  ITokenMessages Errors { get; }

  IEnumerable<IGqlpArgument> Usages { get; }
  IEnumerable<IGqlpSpread> Spreads { get; }

  string Show();
}

public interface IGqlpVariable
  : IGqlpNamed, IGqlpDirectives, IGqlpModifiers
{
  string? Type { get; }
  IGqlpConstant? DefaultValue { get; }
}

public interface IGqlpDirectives
{
  IEnumerable<IGqlpDirective> Directives { get; init; }
}

public interface IGqlpDirective
  : IGqlpNamed
{
  IGqlpArgument? Argument { get; }
}

public interface IGqlpFragment
  : IGqlpNamed
{
  string OnType { get; }
  IEnumerable<IGqlpSelection> Selections { get; }
}
