//HintName: test_object-field+Output_Intf.gen.cs
// Generated from object-field+Output.graphql+ for Intf
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_object_field_Output;

public interface ItestObjFieldOutp
{
  public ItestObjFieldOutpObject AsObjFieldOutp { get; set; }
}

public interface ItestObjFieldOutpObject
{
  public ItestFldObjFieldOutp Field { get; set; }
}

public interface ItestFldObjFieldOutp
{
  public ItestFldObjFieldOutpObject AsFldObjFieldOutp { get; set; }
}

public interface ItestFldObjFieldOutpObject
{
}
