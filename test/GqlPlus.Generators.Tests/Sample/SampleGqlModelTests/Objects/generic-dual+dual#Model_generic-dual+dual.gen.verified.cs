//HintName: Model_generic-dual+dual.gen.cs
// Generated from generic-dual+dual.graphql+

/*
*/

namespace GqlTest.Model_generic_dual_dual;

public interface IDualGnrcDual
{
  DualGnrcDualRef<DualGnrcDualAlt> field { get; }
}
public class DualDualGnrcDual
  : IDualGnrcDual
{
  public DualGnrcDualRef<DualGnrcDualAlt> field { get; set; }
}

public interface IDualGnrcDualRef<Tref>
{
  Tref Asref { get; }
}
public class DualDualGnrcDualRef<Tref>
  : IDualGnrcDualRef<Tref>
{
  public Tref Asref { get; set; }
}

public interface IDualGnrcDualAlt
{
  Number alt { get; }
  String AsString { get; }
}
public class DualDualGnrcDualAlt
  : IDualGnrcDualAlt
{
  public Number alt { get; set; }
  public String AsString { get; set; }
}
