namespace GqlPlus.Abstractions.Operation;

public interface IGqlpSelection
  : IAstError
  , IGqlpDirectives
{ }

public interface IGqlpField
  : IGqlpIdentified
  , IGqlpSelection
  , IAstModifiers
  , IGqlpSelections
{
  string? FieldAlias { get; }
  IGqlpArg? Arg { get; }
}

public interface IGqlpInline
  : IAstAbbreviated
  , IGqlpSelection
  , IGqlpSelections
  , IEquatable<IGqlpInline>
{
  string? OnType { get; }
}

public interface IGqlpSpread
  : IGqlpIdentified
  , IGqlpSelection
{ }

public interface IGqlpArg
  : IAstValue<IGqlpArg>
  , IEquatable<IGqlpArg>
{
  string? Variable { get; }
  IAstConstant? Constant { get; }
}
