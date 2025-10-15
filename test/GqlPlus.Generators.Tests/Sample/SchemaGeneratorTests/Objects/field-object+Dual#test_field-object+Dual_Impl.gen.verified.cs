//HintName: test_field-object+Dual_Impl.gen.cs
// Generated from field-object+Dual.graphql+ for Impl

/*
*/
namespace GqlPlus.GeneratorTests.Gqlp_field_object_Dual;

public class DualtestFieldObjDual
  : ItestFieldObjDual
{
  public FldFieldObjDual field { get; set; }
}

public class DualtestFldFieldObjDual
  : ItestFldFieldObjDual
{
  public Number field { get; set; }
  public String AsString { get; set; }
}
