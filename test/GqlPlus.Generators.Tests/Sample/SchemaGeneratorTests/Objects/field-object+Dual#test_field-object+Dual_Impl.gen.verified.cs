//HintName: test_field-object+Dual_Impl.gen.cs
// Generated from field-object+Dual.graphql+ for Impl
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_field_object_Dual;

public class testFieldObjDual
  : ItestFieldObjDual
{
  public testFldFieldObjDual field { get; set; }
  public testFieldObjDual FieldObjDual { get; set; }
}

public class testFldFieldObjDual
  : ItestFldFieldObjDual
{
  public testNumber field { get; set; }
  public testString AsString { get; set; }
  public testFldFieldObjDual FldFieldObjDual { get; set; }
}
