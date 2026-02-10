//HintName: test_field-object+Output_Intf.gen.cs
// Generated from field-object+Output.graphql+ for Intf
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_field_object_Output;

public interface ItestFieldObjOutp
{
  public ItestFieldObjOutpObject AsFieldObjOutp { get; set; }
}

public interface ItestFieldObjOutpObject
{
  public ItestFldFieldObjOutp Field { get; set; }
}

public interface ItestFldFieldObjOutp
{
  public string AsString { get; set; }
  public ItestFldFieldObjOutpObject AsFldFieldObjOutp { get; set; }
}

public interface ItestFldFieldObjOutpObject
{
  public decimal Field { get; set; }
}
