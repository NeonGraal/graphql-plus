namespace GqlPlus.Abstractions.Operation;

public interface IGqlpSelection
  : IGqlpDirectives
{ }

public interface IGqlpField
  : IGqlpIdentified
  , IGqlpSelection
  , IGqlpModifiers
{
  string? FieldAlias { get; }
  IGqlpArg? Arg { get; }
  IEnumerable<IGqlpSelection> Selections { get; }
}

public interface IGqlpInline
  : IGqlpAbbreviated
  , IGqlpSelection
  , IEquatable<IGqlpInline>
{
  string? OnType { get; }
  IEnumerable<IGqlpSelection> Selections { get; }
}

public interface IGqlpSpread
  : IGqlpIdentified
  , IGqlpSelection
{ }

public interface IGqlpArg
  : IGqlpValue<IGqlpArg>
  , IEquatable<IGqlpArg>
{
  string? Variable { get; }
  IGqlpConstant? Constant { get; }
}
