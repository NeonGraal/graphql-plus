//HintName: Model_generic-dual+output.gen.cs
// Generated from generic-dual+output.graphql+

/*
*/

namespace GqlTest.Model_generic_dual_output;

public interface IOutpGnrcDual
{
  OutpGnrcDualRef field { get; }
}
public class OutputOutpGnrcDual
  : IOutpGnrcDual
{
  public OutpGnrcDualRef field { get; set; }
}

public interface IOutpGnrcDualRef<Tref>
{
  Tref Asref { get; }
}
public class OutputOutpGnrcDualRef<Tref>
  : IOutpGnrcDualRef<Tref>
{
  public Tref Asref { get; set; }
}

public interface IOutpGnrcDualAlt
{
  Number alt { get; }
  String AsString { get; }
}
public class DualOutpGnrcDualAlt
  : IOutpGnrcDualAlt
{
  public Number alt { get; set; }
  public String AsString { get; set; }
}
