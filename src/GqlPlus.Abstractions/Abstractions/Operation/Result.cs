namespace GqlPlus.Abstractions.Operation;

public interface IGqlpSelection
  : IGqlpError, IGqlpDirectives
{ }

public interface IGqlpField
  : IGqlpIdentified, IGqlpSelection, IGqlpModifiers, IGqlpSelections
{
  string? FieldAlias { get; }
  IGqlpArg? Arg { get; }
}

public interface IGqlpInline
  : IGqlpSelection
  , IGqlpSelections
  , IEquatable<IGqlpInline>
{
  string? OnType { get; }
}

public interface IGqlpSpread
  : IGqlpIdentified
  , IGqlpSelection
  , IEquatable<IGqlpSpread>
{ }

public interface IGqlpArg
  : IGqlpValue<IGqlpArg>
  , IEquatable<IGqlpArg>
{
  string? Variable { get; }
  IGqlpConstant? Constant { get; }
}
