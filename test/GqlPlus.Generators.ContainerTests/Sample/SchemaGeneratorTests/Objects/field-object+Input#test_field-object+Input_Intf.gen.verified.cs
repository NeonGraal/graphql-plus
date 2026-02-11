//HintName: test_field-object+Input_Intf.gen.cs
// Generated from field-object+Input.graphql+ for Intf
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_field_object_Input;

public interface ItestFieldObjInp
{
  ItestFieldObjInpObject AsFieldObjInp { get; }
}

public interface ItestFieldObjInpObject
{
  ItestFldFieldObjInp Field { get; }
}

public interface ItestFldFieldObjInp
{
  string AsString { get; }
  ItestFldFieldObjInpObject AsFldFieldObjInp { get; }
}

public interface ItestFldFieldObjInpObject
{
  decimal Field { get; }
}
