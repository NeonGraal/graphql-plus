//HintName: test_field-object+Input_Impl.gen.cs
// Generated from field-object+Input.graphql+ for Impl
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_field_object_Input;

public class testFieldObjInp
  : ItestFieldObjInp
{
  public ItestFldFieldObjInp Field { get; set; }
  public ItestFieldObjInpObject AsFieldObjInp { get; set; }
}

public class testFldFieldObjInp
  : ItestFldFieldObjInp
{
  public decimal Field { get; set; }
  public string AsString { get; set; }
  public ItestFldFieldObjInpObject AsFldFieldObjInp { get; set; }
}
