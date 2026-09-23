namespace GqlPlus;

// TODO: Replace the marker-only scalar model with the concrete scalar types from
// the plan. The current type does not yet distinguish `Null`, `Unit`, `Void`,
// or the richer tagged scalar/list/map value variants expected by the core model.
public class GqlpScalar
  : IGqlpScalar;

public interface IGqlpScalar;
