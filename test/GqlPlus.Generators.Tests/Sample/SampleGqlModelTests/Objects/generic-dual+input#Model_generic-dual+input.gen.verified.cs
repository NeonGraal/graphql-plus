//HintName: Model_generic-dual+input.gen.cs
// Generated from generic-dual+input.graphql+

/*
*/

namespace GqlTest.Model_generic_dual_input;

public interface IInpGnrcDual
{
  InpGnrcDualRef field { get; }
}
public class InputInpGnrcDual
  : IInpGnrcDual
{
  public InpGnrcDualRef field { get; set; }
}

public interface IInpGnrcDualRef<Tref>
{
  Tref Asref { get; }
}
public class InputInpGnrcDualRef<Tref>
  : IInpGnrcDualRef<Tref>
{
  public Tref Asref { get; set; }
}

public interface IInpGnrcDualAlt
{
  Number alt { get; }
  String AsString { get; }
}
public class DualInpGnrcDualAlt
  : IInpGnrcDualAlt
{
  public Number alt { get; set; }
  public String AsString { get; set; }
}
