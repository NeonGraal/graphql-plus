namespace GqlPlus.Abstractions.Operation;

public interface IGqlpSelection
  : IGqlpDirectives
{ }

public interface IGqlpField
  : IGqlpNamed, IGqlpSelection, IGqlpModifiers
{
  string? FieldAlias { get; }
  IGqlpArgument? Argument { get; }
  IEnumerable<IGqlpSelection> Selections { get; }
}

public interface IGqlpInline
  : IGqlpSelection
{
  string? OnType { get; }
  IEnumerable<IGqlpSelection> Selections { get; }
}

public interface IGqlpSpread
  : IGqlpNamed, IGqlpSelection
{ }

public interface IGqlpArgument
  : IGqlpValue<IGqlpArgument>
{
  string? Variable { get; }
  IGqlpConstant? Constant { get; }
}
