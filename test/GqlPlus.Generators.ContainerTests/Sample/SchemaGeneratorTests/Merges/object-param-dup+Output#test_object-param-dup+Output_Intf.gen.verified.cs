//HintName: test_object-param-dup+Output_Intf.gen.cs
// Generated from object-param-dup+Output.graphql+ for Intf
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_object_param_dup_Output;

public interface ItestObjParamDupOutp<Ttest>
{
  public ItestObjParamDupOutpObject AsObjParamDupOutp { get; set; }
}

public interface ItestObjParamDupOutpObject<Ttest>
{
  public Ttest Test { get; set; }
  public Ttest Type { get; set; }
}
