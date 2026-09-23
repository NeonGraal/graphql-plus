namespace GqlPlus;

public class GqlpValue
  : IGqlpValue;

// TODO: Finish the plan's discriminated value model.
// The stage-1 design expects distinct `Null`, `Unit`, and `Void` variants plus
// concrete tagged list/map/value wrappers, but the current API is still a marker
// abstraction without those concrete value implementations.
public interface IGqlpValue;
