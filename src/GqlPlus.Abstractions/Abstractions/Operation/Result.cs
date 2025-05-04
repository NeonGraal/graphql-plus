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
  : IGqlpSelection, IGqlpSelections
{
  string? OnType { get; }
}

public interface IGqlpSpread
  : IGqlpIdentified, IGqlpSelection
{ }

public interface IGqlpArg
  : IGqlpValue<IGqlpArg>
  , IEquatable<IGqlpArg>
{
  string? Variable { get; }
  IGqlpConstant? Constant { get; }
}
