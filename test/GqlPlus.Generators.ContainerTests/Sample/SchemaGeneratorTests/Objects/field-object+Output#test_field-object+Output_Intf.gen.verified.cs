//HintName: test_field-object+Output_Intf.gen.cs
// Generated from field-object+Output.graphql+ for Intf
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_field_object_Output;

public interface ItestFieldObjOutp
{
  ItestFieldObjOutpObject AsFieldObjOutp { get; }
}

public interface ItestFieldObjOutpObject
{
  ItestFldFieldObjOutp Field { get; }
}

public interface ItestFldFieldObjOutp
{
  string AsString { get; }
  ItestFldFieldObjOutpObject AsFldFieldObjOutp { get; }
}

public interface ItestFldFieldObjOutpObject
{
  decimal Field { get; }
}
