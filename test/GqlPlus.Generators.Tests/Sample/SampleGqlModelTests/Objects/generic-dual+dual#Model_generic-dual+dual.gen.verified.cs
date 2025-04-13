//HintName: Model_generic-dual+dual.gen.cs
// Generated from generic-dual+dual.graphql+

/*
*/

namespace GqlTest.Model_generic_dual_dual;

public interface IDualGnrcDual
{
  DualGnrcDualRef < I@044/0001 DualGnrcDualAlt > field { get; }
}
public class DualDualGnrcDual
{
  public DualGnrcDualRef < I@044/0001 DualGnrcDualAlt > field { get; set; }
}

public interface IDualGnrcDualRef
{
  $ref Asref { get; }
}
public class DualDualGnrcDualRef
{
  public $ref Asref { get; set; }
}

public interface IDualGnrcDualAlt
{
  Number alt { get; }
  String AsString { get; }
}
public class DualDualGnrcDualAlt
{
  public Number alt { get; set; }
  public String AsString { get; set; }
}
