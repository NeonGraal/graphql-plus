namespace GqlPlus;

public sealed class GqlpUnit(string? tag = null)
  : GqlpValue(tag ?? "Unit")
  , IGqlpUnit;

public interface IGqlpUnit : IGqlpValue;
