//HintName: Model_generic-dual+output.gen.cs
// Generated from generic-dual+output.graphql+

/*
*/

namespace GqlTest.Model_generic_dual_output;

public interface IOutpGnrcDual
{
  OutpGnrcDualRef < I@046/0001 OutpGnrcDualAlt > field { get; }
}
public class OutputOutpGnrcDual
{
  public OutpGnrcDualRef < I@046/0001 OutpGnrcDualAlt > field { get; set; }
}

public interface IOutpGnrcDualRef
{
  $ref Asref { get; }
}
public class OutputOutpGnrcDualRef
{
  public $ref Asref { get; set; }
}

public interface IOutpGnrcDualAlt
{
  Number alt { get; }
  String AsString { get; }
}
public class DualOutpGnrcDualAlt
{
  public Number alt { get; set; }
  public String AsString { get; set; }
}
