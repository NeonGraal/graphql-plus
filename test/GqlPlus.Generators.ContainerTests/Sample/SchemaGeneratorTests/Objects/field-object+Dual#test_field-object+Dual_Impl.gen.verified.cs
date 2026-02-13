//HintName: test_field-object+Dual_Impl.gen.cs
// Generated from field-object+Dual.graphql+ for Impl
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_field_object_Dual;

public class testFieldObjDual
  : ItestFieldObjDual
{
  public ItestFldFieldObjDual Field { get; set; }
  public ItestFieldObjDualObject AsFieldObjDual { get; set; }
}

public class testFldFieldObjDual
  : ItestFldFieldObjDual
{
  public decimal Field { get; set; }
  public string AsString { get; set; }
  public ItestFldFieldObjDualObject AsFldFieldObjDual { get; set; }
}
