//HintName: test_field-object+Input_Intf.gen.cs
// Generated from field-object+Input.graphql+ for Intf
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_field_object_Input;

public interface ItestFieldObjInp
{
  public ItestFieldObjInpObject AsFieldObjInp { get; set; }
}

public interface ItestFieldObjInpObject
{
  public ItestFldFieldObjInp Field { get; set; }
}

public interface ItestFldFieldObjInp
{
  public string AsString { get; set; }
  public ItestFldFieldObjInpObject AsFldFieldObjInp { get; set; }
}

public interface ItestFldFieldObjInpObject
{
  public decimal Field { get; set; }
}
