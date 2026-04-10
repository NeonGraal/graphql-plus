namespace GqlPlus.Abstractions.Operation;

public interface IGqlpSelection
  : IAstError
  , IAstDirectives
{ }

public interface IGqlpField
  : IAstIdentified
  , IGqlpSelection
  , IAstModifiers
  , IAstSelections
{
  string? FieldAlias { get; }
  IGqlpArg? Arg { get; }
}

public interface IGqlpInline
  : IAstAbbreviated
  , IGqlpSelection
  , IAstSelections
  , IEquatable<IGqlpInline>
{
  string? OnType { get; }
}

public interface IGqlpSpread
  : IAstIdentified
  , IGqlpSelection
{ }

public interface IGqlpArg
  : IAstValue<IGqlpArg>
  , IEquatable<IGqlpArg>
{
  string? Variable { get; }
  IAstConstant? Constant { get; }
}
